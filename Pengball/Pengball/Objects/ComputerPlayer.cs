using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PengEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pengball.Objects
{
    public class ComputerPlayer : Player
    {

        private enum ContacteeEnum
        {
            Tree,
            Roof,
            Self,
            Other,
        }

        private float targetPositionOffset = 0.07f;
        private float targetPositionRandomOffset = 0.05f;

        private PengballWorld parallelWorld;
        private float? targetPosition;
        private DateTime? targetTime;
        private Random random = new Random();
        private Vector2[] trajectory = new Vector2[0];
        private Vector2? previousUpdateBollPosition;



        public ComputerPlayer(string id, PengWorld world, PlayerDirection dir, Vector2 startPosition)
            : base(id, world, dir, startPosition)
        {
            string screenplay = ((PengballWorld)world).Screenplay;
            screenplay = screenplay.Replace("ComputerPlayer", "Player");
            parallelWorld = new PengballWorld(null, world.Content, false, screenplay, false);
            parallelWorld.Tag = "parallelWorld";
            ((PengballWorld)world).Loaded += new EventHandler(world_Loaded);
        }

        void world_Loaded(object sender, EventArgs e)
        {
            World.Ball.Contacted += new EventHandler<PengContactEventArgs>(Ball_Contacted);
        }

        private ContacteeEnum GetContactee(PengContactEventArgs e)
        {
            switch (e.Contactee.Name)
            {
                case "tree":
                    return ContacteeEnum.Tree;
                case "roof":
                    return ContacteeEnum.Roof;
                default:
                    if (e.Contactee == this)
                        return ContacteeEnum.Self;
                    return ContacteeEnum.Other;
            }
        }

        void Ball_Contacted(object sender, PengContactEventArgs e)
        {
            if (!GameStopped)
            {
                var contactee = GetContactee(e);
                if (IsOnTheMySide(World.Ball.Position)
                    && contactee != ContacteeEnum.Other)
                {
                    if (contactee == ContacteeEnum.Self)
                    {
                        CalculateTargetPosition(ContacteeEnum.Self);
                    }
                    else
                        CalculateTargetPosition(contactee);
                }
            }
        }

        public void InitializeParallelWorld()
        {
            parallelWorld.Ball.Position = World.Ball.Position;
            parallelWorld.Ball.LinearVelocity = World.Ball.LinearVelocity;
            parallelWorld.Ball.AngularVelocity = World.Ball.AngularVelocity;
        }

        private void CalculateTargetPosition(ContacteeEnum contactee)
        {
            InitializeParallelWorld();

            TimeSpan totalGameTime = new TimeSpan(0);
            TimeSpan elapsedGameTime = TimeSpan.FromMilliseconds(50);
            bool stopCalculation = false;
            parallelWorld.Ball.Contacted += new EventHandler<PengContactEventArgs>(delegate(object sender, PengContactEventArgs e)
            {
                if (e.Contactee.Name == "footer")
                    stopCalculation = true;
            });

            List<Vector2> trajectoryPointList = new List<Vector2>();
            while (!stopCalculation)
            {
                trajectoryPointList.Add(parallelWorld.Ball.Position);
                totalGameTime += elapsedGameTime;
                parallelWorld.Update(new GameTime(totalGameTime, elapsedGameTime, false));

                // расчет затянулся
                if (totalGameTime.TotalSeconds > 60)
                {
                    stopCalculation = true;
                    break;
                }

                // мяч достиг точки для удара
                if (parallelWorld.Ball.Position.X > 3f && parallelWorld.Ball.Position.Y > 2f && parallelWorld.Ball.LinearVelocity.Y > 0)
                    break;

                // мяч перелетел на другую сторону поля
                if (parallelWorld.Ball.Position.X < 2.3)
                {
                    stopCalculation = true;
                    break;
                }
            }
            if (!stopCalculation)
            {
                targetPosition = parallelWorld.Ball.Position.X + TargetPositionOffset + (float)random.NextDouble() * targetPositionRandomOffset;
                targetTime = DateTime.Now.Add(totalGameTime - TimeSpan.FromMilliseconds(700));
            }
            else
            {
                targetPosition = null;
                targetTime = null;
            }
            trajectory = trajectoryPointList.ToArray();
        }

        private bool IsOnTheMySide(Vector2 point)
        {
            return point.X > World.Viewport.Width / 2 + World.Tree.Size.X / 2;
        }

        public float TargetPositionRandomOffset
        {
            get { return targetPositionRandomOffset; }
            set { targetPositionRandomOffset = value; }
        }

        public float TargetPositionOffset
        {
            get { return targetPositionOffset; }
            set { targetPositionOffset = value; }
        }

        public override void OnDraw(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            if (World.DebugMode)
            {
                Texture2D pointTexture = LoadContent<Texture2D>("textures/point");
                foreach (Vector2 pt in trajectory)
                {
                    spriteBatch.Draw(pointTexture, ConvertWorldToScreen(pt), Color.White);
                }
            }
            base.OnDraw(gameTime, spriteBatch);
        }


        protected override void OnReset()
        {
            base.OnReset();
            if (World.Ball.Position.X > 3)
            {
                targetPosition = 3.5f;
                targetTime = null;
                //targetTime = DateTime.Now;
                JumpInternal();
            }
            else
            {
                targetPosition = null;
                targetTime = null;
            }
        }

        public override void OnUpdate(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (!GameStopped)
            {

                if (previousUpdateBollPosition.HasValue
                    && !IsOnTheMySide(previousUpdateBollPosition.Value)
                    && IsOnTheMySide(World.Ball.Position)
                    && World.Ball.LinearVelocity.X > 0)
                {
                    CalculateTargetPosition(ContacteeEnum.Other);
                }

                if (targetPosition != null)
                {
                    if (Position.X > targetPosition + 0.03)
                    {
                        MoveLeft();
                    }
                    else if (Position.X < targetPosition - 0.03)
                    {
                        MoveRight();
                    }
                    else
                    {
                        NoMove();
                        if (targetTime != null)
                        {
                            var milliseconds = (targetTime.Value - DateTime.Now).TotalMilliseconds;
                            if (milliseconds < 0 && milliseconds > -1000)
                            {
                                Jump();
                            }
                        }
                    }
                }

                previousUpdateBollPosition = World.Ball.Position;

            }

            base.OnUpdate(gameTime);
        }

    }
}
