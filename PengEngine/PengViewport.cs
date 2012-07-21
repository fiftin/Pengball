using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PengEngine
{
    public struct PengViewport
    {
        private float left;
        private float top;
        private float width;
        private float height;

        public PengViewport(Vector2 size)
            : this(0, 0, size.X, size.Y)
        {
        }

        public PengViewport(float left, float top, float width, float height)
            : this()
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }
         
        public float Height
        {
            get { return height; }
            set { height = value; }
        }

        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        public float Top
        {
            get { return top; }
            set { top = value; }
        }

        public float Left
        {
            get { return left; }
            set { left = value; }
        }

    }
}
