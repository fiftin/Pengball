using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics.Contracts;

namespace PengEngine
{
    public class PengState
    {
        private List<Texture2D> textureList = new List<Texture2D>();
        private int? rotation;
        private Vector2? position;

        public void LoadTexturesFromSpriteList(Texture2D spriteList, int spriteWidth, int spriteHeight, int startIndex, int count)
        {
            Contract.Requires(spriteList != null);
            Contract.Requires(spriteWidth > 0);
            Contract.Requires(startIndex > 0);
            Contract.Requires(count > 0);
            Contract.Requires(spriteList.Width % spriteWidth == 0);
            Contract.Requires(spriteList.Height % spriteHeight == 0);
            int m = spriteList.Width / spriteWidth;
            int n = spriteList.Height / spriteHeight;
            Contract.Requires(m * n >= count);
            for (int i = startIndex; i < count; i++)
            {
                int y = (i / m) * spriteHeight;
                int x = (i - y * m) * spriteHeight;
                Color[] data = new Color[spriteWidth * spriteHeight];
                spriteList.GetData(1, new Rectangle(x, y, spriteWidth, spriteHeight), data, 0, data.Length);
                Texture2D texture = new Texture2D(spriteList.GraphicsDevice, spriteWidth, spriteHeight);
                texture.SetData(data);
            }
        }

        public IList<Texture2D> Textures
        {
            get
            {
                return textureList.AsReadOnly();
            }
        }

        public void AddTexture(Texture2D texture)
        {
            textureList.Add(texture);
        }

        public void RemoveTexture(Texture2D texture)
        {
            textureList.Remove(texture);
        }

        public void RemoveAllTextures()
        {
            textureList.Clear();
        }

        public void RemoveTextureAt(int index)
        {
            textureList.RemoveAt(index);
        }

        public float? AngularDamping
        {
            get;
            set;
        }

        public float? LinearDamping
        {
            get;
            set;
        }

        public float? Restitution
        {
            get;
            set;
        }

        public float? Friction
        {
            get;
            set;
        }

        public Vector2? Size
        {
            get;
            set;
        }

        public float? Mass
        {
            get;
            set;
        }

        public Vector2? LinearVelocity
        {
            get;
            set;
        }

        public float? AngularVelocity
        {
            get;
            set;
        }

        public Vector2? Origin
        {
            get;
            set;
        }

        public SpriteEffects? Mirroring
        {
            get;
            set;
        }

        public Vector2? Position
        {
            get { return position; }
            set { position = value; }
        }

        public int? Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

    }
}
