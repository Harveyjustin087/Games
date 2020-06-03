/* GameScene.cs
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
    /// The Game Scene is an abstract class the other scenes inherit from so they can move to the selected pages from
    /// the menu or back and forth
    /// </summary>
    public abstract class GameScene : DrawableGameComponent
    {
        private List<GameComponent> components;

        public List<GameComponent> Components { get => components; set => components = value; }

        /// <summary>
        /// This method displays the selected item when called
        /// </summary>
        public virtual void show()
        {
            this.Visible = true;
            this.Enabled = true;
        }
        /// <summary>
        /// This method hides the selected item when called
        /// </summary>
        public virtual void hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }


        public GameScene(Game game) : base(game)
        {
            components = new List<GameComponent>();
            hide();
        }
        /// <summary>
        /// This method updates and enables scenes when called based on the gameTime parameter.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent item in components)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }

            }
            base.Update(gameTime);
        }
        /// <summary>
        /// This method draws the scene called to the screen based on the gameTime parameter.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent comp = null;
            foreach (GameComponent item in components)
            {
                if (item is DrawableGameComponent)
                {
                    comp = (DrawableGameComponent)item;
                }
                if (comp.Visible)
                {
                    comp.Draw(gameTime);
                }
            }


            base.Draw(gameTime);
        }
    }
}
