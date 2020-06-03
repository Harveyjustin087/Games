/* GameLife.cs
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
    /// The GameLife class inherits from DrawableGameComponent creates and tracks the lives of the player in the game
    /// </summary>
    public class GameLife : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Vector2 position;
        private Texture2D texFull;
        private Texture2D tex2;
        private Texture2D tex1;
        private int lives = 3;
        private CollisionManager collision;
        private bool isDead;
        public GameLife(Game game,
            SpriteBatch spriteBatch,
            Vector2 position,
            Texture2D texFull,
            Texture2D tex2,
            Texture2D tex1,
            int lives,
            CollisionManager collision,
            bool isDead) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.position = position;
            this.texFull = texFull;
            this.tex2 = tex2;
            this.tex1 = tex1;
            this.lives = lives;
            this.collision = collision;
            this.isDead = isDead;
        }

        public bool IsDead { get => isDead; set => isDead = value; }
        /// <summary>
        /// This method draws the image for the game lives to the screen updates them based on the gameTime parameter
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (lives == 3)
            {
                spriteBatch.Draw(texFull, position, Color.White);
            }
            else if (lives == 2)
            {
                spriteBatch.Draw(tex2, position, Color.White);
            }
            else
            {
                spriteBatch.Draw(tex1, position, Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// This method updates the game lives based on the gameTime parameter. This method counts the lives lost after
        /// a collision occurs and sets the isDead bool to true if all lives are lost.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (collision.LifeLostCounter == 1)
            {
                lives = 2;
            }
            if (collision.LifeLostCounter == 2)
            {
                lives = 1;
            }
            if (collision.LifeLostCounter == 3)
            {
                isDead = true;
            }
            base.Update(gameTime);
        }
    }
}
