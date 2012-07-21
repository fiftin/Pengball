using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using System.Xml;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Linq;

namespace PengEngine
{
    public class PengObject
    {
        private PengWorld world;
        private Body body;
        private string name;

        private Vector2 size;
        private Vector2 origin;
        private Texture2D texture;
        private SpriteEffects mirroring;

        private IDictionary<string, PengState> states = new Dictionary<string, PengState>();
        private string stateID = null;
        private int textureIndex = -1;

        public void AddState(string id, PengState state)
        {
            states.Add(id, state);
        }

        public void RemoveState(string id)
        {
            states.Remove(id);
        }

        private void SetState(string stateID)
        {
            if (!states.ContainsKey(stateID))
                throw new ArgumentException("stateID");
            bool cancel = false;
            OnStateChanging(stateID, ref cancel);
            if (!cancel)
            {
                var oldStateID = stateID;
                this.stateID = stateID;
                OnStateChanged(oldStateID);
            }
        }

        public string StateID
        {
            get { return stateID; }
            set { SetState(value); }
        }

        public PengState State
        {
            get
            {
                if (StateID == null)
                    return null;
                PengState state;
                if (!states.TryGetValue(StateID, out state))
                    return null;
                return state;
            }
        }

        protected virtual void OnStateChanging(string stateID, ref bool cancel)
        {
        }

        protected virtual void OnStateChanged(string oldStateID)
        {
            if (body != null && State.Position.HasValue)
                body.Position = State.Position.Value;
            if (body != null && State.Rotation.HasValue)
                body.Rotation = State.Rotation.Value;
            if (State.Textures.Count > 0)
            {
                textureIndex = 0;
                Texture = State.Textures[0];
            }
        }

        public PengObject(string name, PengWorld world)
        {
            this.name = name;
            this.world = world;
            world.AddObject(this);
        }

        public Texture2D Texture
        {
            get
            {
                return texture;
            }
            set
            {
                texture = value;
            }
        }

        public PengWorld World
        {
            get { return world; }
            internal set { world = value; }
        }

        public string Name
        {
            get { return name; }
        }

        public Body Body
        {
            get { return body; }
            protected set
            {
                body = value;
            }
        }

        public float Rotation
        {
            get { return Body.Rotation; }
            set { Body.Rotation = value; }
        }

        public Vector2 Position
        {
            get { return Body.Position; }
            set { Body.Position = value; }
        }

        public float X
        {
            get
            {
                return Position.X;
            }
            set
            {
                Position = new Vector2(value, Position.Y);
            }
        }

        public float Y
        {
            get
            {
                return Position.Y;
            }
            set
            {
                Position = new Vector2(Position.X, value);
            }
        }

        public float AngularDamping
        {
            get
            {
                return Body.AngularDamping;
            }
            set
            {
                Body.AngularDamping = value;
            }
        }

        public float LinearDamping
        {
            get
            {
                return Body.LinearDamping;
            }
            set
            {
                Body.LinearDamping = value;
            }
        }

        public float Restitution
        {
            get
            {
                return Body.Restitution;
            }
            set
            {
                Body.Restitution = value;
            }
        }

        public float Friction
        {
            get
            {
                return Body.Friction;
            }
            set
            {
                Body.Friction = value;
            }
        }

        public Vector2 Size
        {
            get { return size; }
            protected set
            {
                size = value;
                Origin = new Vector2(value.X / 2, value.Y / 2);
            }
        }

        public float Mass
        {
            get
            {
                return Body.Mass;
            }
            set
            {
                Body.Mass = value;
            }
        }

        public Vector2 LinearVelocity
        {
            get
            {
                return Body.LinearVelocity;
            }
            set
            {
                Body.LinearVelocity = value;
            }
        }

        public float AngularVelocity
        {
            get
            {
                return Body.AngularVelocity;
            }
            set
            {
                Body.AngularVelocity = value;
            }
        }

        public Vector2 Origin
        {
            get { return origin; }
            protected set { origin = value; }
        }


        public SpriteEffects Mirroring
        {
            get { return mirroring; }
            set { mirroring = value; }
        }

        public Vector2 GetTextureOrigin()
        {
            return new Vector2(Texture.Width / Size.X * Origin.X,
                Texture.Height / Size.Y * Origin.Y);
        }

        public virtual void OnDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Texture != null)
            {
                spriteBatch.Draw(Texture, new Rectangle(
                        ConvertWorldToScreen(Position.X),
                        ConvertWorldToScreen(Position.Y),
                        ConvertWorldToScreen(Size.X),
                        ConvertWorldToScreen(Size.Y)),
                    null,
                    Color.White,
                    Rotation,
                    GetTextureOrigin(),
                    Mirroring,
                    1);
            }
        }

        private void UpdateTexture(GameTime gameTime)
        {
            if (State != null)
            {
                if (textureIndex < State.Textures.Count - 1)
                    textureIndex++;
                else
                    textureIndex = 0;
                texture = State.Textures[textureIndex];
            }
        }

        public virtual void OnUpdate(GameTime gameTime)
        {
            UpdateTexture(gameTime);
            if (ListenContacts)
            {
                var adge = Body.ContactList;
                while (adge != null)
                {
                    if (adge.Contact.IsTouching())
                    {

                        var bodyA = adge.Contact.FixtureA.Body;
                        var bodyB = adge.Contact.FixtureB.Body;
                        Body otherBody = null;
                        if (bodyA != Body || bodyB != Body)
                        {
                            if (bodyA != Body)
                            {
                                otherBody = bodyA;
                            }
                            else if (bodyB != Body)
                            {
                                otherBody = bodyB;
                            }
                        }
                        if (otherBody != null)
                        {
                            PengObject other = World.FindObjectByBody(otherBody);
                            if (other != null)
                            {
                                OnContacted(new PengContactEventArgs(other));
                            }
                        }
                    }

                    adge = adge.Next;
                }
            }
        }

        internal void Update(GameTime gameTime)
        {
            OnUpdate(gameTime);
        }

        internal void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            OnDraw(gameTime, spriteBatch);
        }

        public Vector2 ConvertWorldToScreen(Vector2 simUnits)
        {
            return new Vector2(World.ConvertWorldToScreen(simUnits.X),World.ConvertWorldToScreen(simUnits.Y));
        }

        public int ConvertWorldToScreen(float simUnits)
        {
            return World.ConvertWorldToScreen(simUnits);
        }

        public T LoadContent<T>(string assetName)
        {
            return world.LoadContent<T>(assetName);
        }

        public virtual void Load(string content)
        {
        }

        protected virtual void OnContacted(PengContactEventArgs e)
        {
            if (Contacted != null)
            {
                Contacted(this, e);
            }
        }

        protected bool ListenContacts { get; set; }

        public event EventHandler<PengContactEventArgs> Contacted;
    }
}
