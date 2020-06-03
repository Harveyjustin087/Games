/* CollisionManage.cs
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
using Microsoft.Xna.Framework.Audio;
using System.Timers;

namespace DarkSpiderVerse
{
/// <summary>
/// The CollisionManager class inherits from GameComponent and handles all collision in the game between the player
/// and enemies
/// </summary>
    public class CollisionManager : GameComponent
    {
        private Player player;
        private Rhino rhino;
        private Mysterio mysterio;
        private Vulture vulture;
        private GreenGoblin goblin;
        private Carnage carnage;
        private Venom venom;
        private int hit = 0;
        public SoundEffect scream;
        private float currentTime;
        private bool isHit = false;
        private int lifeLostCounter = 0;
        private const float delay = 5; 

        public int Hit { get => hit; set => hit = value; }
        public int LifeLostCounter { get => lifeLostCounter; set => lifeLostCounter = value; }

        public CollisionManager(Game game,
            Player player,
            Rhino rhino,
            Mysterio mysterio,
            Vulture vulture,
            GreenGoblin goblin,
            Carnage carnage,
            Venom venom,
            int hit) : base(game)
        {
            this.player = player;
            this.rhino = rhino;
            this.mysterio = mysterio;
            this.goblin = goblin;
            this.vulture = vulture;
            this.carnage = carnage;
            this.venom = venom;
            this.hit = hit;
        }
        /// <summary>
        /// This method checks for collisions between the player and the various enemies in the game and adds to a hit counter
        /// and updates a boolean for removing lives from the player every ten seconds. Uses the gameTime aparameter to update based on the
        /// game loop.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            currentTime += (float)gameTime.ElapsedGameTime.Milliseconds;
            if (player.getBound().Intersects(rhino.getBound()))
            {
                hit = hit + 1;
                isHit = true;
            }
            if (player.getBound().Intersects(mysterio.getBound()))
            {
                hit = hit + 1;
                isHit = true;
            }
            if (player.getBound().Intersects(goblin.getBound()))
            {
                isHit = true;
                hit = hit + 1; 
            }
            if (player.getBound().Intersects(vulture.getBound()))
            {
                isHit = true;
                hit = hit + 1;
            }
            if (player.getBound().Intersects(carnage.getBound()))
            {
                isHit = true;
                hit = hit + 1;
            }
            if (player.getBound().Intersects(venom.getBound()))
            {
                isHit = true;
                hit = hit + 1;
            }
            if (currentTime >= 10000 && currentTime <= 10500)
            {
                if (isHit == true)
                {
                    lifeLostCounter++;
                    isHit = false;
                }
                
            }
            if (currentTime >= 20000 && currentTime <= 20500)
            {
                if (isHit == true)
                {
                    lifeLostCounter++;
                    isHit = false;
                }
            }
            if (currentTime >= 30000 && currentTime <= 30500)
            {
                if (isHit == true)
                {
                    lifeLostCounter++;
                    isHit = false;
                }
            }
            if (currentTime >= 40000 && currentTime <= 40500)
            {
                if (isHit == true)
                {
                    lifeLostCounter++;
                    isHit = false;
                }
            }
            if (currentTime >= 50000 && currentTime <= 50500)
            {
                if (isHit == true)
                {
                    lifeLostCounter++;
                    isHit = false;
                }
            }
            if (currentTime >= 60000 && currentTime <= 60500)
            {
                if (isHit == true)
                {
                    lifeLostCounter++;
                    isHit = false;
                }
            }
            if (currentTime >= 70000 && currentTime <= 70500)
            {
                if (isHit == true)
                {
                    lifeLostCounter++;
                    isHit = false;
                }
            }
            if (currentTime >= 80000 && currentTime <= 80500)
            {
                if (isHit == true)
                {
                    lifeLostCounter++;
                    isHit = false;
                }
            }
            if (currentTime >= 90000 && currentTime <= 90500)
            {
                if (isHit == true)
                {
                    lifeLostCounter++;
                    isHit = false;
                }
            }
            if (currentTime >= 100000 && currentTime <= 100500)
            {
                if (isHit == true)
                {
                    lifeLostCounter++;
                    isHit = false;
                }
            }
            if (currentTime >= 110000 && currentTime <= 110500)
            {
                if (isHit == true)
                {
                    lifeLostCounter++;
                    isHit = false;
                }
            }
            if (currentTime >= 1250000 && currentTime <= 1250500)
            {
                lifeLostCounter = 3;
            }

            base.Update(gameTime);
        }
    }
}