using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PengEngine.Internal;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework.Content;
using FarseerPhysics.DebugViews;

namespace PengEngine
{
    public class PengWorld
    {
        private World world;
        private ContentManager content;
        private IDictionary<string, PengObject> objects;
        private IDictionary<string, PengObject> readOnlyObjects;
        private PengViewport viewport;
        private DebugViewXNA debugView;
        private GraphicsDevice graphics;
        private SpriteBatch spriteBatch;
        private bool debugMode;

        public object Tag { get; set; }

        public PengWorld()
            : this(null, null, false)
        {
        }

        public PengWorld(GraphicsDevice graphics ,ContentManager content, bool visible = true)
        {
            objects = new Dictionary<string, PengObject>();
            readOnlyObjects = new ReadOnlyDictionary<string, PengObject>(objects);
            world = new World(new Vector2(0, 10));
            viewport = new PengViewport(0, 0, 40, 20);
            Visible = visible;
            this.content = content;
            this.graphics = graphics;
            BackgroundColor = Color.CornflowerBlue;
            if (Visible)
            {
                spriteBatch = new SpriteBatch(graphics);
                debugView = new DebugViewXNA(World);
                debugView.LoadContent(graphics, content);
                
            }
        }

        internal void AddObject(PengObject obj)
        {
            if (objects.ContainsKey(obj.Name))
                throw new ArgumentException("obj");
            objects.Add(obj.Name, obj);
        }

        public void RemoveObject(string name)
        {
            PengObject value;
            if (objects.TryGetValue(name, out value))
            {
                objects.Remove(name);
                World.RemoveBody(value.Body);
                value.World = null;
            }
        }

        public T LoadContent<T>(string assetName)
        {
            return Content.Load<T>(assetName);
        }

        protected GraphicsDevice Graphics
        {
            get
            {
                return graphics;
            }
        }

        protected SpriteBatch SpriteBatch
        {
            get
            {
                return spriteBatch;
            }
        }

        public bool Visible { get; private set; }

        public bool DebugMode
        {
            get { return debugMode; }
            set { debugMode = value; }
        }

        public World World
        {
            get { return world; }
        }

        public ContentManager Content
        {
            get { return content; }
        }

        public IDictionary<string, PengObject> Objects
        {
            get
            {
                return readOnlyObjects;
            }
        }

        public PengViewport Viewport
        {
            get { return viewport; }
            set { viewport = value; }
        }

        public int ConvertWorldToScreen(float worldUnits)
        {
            return (int)Math.Ceiling(graphics.Viewport.Width / Viewport.Width * worldUnits);
        }

        public virtual void Update(GameTime gameTime)
        {
            World.Step(Math.Min((float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f, (1f / 30f)));
            foreach (var obj in objects.Values)
            {
                obj.Update(gameTime);
            }
        }

        public Color BackgroundColor { get; set; }
        public Texture2D BackgroundTexture { get; set; }

        protected virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!Visible)
                return;

            if (DebugMode)
            {
                Matrix projection = Matrix.Identity;
                var scale = Matrix.CreateScale(new Vector3(0.40f, 0.58f, 0));
                //var scale = Matrix.CreateScale(new Vector3(0.08f, 0.10f, 0));
                var refl = Matrix.CreateReflection(new Plane(new Vector3(0, 1, 0), 0));
                var tr = Matrix.CreateTranslation(new Vector3(-2.5f, -1.77f, 0.1f));
                projection = projection * tr * refl * scale;
                Matrix view = Matrix.Identity;
                debugView.RenderDebugData(ref projection, ref view);
            }
            else if (BackgroundTexture != null)
            {
                spriteBatch.Draw(BackgroundTexture, graphics.Viewport.Bounds, Color.White);
            }

            foreach (var obj in objects.Values)
            {
                obj.Draw(gameTime, spriteBatch);
            }
        }

        public virtual void Draw(GameTime gameTime)
        {
            if (!Visible)
                return;
            Graphics.Clear(BackgroundColor);
            SpriteBatch.Begin();
            Draw(gameTime, SpriteBatch);
            SpriteBatch.End();
        }

        public PengObject FindObjectByBody(Body body)
        {
            foreach (var obj in objects.Values)
            {
                if (obj.Body == body)
                {
                    return obj;
                }
            }
            return null;
        }

        protected virtual void Load(string content, Func<string, Type> typeProvider)
        {
            PengXmlWorldLoader.Instance.Load(this,
                System.Xml.XmlReader.Create(new System.IO.StringReader(content)),
                typeProvider);
        }
    }
}
