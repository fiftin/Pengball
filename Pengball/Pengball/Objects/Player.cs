using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PengEngine;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Common;
using Microsoft.Xna.Framework.Input;
namespace Pengball.Objects
{

    public class Player : Actor
    {

        private DateTime? lastJumpTime;

        public const float DefaultJumpImpulse = 5.8f;
        public const float DefaultVelocity = 2.5f;

        public Player(string id, PengWorld world, PlayerSide side, Vector2 startPosition)
            : base(id, world)
        {
            Side = side;
            StartPosition = startPosition;
            JumpImpulse = DefaultJumpImpulse;
            Velocity = DefaultVelocity;
            ListenContacts = true;
            Initialize();
        }

        public Vector2 StartPosition { get; set; }

        public void Reset()
        {
            Position = StartPosition;
            LinearVelocity = Vector2.Zero;
            InJump = false;
            OnReset();
        }

        protected virtual void OnReset()
        {
        }

        protected override void OnContacted(PengContactEventArgs e)
        {
            if (e.Contactee.Name == "footer" && InJump)
            {
                InJump = false;
            }
            base.OnContacted(e);
        }

        public void MoveLeft()
        {
            Body.LinearVelocity = new Vector2(-Velocity, Body.LinearVelocity.Y);
        }

        public void MoveRight()
        {
            Body.LinearVelocity = new Vector2(Velocity, Body.LinearVelocity.Y);
        }

        public void NoMove()
        {
            Body.LinearVelocity = new Vector2(0, Body.LinearVelocity.Y);
        }


        protected void JumpInternal()
        {
            Body.ApplyLinearImpulse(new Vector2(0, -JumpImpulse));
            lastJumpTime = DateTime.Now;
            InJump = true;
        }

        public void Jump()
        {
            if (lastJumpTime != null && DateTime.Now - lastJumpTime < TimeSpan.FromMilliseconds(500))
            {
                InJump = true;
                return;
            }
            if (!InJump)
            {
                JumpInternal();
            }
        }

        public bool InJump
        {
            get;
            private set;
        }

        public float JumpImpulse
        {
            get;
            set;
        }

        public float Velocity { get; set; }

        public PlayerSide Side
        {
            get;
            private set;
        }

        public Player Rival { get; internal set; }

        protected bool InMySide(Vector2 point)
        {
            if (Side == PlayerSide.Left)
            {
                return point.X < WorldSize.X / 2;
            }
            else
            {
                return point.X > WorldSize.X / 2;
            }
            //return point.X > World.Viewport.Width / 2 + World.Tree.Size.X / 2;
        }

        private float ConvertTextureToLocalX(int i)
        {
            return (Size.X / Texture.Width) * (float)i;
        }

        private Vector2 ConvertTextureToLocal(int x, int y)
        {
            if (Side == PlayerSide.Left)
            {
                x = Texture.Width - x;
            }
            float xx = (Size.X / Texture.Width) * (float)x - Size.X / 2;
            float yy = (Size.Y / Texture.Height) * (float)y - Size.Y / 2;
            return new Vector2(xx, yy);
        }

        private void InitializeFixtures()
        {
            FixtureFactory.AttachCircle(
                ConvertTextureToLocalX(165) / 2,
                3.4f,
                Body,
                ConvertTextureToLocal(88, 158));

            FixtureFactory.AttachCircle(
                ConvertTextureToLocalX(90) / 2,
                3.4f,
                Body,
                ConvertTextureToLocal(85, 106));
        }

        private void Initialize()
        {
            Mirroring = (Side == PlayerSide.Left) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Texture = LoadContent<Texture2D>("textures/penguin");
            Size = new Vector2(0.7f, 0.7f * Texture.Height / Texture.Width);
            Body = BodyFactory.CreateBody(World.World);
            InitializeFixtures();
            Position = StartPosition;
            Body.FixedRotation = true;
            Body.BodyType = BodyType.Dynamic;
            Body.IgnoreCollisionWith(World.Objects["ballLeftStand"].Body);
            Body.IgnoreCollisionWith(World.Objects["ballRightStand"].Body);
            Body.IgnoreCollisionWith(World.Objects["leftWallForBall"].Body);
            Body.IgnoreCollisionWith(World.Objects["rightWallForBall"].Body);
            Body.IgnoreCollisionWith(World.Objects["tree"].Body);
        }

        public override void OnUpdate(GameTime gameTime)
        {
            base.OnUpdate(gameTime);
        }
    }
}
