/* ActionScene.cs
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
    /// The ActionScene opens the main game when the user selects it from the main menu
    /// </summary>
    public class ActionScene : GameScene
    {
        //declare necessary variables
        private SpriteBatch spriteBatch;
        private Level level;
        private Texture2D spideyRun;
        private Texture2D carnTex;
        private Texture2D gobTex;
        private Texture2D fullLife;
        private Texture2D lostLife;
        private Texture2D lastLife;
        private Texture2D venomTex;
        private Texture2D gobtex;
        private Texture2D levelTex;
        private Texture2D catTex;
        private Texture2D vultureTex;
        private Texture2D rhinoTex;
        private Texture2D mysTex;
        private SpriteFont regularFont;
        private Player player;
        private Carnage carnage;
        private Rhino rhino;
        private TimePlayed timer;
        private Mysterio mysterio;
        private GameScore score;
        private CollisionManager collision;
        private GreenGoblin goblin;
        private BlackCat blackCat;
        private Venom venom;
        private GameLife gameLife;
        private Vulture vulture;
        private Rectangle srcRect;
        private Vector2 spiderPosition;
        private Vector2 position;
        private Vector2 speed;
        private Vector2 stage;
        private Vector2 vertSpeed;
        private Vector2 rhinoPos;
        private Vector2 levelSpeed;
        private Vector2 levelPosition;
        private Vector2 lifePosition;
        private SoundEffect rhinoVoice;
        private SoundEffect goblinVoice;
        private SoundEffect blackCatTalk;
        private SoundEffect carnVoice;
        private SoundEffect weAreVenom;
        private bool isDead;
        int delay;
        
        public ActionScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.SpriteBatch;
            
            //images & fonts
            spideyRun = g.Content.Load<Texture2D>("Images/swinger");
            levelTex = g.Content.Load<Texture2D>("Images/darkuniverse");
            rhinoTex = g.Content.Load<Texture2D>("Images/rhino");
            regularFont = g.Content.Load<SpriteFont>("Fonts/RegularFont");
            mysTex = g.Content.Load<Texture2D>("Images/mysterioxx");
            catTex = g.Content.Load<Texture2D>("Images/bc");
            gobTex = g.Content.Load<Texture2D>("Images/gogobby");
            fullLife = g.Content.Load<Texture2D>("Images/fullLife");
            lostLife = g.Content.Load<Texture2D>("Images/lostLife");
            lastLife = g.Content.Load<Texture2D>("Images/spiderLives");
            vultureTex = g.Content.Load<Texture2D>("Images/vulture");
            carnTex = g.Content.Load<Texture2D>("Images/carnageStab");
            venomTex = g.Content.Load<Texture2D>("Images/wearevenom");

            //sound effects
            rhinoVoice = g.Content.Load<SoundEffect>("Music/RhinoVoice");
            goblinVoice = g.Content.Load<SoundEffect>("Music/gobbyAudio");
            blackCatTalk = g.Content.Load<SoundEffect>("Music/epiccat");
            carnVoice = g.Content.Load<SoundEffect>("Music/CarnageVoice");
            weAreVenom = g.Content.Load<SoundEffect>("Music/wearevenom");


            //vectors and rectangles
            srcRect = new Rectangle(0, 0, levelTex.Width, levelTex.Height);
            position = new Vector2(0, g.Graphics.PreferredBackBufferHeight - spideyRun.Height);
            rhinoPos = new Vector2(g.Graphics.PreferredBackBufferWidth - rhinoTex.Width, g.Graphics.PreferredBackBufferHeight - rhinoTex.Height);
            levelSpeed = new Vector2(4, 0);
            levelPosition = new Vector2(0, Shared.stage.Y - srcRect.Height);
            lifePosition = new Vector2(g.Graphics.PreferredBackBufferWidth - 500, 0);
           
            //game objects
            level = new Level(game, spriteBatch, levelTex,srcRect,levelPosition,levelSpeed);
            player = new Player(game, spriteBatch, spideyRun, position, 5,speed,stage,vertSpeed);
            rhino = new Rhino(game, spriteBatch, rhinoTex, rhinoPos, new Vector2(5, 0),rhinoVoice);
            carnage = new Carnage(game, spriteBatch,carnTex, new Vector2(-5,-1000), 5, new Vector2(5, 0), stage, carnVoice);
            venom = new Venom(game, spriteBatch, venomTex, new Vector2(g.Graphics.PreferredBackBufferWidth, g.Graphics.PreferredBackBufferHeight),5, new Vector2(5, 0), stage, weAreVenom);
            timer = new TimePlayed(game, spriteBatch, regularFont, new Vector2(0, 0));
            vulture = new Vulture(game, spriteBatch, vultureTex, new Vector2(-5, g.Graphics.PreferredBackBufferHeight), 10, speed, stage);
            mysterio = new Mysterio(game,spriteBatch,mysTex,new Vector2(g.Graphics.PreferredBackBufferWidth,g.Graphics.PreferredBackBufferHeight), new Vector2(5, 0));
            goblin = new GreenGoblin(game, spriteBatch, gobTex, new Vector2(-5, g.Graphics.PreferredBackBufferHeight), 2, speed, stage, goblinVoice);
            collision = new CollisionManager(game, player, rhino,mysterio,vulture,goblin,carnage,venom,0);
            score = new GameScore(game, spriteBatch, regularFont, new Vector2(0, 25),collision);
            gameLife = new GameLife(game, spriteBatch, lifePosition, fullLife, lostLife, lastLife,3, collision, isDead);
            blackCat = new BlackCat(game, spriteBatch, catTex,new Vector2(-5,g.Graphics.PreferredBackBufferHeight), 4, speed, stage, blackCatTalk);
            
            
  


            // compnents being added
            this.Components.Add(level);
            this.Components.Add(score);
            this.Components.Add(rhino);
            this.Components.Add(mysterio);
            this.Components.Add(timer);
            this.Components.Add(player);
            this.Components.Add(carnage);
            this.Components.Add(vulture);
            this.Components.Add(goblin);
            this.Components.Add(blackCat);
            this.Components.Add(venom);
            this.Components.Add(collision);
            this.Components.Add(gameLife);

            //animations starting
            goblin.start();
            venom.start();
            blackCat.start();
            vulture.start();
            carnage.start();
            player.start();
        }

        public GameLife GameLife { get => gameLife; set => gameLife = value; }
        public GameScore Score { get => score; set => score = value; }
    }
}
