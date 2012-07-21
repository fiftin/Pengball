using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PengEngine;
using FarseerPhysics.Factories;
using FarseerPhysics.Common;
using Microsoft.Xna.Framework;

namespace Pengball.Objects
{
    public class Tree : PengObject
    {
        public Tree(string name, PengWorld world)
            : base(name, world)
        {
            Initialize();
        }

        private void Initialize()
        {
            var verexArray = new Vector2[] {
                new Vector2(0, -1.6f),
                new Vector2(0.35f, 0),
                new Vector2(-0.35f, 0),
            };
            var vertices = new Vertices(verexArray);
            Body = BodyFactory.CreatePolygon(World.World, vertices, 10);
            Origin = new Vector2(0.35f, 1.6f);
        }

        public override void OnUpdate(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.OnUpdate(gameTime);
        }
    }
}
