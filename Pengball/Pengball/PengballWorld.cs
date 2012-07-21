﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PengEngine;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pengball.Objects;

namespace Pengball
{

    public enum GameStopReason
    {
        None,
        GoalToLeft,
        GoalToRight
    }

    public class PengballWorld : PengWorld
    {

        public PengballWorld(GraphicsDevice graphics, ContentManager content, bool gameplay = true, string screenplay = null, bool visible = true)
            : base(graphics, content, visible)
        {
            Viewport = new PengViewport(0, 0, 5, 3);
            Screenplay = screenplay;
            if (Screenplay == null)
                Screenplay = Content.Load<string>("screenplays/screenplay1");

            Load(Screenplay, GetTypeByName);
            this.gameplay = gameplay;
            Ball = (Ball)Objects["ball"];
            LeftPlayer = (Player)Objects["leftPlayer"];
            RightPlayer = (Player)Objects["rightPlayer"];
            LeftPlayer.Rival = RightPlayer;
            RightPlayer.Rival = LeftPlayer;
            Tree = (Tree)Objects["tree"];
            Ball.Contacted += new EventHandler<PengContactEventArgs>(ball_Contacted);
            BackgroundColor = Color.White;
            BackgroundTexture = Content.Load<Texture2D>("textures/world");
            IsLoaded = true;
            if (Loaded != null)
                Loaded(this, new EventArgs());

            if (!gameplay)
            {
                Ball.Body.IgnoreCollisionWith(Objects["ballLeftStand"].Body);
                Ball.Body.IgnoreCollisionWith(Objects["ballRightStand"].Body);
                Ball.Body.IgnoreCollisionWith(Objects["ballLeftStand"].Body);
                Ball.Body.IgnoreCollisionWith(Objects["ballRightStand"].Body);
            }
        }

        private bool gameplay;
        GameStopReason gameStopReason = GameStopReason.None;
        private bool gameStopped = false;
        private DateTime? stopTime;
        private DateTime? startTime;

        public bool GameStopped { get { return gameStopped; } }
        public string Screenplay { get; private set; }
        public Ball Ball { get; private set; }
        public Player LeftPlayer { get; private set; }
        public Player RightPlayer { get; private set; }
        public Tree Tree { get; private set; }
        public void StopGame(GameStopReason reason = GameStopReason.None)
        {
            UnactivePlayers();
            gameStopped = true;
            stopTime = DateTime.Now;
            startTime = null;
            gameStopReason = reason;
        }

        public void StartGame()
        {
            if (gameStopReason == GameStopReason.GoalToLeft)
                ((Ball)Objects["ball"]).ResetToRight();
            else if (gameStopReason == GameStopReason.GoalToRight)
                ((Ball)Objects["ball"]).ResetToLeft();
            else
                ((Ball)Objects["ball"]).ResetToLeft();
            ((Player)Objects["leftPlayer"]).Reset();
            ((Player)Objects["rightPlayer"]).Reset();
            Objects["leftPlayer"].Body.RestoreCollisionWith(Objects["ball"].Body);
            Objects["rightPlayer"].Body.RestoreCollisionWith(Objects["ball"].Body);
            stopTime = null;
            gameStopped = false;
            startTime = DateTime.Now;
            gameStopReason = GameStopReason.None;
        }

        void UnactivePlayers()
        {
            Objects["leftPlayer"].Body.IgnoreCollisionWith(Objects["ball"].Body);
            Objects["rightPlayer"].Body.IgnoreCollisionWith(Objects["ball"].Body);
        }

        void ball_Contacted(object sender, PengContactEventArgs e)
        {
            if (!gameStopped && gameplay)
            {
                var ball = (Ball)sender;
                if (e.Contactee.Name == "footer")
                {
                    if (ball.Position.X < 2.2f)
                    {
                        rightPlayerPoints++;
                        StopGame(GameStopReason.GoalToLeft);
                    }
                    else if (ball.Position.X > 2.8f)
                    {
                        leftPlayerPoints++;
                        StopGame(GameStopReason.GoalToRight);
                    }
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (gameplay)
            {
                var kbState = Keyboard.GetState();
                if (gameStopReason == GameStopReason.GoalToLeft || gameStopReason == GameStopReason.GoalToRight)
                {
                    if (DateTime.Now - stopTime >= TimeSpan.FromSeconds(2))
                    {
                        StartGame();
                    }
                }
                if (kbState.IsKeyDown(Keys.Enter))
                {
                    DebugMode = true;
                }
                if (kbState.IsKeyDown(Keys.Escape))
                {
                    DebugMode = false;
                }
            }
            base.Update(gameTime);
        }

        private int leftPlayerPoints = 0;
        private int rightPlayerPoints = 0;

        protected override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(Content.Load<SpriteFont>("fonts/tally"), leftPlayerPoints.ToString(), new Vector2(160, 0), new Color(0.1f, 0.2f, 0.1f, 0.4f));
            spriteBatch.DrawString(Content.Load<SpriteFont>("fonts/tally"), rightPlayerPoints.ToString(), new Vector2(750, 0), new Color(0.1f, 0.2f, 0.1f, 0.4f));
        }

        private Type GetTypeByName(string typeName)
        {
            switch (typeName)
            {
                case "float":
                    return typeof(float);
                case "int":
                    return typeof(float);
                case "vector":
                    return typeof(Vector2);
                default:
                    return Type.GetType(typeName);
            }
        }


        public bool IsLoaded { get; private set; }
        public event EventHandler Loaded;
    }
}