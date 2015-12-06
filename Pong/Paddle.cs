using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    internal class Paddle : Sprite
    {
        public Paddle(Texture2D texture, Vector2 location, Rectangle gameBoundaries)
            : base(texture, location, gameBoundaries)
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                Velocity = new Vector2(0, -5);

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                Velocity = new Vector2(0, 5);

            base.Update(gameTime);
        }

        protected override void CheckBounds()
        {
            Location.Y = MathHelper.Clamp(Location.Y, 0, GameBoundaries.Height - Texture.Height);
        }
    }
}