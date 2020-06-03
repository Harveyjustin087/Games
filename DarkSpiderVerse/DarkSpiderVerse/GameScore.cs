/* GameScore.cs
 * Final Project
 * Dark Spiderverse Game
 * Justin Harvey : Created November/December 2019
 * PROG2370 Section 3
 * Professor: S.Ahmed
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DarkSpiderVerse
{
    /// <summary>
    /// The GameScore class tracks points in the game and writes them ot the screen. This class inherits from
    /// DrawableGameComponent
    /// </summary>
    public class GameScore : DrawableGameComponent
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Vector2 position;
        CollisionManager collision;
        float time = 0;
        int points;

        public int Points { get => points; set => points = value; }

        public GameScore(Game game,
            SpriteBatch spriteBatch,
            SpriteFont font,
            Vector2 position,
            CollisionManager collision) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.position = position;
            this.collision = collision;
        }
        /// <summary>
        /// This method updates the time in the game based on the gameTime parameter and is used to track the score in the
        /// game
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            base.Update(gameTime);
        }
        /// <summary>
        /// This method draws the score to the screen as a string updating based on the gameTime parameter and tracks
        /// by the passed collision object.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            points = ((int)time * 1000) - collision.Hit;
            spriteBatch.Begin();
            spriteBatch.DrawString(font, $"Score: {(points).ToString("#")}", position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
