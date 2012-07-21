using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PengEngine;
using Microsoft.Xna.Framework;

namespace Pengball.Objects
{
    public class Actor : PengObject
    {
        public Actor(string name, PengWorld world)
            : base(name, world)
        {
        }

        public new PengballWorld World
        {
            get
            {
                return (PengballWorld)base.World;
            }
        }
        public Vector2 WorldSize { get { return World.Size; } }
        public Ball Ball { get { return World.Ball; } }
        public bool GameStopped { get { return World.GameStopped; } }

    }
}
