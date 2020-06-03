/* Player.cs
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
    /// This class creates the player object the user controls throughout playing the game. It inherits from 
    /// DrawableGameComponent
    /// </summary>
    public class Player : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 dimension;
        private KeyboardState oldState;
        private Vector2 speed;
        private Vector2 stage;
        private Vector2 vertSpeed;

        private List<Rectangle> frames;


        private int frameIndex = -1;
        private int delay;
        private int delayCounter;

        private const int ROW = 1;
        private const int COLUMN = 4;

        
        public Vector2 Position { get => position; set => position = value; }
        public Vector2 Speed { get => speed; set => speed = value; }
        public Vector2 VertSpeed { get => vertSpeed; set => vertSpeed = value; }
        /// <summary>
        /// This method starts and shows the players animations
        /// </summary>
        public void start()
        {
            this.Enabled = true;
            this.Visible = true;
        }
        /// <summary>
        /// This method stops and shows the players animations
        /// </summary>
        public void stop()
        {
            this.Enabled = false;
            this.Visible = false;
        }
        public Player(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            int delay,
            Vector2 speed,
            Vector2 stage,
            Vector2 vertSpeed) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.delay = delay;
            this.speed = new Vector2(5, 0);
            this.stage = new Vector2(g.Graphics.PreferredBackBufferWidth, g.Graphics.PreferredBackBufferHeight);
            this.vertSpeed = new Vector2(0, -5);

            dimension = new Vector2(tex.Width / COLUMN, tex.Height / ROW);
            stop();
            //creates frames
            createFrames();
        }
        /// <summary>
        /// This method creates the animation for the character
        /// </summary>
        private void createFrames()
        {
            frames = new List<Rectangle>();

            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COLUMN; j++)
                {
                    int x = j * (int)dimension.X;
                    int y = i * (int)dimension.Y;
                    Rectangle r = new Rectangle(x, y,
                        (int)dimension.X, (int)dimension.Y);
                    frames.Add(r);
                }
            }
        }
        /// <summary>
        /// This method draws the player to the screen and updates animation and movement based on the  gameTime parameter
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (frameIndex >= 0)
            {
                spriteBatch.Draw(tex, position, frames[frameIndex], Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// This method updates how the player is drawn to the screen based on the gameTime parameter. This method
        /// also tracks the player movement and restricts the player movement to within the screen boundaries as well
        /// as instituting artificial gravity.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            delayCounter++;
            if (delayCounter > delay)
            {
                frameIndex++;
                if (frameIndex > ROW * COLUMN - 1)
                {
                    frameIndex = -1;
                    //stop();
                }


                delayCounter = 0;
            }
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Left))
            {
                position -= speed;
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                position += speed;
            }
            if (position.X <= 0)
            {
                position.X = 0;
            }
            if (position.X > stage.X - 50 - tex.Width)
            {
                position.X = stage.X - 50 - tex.Width;
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                position += vertSpeed;
                if (position.Y <= 5)
                {
                    position.Y = 5;
                    position -= vertSpeed;
                }
            }
            if (position.Y > stage.Y - tex.Height)
            {
                position.Y = stage.Y - tex.Height;
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                position -= vertSpeed;
            }
            if (oldState.IsKeyUp(Keys.Up))
            {
                position -= vertSpeed;
            }
            oldState = ks;
            base.Update(gameTime);

        }
        /// <summary>
        /// This method gets the position and Rectangle of the player object and returns it for collision detection
        /// </summary>
        /// <returns></returns>
        public Rectangle getBound()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width/4,196);
        }
    }
}
