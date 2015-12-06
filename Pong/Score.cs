using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    internal class Score
    {
        private readonly SpriteFont _font;
        private readonly Rectangle _gameBoundaries;

        public Score(SpriteFont font, Rectangle gameBoundaries)
        {
            _font = font;
            _gameBoundaries = gameBoundaries;
        }

        public int PlayerScore { get; set; }
        public int ComputerScore { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            var scoreText = string.Format("{0}:{1} ", PlayerScore, ComputerScore);
            var scoreSize = _font.MeasureString(scoreText);

            var xPosition = _gameBoundaries.Width/2f - scoreSize.X/2;
            var position = new Vector2(xPosition, _gameBoundaries.Height - scoreSize.Y);

            spriteBatch.DrawString(_font, scoreText, position, Color.White);
        }
    }
}