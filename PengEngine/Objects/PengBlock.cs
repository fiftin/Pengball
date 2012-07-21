using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;

namespace PengEngine.Objects
{
    public class PengBlock : PengObject
    {
        public PengBlock(string name, PengWorld world, Vector2 size)
            : base(name, world)
        {
            Size = size;
            Initialize();
        }

        private void Initialize()
        {
            Body = BodyFactory.CreateRectangle(World.World, Size.X, Size.Y, 100);
        }
    }
}
