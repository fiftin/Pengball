using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PengEngine;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Pengball.Objects
{
    public class ManualPlayer : Player
    {
        public ManualPlayer(string id, PengWorld world, PlayerDirection dir, Vector2 startPosition)
            : base(id, world, dir, startPosition)
        {
            UpKey = Keys.Up;
            LeftKey = Keys.Left;
            RightKey = Keys.Right;
        }

        public Keys UpKey { get; set; }
        public Keys LeftKey { get; set; }
        public Keys RightKey { get; set; }

        private void handleKeyboard()
        {
            var kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(UpKey))
            {
                Jump();
            }

            if (kbState.IsKeyDown(LeftKey))
                MoveLeft();
            else if (kbState.IsKeyDown(RightKey))
                MoveRight();
            else
                NoMove();
        }

        public override void OnUpdate(Microsoft.Xna.Framework.GameTime gameTime)
        {
            handleKeyboard();

            base.OnUpdate(gameTime);
        }


    }
}
