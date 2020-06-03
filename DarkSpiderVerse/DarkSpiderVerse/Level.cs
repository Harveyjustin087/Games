/* Level.cs
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
    /// This class creates the scrolling level background for the game and inherits from the DrawableGameComponent
    /// </summary>
    public class Level: DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Rectangle srcRect;
        private Vector2 position1, position2;
        private Vector2 speed;
        private KeyboardState oldState;
        public Level(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Rectangle srcRect,
            Vector2 position,
            Vector2 speed) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.SpriteBatch;
            this.tex = tex;
            this.srcRect = srcRect;
            this.position1 = position;
            this.position2 = new Vector2(position1.X + srcRect.Width, position1.Y);
            this.speed = speed;
        }
        /// <summary>
        /// This method draws the level background to the screen updating it based on the gameTime parameter
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position1, srcRect, Color.White);
            spriteBatch.Draw(tex, position2, srcRect, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// This method updates the level bckground based on the gameTime parameter and user key input 
        /// scrolling the background as the player moves
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            position1 -= speed;
            position2 -= speed;
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Right))
            {
                speed = new Vector2(4, 0);
                if (position1.X < -srcRect.Width)
                {
                    position1.X = position2.X + srcRect.Width;
                }
                if (position2.X < -srcRect.Width)
                {
                    position2.X = position1.X + srcRect.Width;
                }
            }
            else if(oldState.IsKeyUp(Keys.Right))
            {
                speed = new Vector2(0, 0);
            }
            oldState = ks;
            base.Update(gameTime);
        }
    }
}