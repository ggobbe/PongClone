using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    internal enum PlayerTypes
    {
        Human,
        Computer
    }

    internal class Paddle : Sprite
    {
        private readonly PlayerTypes _playerType;

        public Paddle(Texture2D texture, Vector2 location, Rectangle gameBoundaries, PlayerTypes playerType)
            : base(texture, location, gameBoundaries)
        {
            _playerType = playerType;
        }

        public override void Update(GameTime gameTime)
        {
            if (_playerType == PlayerTypes.Computer)
            {
            }

            if (_playerType == PlayerTypes.Human)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    Velocity = new Vector2(0, -5);

                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    Velocity = new Vector2(0, 5);
            }

            base.Update(gameTime);
        }

        protected override void CheckBounds()
        {
            Location.Y = MathHelper.Clamp(Location.Y, 0, GameBoundaries.Height - Texture.Height);
        }
    }
}