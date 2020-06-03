/* TimePlayed.cs
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
    /// This class tracks the time passed since the beginning of the game and writes it to the screen. It also
    /// inherits from the DrawableGameComponent.
    /// </summary>
    public class TimePlayed : DrawableGameComponent
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Vector2 position;
        float time = 0;
        public TimePlayed(Game game,
            SpriteBatch spriteBatch,
            SpriteFont font,
            Vector2 position) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.position = position;
        }
        /// <summary>
        /// This method updates the time passed in the game based on the gameTime parameter.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            base.Update(gameTime);
        }
        /// <summary>
        /// This method draws the game time to the screen based on the gameTime parameter
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font,$"Game Time: {time.ToString("#.##")}", position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
