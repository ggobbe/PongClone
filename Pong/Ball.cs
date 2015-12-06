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

            if (Location.X <= 0 || Location.X >= GameBoundaries.Width - Width)
            {
                var newVelocity = new Vector2(-Velocity.X, Velocity.Y);
                Velocity = newVelocity;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && _attachedToPaddle != null)
            {
                var newVelocity = new Vector2(5, _attachedToPaddle.Velocity.Y);
                Velocity = newVelocity;
                _attachedToPaddle = null;
            }

            if (_attachedToPaddle != null)
            {
                Location.X = _attachedToPaddle.Location.X + _attachedToPaddle.Width;
                Location.Y = _attachedToPaddle.Location.Y;
            }

            base.Update(gameTime);
        }

        public void AttachTo(Paddle paddle)
        {
            _attachedToPaddle = paddle;
        }
    }
}