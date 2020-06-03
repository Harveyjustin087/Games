﻿/* Mysterio.cs
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
    /// This class creates the Mysterio enemy for the game. Inherits from DrawableGameComponent
    /// </summary>
    public class Mysterio : DrawableGameComponent
    {
        GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 speed;
        private Vector2 stage;
        private float currentTime;
        private int goMysterio = 0;

        public Vector2 Position { get => position; set => position = value; }

        public Mysterio(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            Vector2 speed) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;
            //this.position = new Vector2(Shared.stage.X, Shared.stage.Y - 250);
        }
        /// <summary>
        /// This method updates the enemy movement based on the gameTime parameter
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (goMysterio == 0)
            {
                if (currentTime > 15)
                {
                    position = new Vector2(Shared.stage.X, Shared.stage.Y - 250);
                    position -= new Vector2(4, 0);
                    goMysterio++;
                }
            }
            if (goMysterio == 1)
            {
                if (currentTime > 27)
                {
                    position = new Vector2(Shared.stage.X, Shared.stage.Y - 250);
                    position -= new Vector2(4, 0);
                    goMysterio++;
                }
            }
            if (goMysterio == 2)
            {
                if (currentTime > 35)
                {
                    position = new Vector2(Shared.stage.X, Shared.stage.Y - 250);
                    position -= new Vector2(4, 0);
                    goMysterio++;
                }
            }
            if (goMysterio == 3)
            {
                if (currentTime > 73)
                {
                    position = new Vector2(Shared.stage.X, Shared.stage.Y - 250);
                    position -= new Vector2(4, 0);
                    goMysterio++;
                }
            }
            position -= speed; 
            base.Update(gameTime);
        }
        /// <summary>
        /// This method gets the position and Rectangle of the enemy object and returns it for collision detection
        /// </summary>
        /// <returns></returns>
        public Rectangle getBound()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height / 2);
        }
        /// <summary>
        /// This method draws the enemy to the screen based on the gameTime parameter
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

