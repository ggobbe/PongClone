﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    /// <summary>
    ///     This is the main type for your game.
    /// </summary>
    public class PongGame : Game
    {
        /// <summary>
        ///     Changes the difficulty of the game
        ///     -1 Very Hard; 0 Hard; 1 Medium; 2 Easy; 3 Very Easy
        /// </summary>
        internal const int Difficulty = 1;

        /// <summary>
        ///     Changes the game's speed
        ///     -2 Very Slow; -1 Slow; 0 Normal; 1 Fast; 2 Very Fast; 5 Extreme
        /// </summary>
        internal const int Speed = 0;

        private Ball _ball;
        private Paddle _computerPaddle;
        private GameObjects _gameObjects;
        private GraphicsDeviceManager _graphics;
        private Paddle _playerPaddle;
        private Score _score;
        private SpriteBatch _spriteBatch;

        public PongGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        ///     Allows the game to perform any initialization it needs to before starting to run.
        ///     This is where it can query for any required services and load any non-graphic
        ///     related content.  Calling base.Initialize will enumerate through any components
        ///     and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var gameBoundaries = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            var paddleTexture = Content.Load<Texture2D>("paddle");

            _playerPaddle = new Paddle(paddleTexture, Vector2.Zero, gameBoundaries, PlayerTypes.Human);

            var computerPaddleLocation = new Vector2(gameBoundaries.Width - paddleTexture.Width, 0);
            _computerPaddle = new Paddle(paddleTexture, computerPaddleLocation, gameBoundaries, PlayerTypes.Computer);

            _ball = new Ball(Content.Load<Texture2D>("ball"), Vector2.Zero, gameBoundaries);
            _ball.AttachTo(_playerPaddle);

            _score = new Score(Content.Load<SpriteFont>("fonts/OpenSans"), gameBoundaries);

            _gameObjects = new GameObjects
            {
                PlayerPaddle = _playerPaddle,
                ComputerPaddle = _computerPaddle,
                Ball = _ball,
                Score = _score
            };
        }

        /// <summary>
        ///     UnloadContent will be called once per game and is the place to unload
        ///     game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        ///     Allows the game to run logic such as updating the world,
        ///     checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _playerPaddle.Update(gameTime, _gameObjects);
            _computerPaddle.Update(gameTime, _gameObjects);
            _ball.Update(gameTime, _gameObjects);
            _score.Update(gameTime, _gameObjects);

            base.Update(gameTime);
        }

        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _playerPaddle.Draw(_spriteBatch);
            _computerPaddle.Draw(_spriteBatch);
            _score.Draw(_spriteBatch);
            _ball.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}