/* Game1.cs
 * Final Project
 * Dark Spiderverse Game
 * Justin Harvey : Created November/December 2019
 * PROG2370 Section 3
 * Professor: S.Ahmed
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DarkSpiderVerse
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //decalre all scenes here
        private StartScene startScene;
        //actionScene
        private ActionScene actionScene;
        //helpScene
        private HelpScene helpScene;
        //endScene
        private EndScene endScene;
        //aboutScene
        private AboutScene aboutScene;
        //scoreScene
        private ScoreScene scoreScene;

        private bool restart = false;

        public SpriteBatch SpriteBatch { get => spriteBatch; set => spriteBatch = value; }
        public GraphicsDeviceManager Graphics { get => graphics; set => graphics = value; }
        public bool Restart { get => restart; set => restart = value; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //instantiate all scenes here
            startScene = new StartScene(this);
            this.Components.Add(startScene);
            startScene.show();

            actionScene = new ActionScene(this);
            this.Components.Add(actionScene);

            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);

            endScene = new EndScene(this,actionScene);
            this.Components.Add(endScene);

            aboutScene = new AboutScene(this);
            this.Components.Add(aboutScene);

            scoreScene = new ScoreScene(this);
            this.Components.Add(scoreScene);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            int selectedIndex = 0;
            bool isDead = false;
            KeyboardState ks = Keyboard.GetState();

            if (startScene.Enabled)
            {
                selectedIndex = startScene.Menu.SelectedIndex;
                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    actionScene.show();
                    startScene.hide();
                }
                else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    helpScene.show();
                    startScene.hide();
                }
                else if (selectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    scoreScene.show();
                    startScene.hide();
                }
                else if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    aboutScene.show();
                    startScene.hide();
                }
                else if (selectedIndex == 4 && ks.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }

            }

            if (actionScene.Enabled)
            {
                isDead = actionScene.GameLife.IsDead;
                if (ks.IsKeyDown(Keys.Escape))
                {
                    startScene.show();
                    actionScene.hide();
                }
                else if (isDead == true)
                {
                    actionScene.hide();
                    endScene.show();
                }
            }
            if (endScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    LoadContent();
                }
            }

            if (helpScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    startScene.show();
                    helpScene.hide();

                }
            }
            if (aboutScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    startScene.show();
                    aboutScene.hide();

                }
            }
            if (scoreScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    startScene.show();
                    scoreScene.hide();

                }
            }

            //other scenes here

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LawnGreen);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
