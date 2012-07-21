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

        private PengballWorld parallelWorld;
        private float? targetPosition;
        private DateTime? targetTime;
        private Random random = new Random();
        private Vector2[] trajectory = new Vector2[0];
        private Vector2? previousUpdateBollPosition;


        public ComputerPlayer(string id, PengWorld world, PlayerSide side, Vector2 startPosition)
            : base(id, world, side, startPosition)
        {
            string screenplay = ((PengballWorld)world).Screenplay;
            screenplay = screenplay.Replace("ComputerPlayer", "Player");
            parallelWorld = new PengballWorld(null, world.Content, false, screenplay, false);
            parallelWorld.Tag = "parallelWorld";
            ((PengballWorld)world).Loaded += new EventHandler(world_Loaded);
            TargetPositionOffset = 0.07f;
            TargetPositionRandomOffset = 0.05f;
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
                if (InMySide(World.Ball.Position)
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
                if (InMySide(parallelWorld.Ball.Position)
                    && parallelWorld.Ball.Position.Y > 2f && parallelWorld.Ball.LinearVelocity.Y > 0)
                {
                    break;
                }
                // мяч перелетел на другую сторону поля
                if (!InMySide(parallelWorld.Ball.Position))
                {
                    stopCalculation = true;
                    break;
                }
            }
            if (!stopCalculation)
            {
                targetPosition = parallelWorld.Ball.Position.X + Sign * TargetPositionOffset + (float)random.NextDouble() * Sign * TargetPositionRandomOffset;
                
                if (targetPosition > WorldSize.X / 2 - (World.Objects["treeBlock"].Size.X / 2 + Size.X / 2)
                    && targetPosition < WorldSize.X / 2 + (World.Objects["treeBlock"].Size.X / 2 + Size.X / 2))
                {
                    if (Side == PlayerSide.Left)
                    {
                        targetPosition = WorldSize.X / 2 - (World.Objects["treeBlock"].Size.X / 2 + Size.X / 2);
                    }
                    else
                    {
                        targetPosition = WorldSize.X / 2 + (World.Objects["treeBlock"].Size.X / 2 + Size.X / 2);
                    }
                }

                targetTime = DateTime.Now.Add(totalGameTime - TimeSpan.FromMilliseconds(700));
            }
            else
            {
                targetPosition = null;
                targetTime = null;
            }
            trajectory = trajectoryPointList.ToArray();
        }

        public float TargetPositionRandomOffset
        {
            get;
            set;
        }

        public float TargetPositionOffset
        {
            get;
            set;
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

        private float GetStartTargetPosition()
        {
            if (Side == PlayerSide.Right)
                return 3.5f;
            else
                return 2.5f;
        }

        protected override void OnReset()
        {
            base.OnReset();
            if (InMySide(Ball.Position))
            {
                targetPosition = GetStartTargetPosition();
                targetTime = null;
                JumpInternal();
            }
            else
            {
                targetPosition = null;
                targetTime = null;
            }
        }

        private float Sign
        {
            get
            {
                return Side == PlayerSide.Right ? 1 : -1;
            }
        }

        public override void OnUpdate(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (GameStopped)
            {
                base.OnUpdate(gameTime);
                return;
            }

            if (previousUpdateBollPosition.HasValue
                && !InMySide(previousUpdateBollPosition.Value)
                && InMySide(World.Ball.Position)
                && Sign * World.Ball.LinearVelocity.X > 0)
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

            base.OnUpdate(gameTime);
        }

    }
}
