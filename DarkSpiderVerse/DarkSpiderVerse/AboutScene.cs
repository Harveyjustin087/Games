/* AboutScene.cs
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
    /// The AboutScene creates and displays the about page when the user selects it from the main menu
    /// </summary>
    public class AboutScene : GameScene
    {
        SpriteBatch spriteBatch;
        private Texture2D aboutTex;

        public AboutScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.SpriteBatch;
            aboutTex = g.Content.Load<Texture2D>("Images/aboutimage");
        }
        /// <summary>
        /// Draws the about scene to the screen gameTime parameter determines when updated
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
