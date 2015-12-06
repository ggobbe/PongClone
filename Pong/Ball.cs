using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    internal class Ball : Sprite
    {
        private Paddle _attachedToPaddle;

        public Ball(Texture2D texture, Vector2 location, Rectangle gameBoundaries)
            : base(texture, location, gameBoundaries)
        {
        }

        protected override void CheckBounds()
        {
            if (Location.Y <= 0 || Location.Y >= GameBoundaries.Height - Height)
            {
                var newVelocity = new Vector2(Velocity.X, -Velocity.Y);
                Velocity = newVelocity;
            }
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (_attachedToPaddle != null)
            {
                Location.X = _attachedToPaddle.Location.X + _attachedToPaddle.Width;
                Location.Y = _attachedToPaddle.Location.Y;

                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    var newVelocity = new Vector2(BaseVelocity, _attachedToPaddle.Velocity.Y*.75f);
                    Velocity = newVelocity;
                    _attachedToPaddle = null;
                }
            }
            else
            {
                if (BoundingBox.Intersects(gameObjects.PlayerPaddle.BoundingBox) ||
                    BoundingBox.Intersects(gameObjects.ComputerPaddle.BoundingBox))
                {
                    var random = new Random();
                    Velocity = new Vector2(-Velocity.X*(1f + random.Next(5)/100f), Velocity.Y*(1f + random.Next(5)/100f));
                }
                while (BoundingBox.Intersects(gameObjects.PlayerPaddle.BoundingBox) ||
                       BoundingBox.Intersects(gameObjects.ComputerPaddle.BoundingBox))
                {
                    base.Update(gameTime, gameObjects);
                }
            }

            base.Update(gameTime, gameObjects);
        }

        public void AttachTo(Paddle paddle)
        {
            Velocity = Vector2.Zero;
            _attachedToPaddle = paddle;
        }
    }
}