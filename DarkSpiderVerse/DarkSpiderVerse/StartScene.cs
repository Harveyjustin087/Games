/* Shared.cs
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
    /// The StartScene is the first main menu screen seen when the player starts the game and inherits from the GameScene
    /// class
    /// </summary>
    public class StartScene : GameScene
    {
        private MenuComponent menu;
        private SpriteBatch spriteBatch;
        private BackGround backGround;
        private Texture2D tex;
        private Song music;
        string[] menuItems = {"Start Game",
        "Help",
        "High Score",
        "About",
        "Quit"};

        public StartScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.SpriteBatch;

            // load the resources
            SpriteFont regularFont = g.Content.Load<SpriteFont>("Fonts/RegularFont");
            SpriteFont highlightFont = g.Content.Load<SpriteFont>("Fonts/HilightFont");

            menu = new MenuComponent(game, spriteBatch, regularFont, highlightFont, menuItems);
            backGround = new BackGround(game, spriteBatch, tex);
            music = g.Content.Load<Song>("Music/ultimate");
            MediaPlayer.Play(music);
            MediaPlayer.IsRepeating = true;
            this.Components.Add(backGround);
            this.Components.Add(menu);
            
        }

        public MenuComponent Menu { get => menu; set => menu = value; }
    }
}
