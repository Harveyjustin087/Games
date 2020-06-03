/* BackGround.cs
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
using Microsoft.Xna.Framework.Media;

namespace DarkSpiderVerse
{
    /// <summary>
    /// Background Class creates the background for the main menu of the game. Inherits from DrawableGame Component
    /// </summary>
    public class BackGround : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        public BackGround(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.SpriteBatch;
            this.tex = g.Content.Load<Texture2D>("Images/title");
        }
        /// <summary>
        /// This method Draws the background to the screen
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
