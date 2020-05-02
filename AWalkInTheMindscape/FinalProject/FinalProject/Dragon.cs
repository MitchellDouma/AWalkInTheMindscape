/*
 * Program ID: A Walk in the Mindscape
 * 
 * Purpose: A zelda clone where the player collects items
 * and fights enemies in an open world
 * 
 * Revision History:
 * written by Mitchell Douma on December 2018
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using C3.XNA;
using PROG2370CollisionLibrary;
using AllInOneMono;
using Microsoft.Xna.Framework.Audio;

namespace FinalProject
{
    class Dragon : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D dragonTexture;
        static Rectangle dragonRectangle;
        SpriteFont spriteFont;
        Game1 game;
        Vector2 position = new Vector2(600, 345);

        DeathScreen winScene;
        

        const int WAKEUPSTART = 0;
        const int WAKEUPFRAMES = 11;
        const int AWAKE = 12;
        const int BLINKSTART = 13;
        const int BLINKFRAMES = 22;
        const int BITE = 23;
        const int BREATHEIN = 24;
        const int BREATHEOUT = 25;
        const int DYING = 26;

        int currentFrame = WAKEUPSTART;

        int currentFrameDelay = 0;
        const int MAXFRAMEDELAY = 15;

        const int WIDTH = 32;
        const int HEIGHT = 18;
        const int SCALE = 6;

        bool isHit;
        bool isPlaying;
        int playTime;

        int health;
        int defence = 6;

        bool isDead = false;
        bool isAwake = false;
        static bool isBiting = false;
        static bool isBreathing = false;

        static public bool IsBreathing { get => isBreathing; }
        static public bool IsBiting { get => isBiting; }
        public static Rectangle DragonRectangle { get => dragonRectangle; }
        List<Rectangle> dragonFrames;
        public Dragon(Game game, SpriteBatch spriteBatch, Texture2D dragonTexture, SpriteFont spriteFont) : base(game)
        {
            this.game = game as Game1;
            this.spriteBatch = spriteBatch;
            this.dragonTexture = dragonTexture;
            this.spriteFont = spriteFont;

            //frames
            dragonFrames = new List<Rectangle>();
            dragonFrames.Add(new Rectangle(0, 0, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(32, 0, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(64, 0, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(96, 0, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(0, 18, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(32, 18, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(64, 18, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(96, 18, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(0, 36, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(32, 36, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(64, 36, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(96, 36, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(0, 36, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(32, 54, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(64, 44, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(96, 54, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(0, 72, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(32, 72, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(64, 72, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(96, 72, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(0, 90, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(32, 90, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(64, 90, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(96, 90, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(0, 108, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(32, 108, (int)WIDTH, (int)HEIGHT));
            dragonFrames.Add(new Rectangle(64, 108, (int)WIDTH, (int)HEIGHT));



            health = 30;

        }

        public override void Draw(GameTime gameTime)
        {
            if (Background.CurrentBackground == 90)
            {
                dragonRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(WIDTH * SCALE), (int)(HEIGHT * SCALE));
                spriteBatch.Begin();
                spriteBatch.Draw(dragonTexture, dragonRectangle, dragonFrames.ElementAt<Rectangle>(currentFrame), Color.White, 0f, new Vector2(0), SpriteEffects.None, 0f);
                //wireframe:
               // spriteBatch.DrawRectangle(dragonRectangle, Color.Pink);
                //spriteBatch.DrawString(spriteFont, health.ToString(), new Vector2(50), Color.Blue);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }

        public void Update()
        {
            Random attackProbability = new Random();
            int attack = attackProbability.Next(180);
            if (Background.CurrentBackground == 90)
            {
                
                Rectangle proposedDragon = new Rectangle(dragonRectangle.X,
                                                   dragonRectangle.Y,
                                                   dragonRectangle.Width,
                                                   dragonRectangle.Height);
                // collision against sword
                //bomb expolsion
                Sides collisionSides = proposedDragon.CheckCollisions(Explosion.ExplosionRectangle);
                if ((collisionSides & Sides.RIGHT) == Sides.RIGHT)
                {
                    if (Explosion.IsAlive)
                    {
                        health -= Explosion.Damage;
                    }


                }

                if ((collisionSides & Sides.LEFT) == Sides.LEFT)
                {
                    if (Explosion.IsAlive)
                    {
                        health -= Explosion.Damage;
                    }
                }

                if ((collisionSides & Sides.TOP) == Sides.TOP)
                {
                    if (Explosion.IsAlive)
                    {
                        health -= Explosion.Damage;
                    }

                }

                if ((collisionSides & Sides.BOTTOM) == Sides.BOTTOM)
                {
                    if (Explosion.IsAlive)
                    {
                        health -= Explosion.Damage;
                    }

                }
                collisionSides = proposedDragon.CheckCollisions(Player.PlayerRectangle);
                if ((collisionSides & Sides.TOP) == Sides.TOP)
                {
                    if (Player.IsAttacking)
                    {
                        health -= IronSword.AttackDamage;
                        isHit = true;
                        playTime = 0;
                    }
                 
                    
                }
                else
                {
                    isHit = false;
                }
                if ((collisionSides & Sides.BOTTOM) == Sides.BOTTOM)
                {
                    if (Player.IsAttacking)
                    {
                        health -= IronSword.AttackDamage;
                        isHit = true;
                        playTime = 0;
                    }
               
                }
                else
                {
                    isHit = false;
                }
                if ((collisionSides & Sides.LEFT) == Sides.LEFT)
                {
                    if (Player.IsAttacking)
                    {
                        health -= IronSword.AttackDamage;
                        isHit = true;
                        playTime = 0;
                    }
             
                }
                else
                {
                    isHit = false;
                }
                if ((collisionSides & Sides.RIGHT) == Sides.RIGHT)
                {
                    if (Player.IsAttacking)
                    {
                        health -= IronSword.AttackDamage;
                        isHit = true;
                        playTime = 0;
                    }
                  

                }
                else
                {
                    isHit = false;
                }
                if (health <= 0)
                {
                    isDead = true;
                }
            }
            //biting
            if(isAwake &&  !isBiting  && attack == 0 && !isDead)
            {
                isBiting = true;
            }
            //breathing
            if (isAwake && !isBreathing && attack == 179 && !isDead)
            {
                isBreathing = true;
                Fire f = new Fire(game, spriteBatch, game.Content.Load<Texture2D>("FIREBALL"), new Vector2(dragonRectangle.X + 70, dragonRectangle.Y + 35), 1);
                game.Components.Add(f);

            }

            //animation start
            //waking up
            if (Background.CurrentBackground == 90)
            {
                if (!isAwake)
                {
                    currentFrameDelay++;
                    if (currentFrameDelay > MAXFRAMEDELAY)
                    {
                        currentFrameDelay = 0;
                        currentFrame++;
                        if (currentFrame > WAKEUPFRAMES)
                        {
                            currentFrame = AWAKE;
                            isAwake = true;
                        }
                    }
                }

                //biting
                if (isBiting)
                {
                    currentFrameDelay++;
                    if (currentFrameDelay > MAXFRAMEDELAY)
                    {
                        currentFrameDelay = 0;
                        currentFrame = BITE;
                        isBiting = false;
                    }

                }
                //spit hot fire
                else if (isBreathing)
                {
                    currentFrameDelay++;
                    if (currentFrameDelay > MAXFRAMEDELAY)
                    {
                        currentFrameDelay = 0;
                        currentFrame = BREATHEIN;
                        isBreathing = false;
                    }
                }
                else if (isAwake)
                {
                    currentFrame = AWAKE;
                }
                //dying
                if (isDead)
                {
                    currentFrame = DYING;
                    currentFrameDelay++;
                    if (currentFrameDelay > MAXFRAMEDELAY)
                    {
                        currentFrameDelay = 0;
                        winScene = new DeathScreen(game, spriteBatch, game.Content.Load<Texture2D>("WinScene"));
                        game.Components.Add(winScene);
                    }                    
                }
            }
            //animation end
            #region soundEffects
            //sound effects
            SoundEffect soundEffect;
            if (isHit)
            {
                if (!isPlaying)
                {
                    soundEffect = game.Content.Load<SoundEffect>("EnemyHit");
                    soundEffect.Play(0.1f, 0, 0);
                    isPlaying = true;
                    playTime = 0;
                }
                else
                {
                    playTime += 1;
                    if (playTime > 30)
                    {
                        isPlaying = false;

                    }
                }
            }
            #endregion
            //base.Update(gameTime);
        }
    }
}
