using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PengEngine;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pengball.Objects
{
    public class Ball : Actor
    {
        private float radius;

        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public Vector2 LeftStartPos { get; set; }
        public Vector2 RightStartPos { get; set; }
        public PlayerSide InitialSide { get; private set; }

        public Ball(string name, PengWorld world, Vector2 leftStartPos, Vector2 rightStartPos, float radius, PlayerSide side)
            : base(name, world)
        {
            this.radius = radius;
            LeftStartPos = leftStartPos;
            RightStartPos = rightStartPos;
            InitialSide = side;

            Inititalize();
        }

        bool isSleep = true;

        public void Reset()
        {
            if (InitialSide == PlayerSide.Left)
                ResetToLeft();
            else
                ResetToRight();
        }

        public void ResetToLeft()
        {
            Position = LeftStartPos;
            Body.LinearVelocity = Vector2.Zero;
            Body.AngularVelocity = 0;
            isSleep = true;
            Body.RestoreCollisionWith(World.Objects["ballLeftStand"].Body);
        }

        public void ResetToRight()
        {
            Position = RightStartPos;
            Body.LinearVelocity = Vector2.Zero;
            Body.AngularVelocity = 0;
            isSleep = true;
            Body.RestoreCollisionWith(World.Objects["ballRightStand"].Body);
        }

        protected override void OnContacted(PengContactEventArgs e)
        {
            if (isSleep && e.Contactee is Player)
            {
                Body.IgnoreCollisionWith(World.Objects["ballLeftStand"].Body);
                Body.IgnoreCollisionWith(World.Objects["ballRightStand"].Body);
                isSleep = false;
            }
            base.OnContacted(e);
        }

        private void Inititalize()
        {
            ListenContacts = true;
            var initPos = InitialSide == PlayerSide.Left ? LeftStartPos : RightStartPos;
            Body = BodyFactory.CreateCircle(World.World, radius, 10, initPos);
            Body.BodyType = FarseerPhysics.Dynamics.BodyType.Dynamic;
            Size = new Vector2(radius * 2, radius * 2);
            Texture = LoadContent<Texture2D>("textures/ball");
            Body.IgnoreCollisionWith(World.Objects["treeBlock"].Body);
        }
    }
}
