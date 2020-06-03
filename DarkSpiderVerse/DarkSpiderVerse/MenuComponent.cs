/* MenuComponent.cs
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
    /// This class creates the menu components necessary for navigating the main menu. It inherits from
    /// DrawableGameComponent
    /// </summary>
    public class MenuComponent : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont regularFont, highlightFont;
        private List<string> menuItems;
        private int selectedIndex = 0;
        private Vector2 position;
        private Color regularColor = Color.Silver;
        private Color highlightColor = Color.Yellow;

        private KeyboardState oldState;


        public MenuComponent(Game game,
            SpriteBatch spriteBatch,
            SpriteFont regularFont,
            SpriteFont highlightFont,
            string[] menus) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.regularFont = regularFont;
            this.highlightFont = highlightFont;

            menuItems = menus.ToList();
            position = new Vector2(Shared.stage.X/2,Shared.stage.Y/2);
        }

        public int SelectedIndex { get => selectedIndex; set => selectedIndex = value; }
        /// <summary>
        /// This method draws the menu components to the screen based off of the gameTime parameter 
        /// and the selected index which updates based on the user's menu choices
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            Vector2 tempPos = position;
            spriteBatch.Begin();

            for (int i = 0; i < menuItems.Count; i++)
            {
                if (selectedIndex == i)
                {
                    spriteBatch.DrawString(highlightFont, menuItems[i], tempPos,
                        highlightColor);
                    tempPos.Y += highlightFont.LineSpacing;
                }
                else
                {
                    spriteBatch.DrawString(regularFont, menuItems[i], tempPos,
                        regularColor);
                    tempPos.Y += regularFont.LineSpacing;
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
        /// <summary>
        /// This method updates the menu components based off of the gameTime parameter 
        /// and the selected index which updates based on the user's menu choices
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
            {
                selectedIndex++;
                if (selectedIndex == menuItems.Count)
                {
                    selectedIndex = 0;
                }
            }
            if (ks.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
            {
                selectedIndex--;
                if (selectedIndex == -1)
                {
                    selectedIndex = menuItems.Count - 1;
                }
            }

            oldState = ks;

            base.Update(gameTime);
        }
    }
}
