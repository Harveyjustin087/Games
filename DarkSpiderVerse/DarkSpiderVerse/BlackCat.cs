/* BlackCat.cs
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
using Microsoft.Xna.Framework.Audio;

namespace DarkSpiderVerse
{
    /// <summary>
    /// This class creates the Black Cat character for the game. Inherits from DrawableGameComponent
    /// </summary>
    public class BlackCat : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 dimension;
        private Vector2 speed;
        private Vector2 stage;
        private SoundEffect voice;
        private float currentTime;
        private int goCat = 0;

        private List<Rectangle> frames;

        private int frameIndex = -1;
        private int delay;
        private int delayCounter;

        private const int ROW = 1;
        private const int COLUMN = 3;


        public Vector2 Position { get => position; set => position = value; }
        /// <summary>
        /// This method displays the selected item when called
        /// </summary>
        public void start()
        {
            this.Enabled = true;
            this.Visible = true;
        }
        /// <summary>
        /// This method hides the selected item when called
        /// </summary>
        public void stop()
        {
            this.Enabled = false;
            this.Visible = false;
        }
        public BlackCat(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            int delay,
            Vector2 speed,
            Vector2 stage,
            SoundEffect voice) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.delay = delay;
            this.speed = new Vector2(5, 0);
            this.stage = new Vector2(g.Graphics.PreferredBackBufferWidth, g.Graphics.PreferredBackBufferHeight);
            this.voice = voice;

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
        /// This method draws the character to the screen based on the gameTime parameter
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
        /// This method updates the characters movement and animation based on the gameTime parameter
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
                }

                delayCounter = 0;
            }
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (goCat == 0)
            {
                if (currentTime > 9)
                {
                    position = new Vector2(-100,353);
                    position += new Vector2(4, 0);
                    goCat++;
                    voice.Play();
                }

            }
            if (goCat == 1)
            {
                if (currentTime > 60)
                {
                    position = new Vector2(-100,353);
                    position += new Vector2(4, 0);
                    goCat++;
                    voice.Play();
                }

            }
            if (goCat == 2)
            {
                if (currentTime > 100)
                {
                    position = new Vector2(-100, 353);
                    position += new Vector2(4, 0);
                    goCat++;
                    voice.Play();
                }

            }
            position += speed;

            base.Update(gameTime);
        }
    }
}