﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    internal abstract class Sprite
    {
        protected const float BaseVelocity = 5f + PongGame.Speed;

        protected readonly Rectangle GameBoundaries;
        protected readonly Texture2D Texture;
        public Vector2 Location;

        public Sprite(Texture2D texture, Vector2 location, Rectangle gameBoundaries)
        {
            Texture = texture;
            Location = location;
            GameBoundaries = gameBoundaries;
            Velocity = Vector2.Zero;
        }

        public Vector2 Velocity { get; protected set; }

        public int Width => Texture.Width;
        public int Height => Texture.Height;

        public Rectangle BoundingBox => new Rectangle((int) Location.X, (int) Location.Y, Width, Height);

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, Color.White);
        }

        public virtual void Update(GameTime gameTime, GameObjects gameObjects)
        {
            Location += Velocity;

            CheckBounds();
        }

        protected abstract void CheckBounds();
    }
}