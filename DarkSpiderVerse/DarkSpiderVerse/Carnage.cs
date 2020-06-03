﻿/* Carnage.cs
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
    /// This class creates the Carnage enemy for the game. Inherits from DrawableGameComponent
    /// </summary>
    public class Carnage : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 dimension;
        private Vector2 speed;
        private Vector2 stage;
        private SoundEffect voice;
        private float currentTime;
        private int goCarnage = 0;

        private List<Rectangle> frames;

        private int frameIndex = -1;
        private int delay;
        private int delayCounter;

        private const int ROW = 1;
        private const int COLUMN = 6;


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
        public Carnage(Game game,
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
        /// This method draws the enemy to the screen based on the gameTime parameter
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
        /// This method gets the position and Rectangle of the enemy object and returns it for collision detection
        /// </summary>
        /// <returns></returns>
        public Rectangle getBound()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width / 6, tex.Height);
        }
        /// <summary>
        /// This method updates the enemy movement and animation based on the gameTime parameter
        /// </summary>
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
            if (goCarnage == 0)
            {
                if (currentTime > 2)
                {
                    position = new Vector2(Shared.stage.X, Shared.stage.Y - 150);
                    position -= new Vector2(4, 0);
                    goCarnage++;
                    voice.Play();
                }

            }
            if (goCarnage == 1)
            {
                if (currentTime > 41)
                {
                    position = new Vector2(Shared.stage.X, Shared.stage.Y - 150);
                    position -= new Vector2(6, 0);
                    goCarnage++;
                    voice.Play();
                }

            }
            if (goCarnage == 2)
            {
                if (currentTime > 53)
                {
                    position = new Vector2(Shared.stage.X, Shared.stage.Y - 150);
                    position -= new Vector2(6, 0);
                    goCarnage++;
                    voice.Play();
                }

            }
            if (goCarnage == 3)
            {
                if (currentTime > 83)
                {
                    position = new Vector2(Shared.stage.X, Shared.stage.Y - 150);
                    position -= new Vector2(4, 0);
                    goCarnage++;
                    voice.Play();
                }

            }
            position -= speed;

            base.Update(gameTime);
        }
    }
}