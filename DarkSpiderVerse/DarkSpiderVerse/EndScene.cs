/* EndScene.cs
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
    /// This Class creates the EndScene showed after the game completion and inherits from the GameScene class
    /// </summary>
    public class EndScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private SpriteFont font;
        private int point;
        private ActionScene actionScene;
        public EndScene(Game game,ActionScene actionScene) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.SpriteBatch;
            tex = g.Content.Load<Texture2D>("Images/endScreen");
            font = g.Content.Load<SpriteFont>("Fonts/RegularFont");
            this.actionScene = actionScene;
        }
        /// <summary>
        /// This method Draws the endScene and a string contating the player's final score to the screen and updates based
        /// on the gameTime parameter
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            spriteBatch.DrawString(font, $"Final Score:{point}",new Vector2(0,250),Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// This method updates baed on the gameTime parameter taking the score fro mthe game and presenting it to the user
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            point = actionScene.Score.Points;
            base.Update(gameTime);
        }
    }
}
