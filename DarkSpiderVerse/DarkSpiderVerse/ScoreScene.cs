/* ScoreScene.cs
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
    /// Creates and Displays  the ScoreScene when called from the main menu
    /// </summary>
    public class ScoreScene : GameScene
    {
        SpriteBatch spriteBatch;
        private Texture2D aboutTex;

        public ScoreScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.SpriteBatch;
            aboutTex = g.Content.Load<Texture2D>("Images/highScore");
        }
        /// <summary>
        /// Draws the score scene to the screen gameTime parameter determines when updated
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(aboutTex, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
