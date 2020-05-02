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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C3.XNA;
using PROG2370CollisionLibrary;
using Microsoft.Xna.Framework.Audio;

namespace FinalProject
{
    class Soldier : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        Game game;
        Texture2D soldierTexture;

        List<Soldier> soldiers = new List<Soldier>();

        static List<Rectangle> soldierRectangle;
        Vector2 velocity = new Vector2();

        SpriteEffects spriteDirection;

        const int STANDINGDOWN = 0;
        const int STANDINGSIDE = 1;
        const int STANDINGUP = 2;
        const int FIRSTWALKSIDE = 3;
        const int WALKSIDEFRAMES = 6;
        const int FIRSTWALKDOWN = 7;
        const int WALKDOWNFRAMES = 10;
        const int FIRSTWALKUP = 11;
        const int WALKUPFRAMES = 14;
        const int ATTACKSIDE = 15;
        const int ATTACKDOWN = 16;
        const int ATTACKUP = 17;
        const int DEADSTART = 18;
        const int DEADEND = 19;

        List<Rectangle> soldierFrames;
        List<int> currentFrame;

        List<int> facingDirection;

        const int DOWN = 0;
        const int UP = 1;
        const int LEFT = 2;
        const int RIGHT = 3;

        const float SPEED = 1f;

        Vector2 previousUpdate;
        int previousBackground;

        Vector2 randomPosition;

        int currentInvincibility = 0;
        const int MAXINVINCIBILITY = 30;
        List<bool> isInvincible;

        Random random = new Random();

        bool isHit = false;
        bool isPlaying = false;
        int playTime;

        List<int> soldierHealth;
        List<int> previousHealth;

        bool isAttacking;
        static bool exists = false;
        static List<bool> isDead;
        static bool getHealth;

        int currentFrameDelay = 0;
        const int MAXFRAMEDELAY = 15;

        const float WIDTH = 22f;
        const float HEIGHT = 32f;
        const float SCALE = 1.5f;

        const int SCREENCHANGEX = 691;
        const int SCREENCHANGEY = 600;

        public static bool GetHealth { get => getHealth; }
        public static List<bool> IsDead { get => isDead; }
        public static bool Exists { get => exists; }
        public List<Soldier> Soldiers { get => soldiers; }
        public static List<Rectangle> SoldierRectangle { get => soldierRectangle; }
        public Soldier(Game game, SpriteBatch spriteBatch, Texture2D soldierTexture,  List<Soldier> soldiers, SpriteFont spriteFont) : base(game)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.soldierTexture = soldierTexture;
            this.spriteFont = spriteFont;

            soldierRectangle = new List<Rectangle>();
            isDead = new List<bool>();
            soldierHealth = new List<int>();
            previousHealth = new List<int>();
            facingDirection = new List<int>();
            currentFrame = new List<int>();
            isInvincible = new List<bool>();


            random = new Random();

            velocity = new Vector2(0);

            //animation frames
            soldierFrames = new List<Rectangle>();
            soldierFrames.Add(new Rectangle(0, 0, (int)WIDTH, (int)HEIGHT));
            soldierFrames.Add(new Rectangle(32, 0, (int)WIDTH, (int)HEIGHT));
            soldierFrames.Add(new Rectangle(64, 0, (int)WIDTH, (int)HEIGHT));
            soldierFrames.Add(new Rectangle(96, 0, (int)WIDTH, (int)HEIGHT));
            soldierFrames.Add(new Rectangle(128, 0, (int)WIDTH, (int)HEIGHT));
            soldierFrames.Add(new Rectangle(160, 0, (int)WIDTH, (int)HEIGHT));
            soldierFrames.Add(new Rectangle(0, 38, (int)WIDTH, (int)HEIGHT));
            soldierFrames.Add(new Rectangle(32, 38, (int)WIDTH, (int)HEIGHT));
            soldierFrames.Add(new Rectangle(64, 38, (int)WIDTH, (int)HEIGHT));
            soldierFrames.Add(new Rectangle(96, 38, (int)WIDTH, (int)HEIGHT));
            soldierFrames.Add(new Rectangle(128, 38, (int)WIDTH, (int)HEIGHT));
            soldierFrames.Add(new Rectangle(160, 38, (int)WIDTH, (int)HEIGHT));
            soldierFrames.Add(new Rectangle(0, 76, (int)WIDTH, (int)HEIGHT));
            soldierFrames.Add(new Rectangle(32, 76, (int)WIDTH, (int)HEIGHT));
            soldierFrames.Add(new Rectangle(64, 76, (int)WIDTH, (int)HEIGHT));
            soldierFrames.Add(new Rectangle(96, 76, (int)WIDTH, (int)HEIGHT));
            soldierFrames.Add(new Rectangle(128, 76, (int)WIDTH, (int)HEIGHT));
            soldierFrames.Add(new Rectangle(160, 76, (int)WIDTH, (int)HEIGHT));

            //this.soldiers.Clear();
            //isDead.Clear();
            //soldierRectangle.Clear();
            //soldierHealth.Clear();
            //previousHealth.Clear();
            //facingDirection.Clear();
            //currentFrame.Clear();
            //isInvincible.Clear();

            foreach(Soldier soldier in soldiers)
            {
                this.soldiers.Add(soldier);
                int randomPositionX = random.Next(600, 800);
                int randomPositionY = random.Next(300, 400);
                soldierRectangle.Add(new Rectangle(randomPositionX, randomPositionY, (int)(WIDTH * SCALE), (int)(HEIGHT * SCALE)));
                isDead.Add(false);
                soldierHealth.Add(3);
                previousHealth.Add(3);
                facingDirection.Add(-1);
                currentFrame.Add(STANDINGDOWN);
                isInvincible.Add(false);
                
            }
        }

        public override void Draw(GameTime gameTime)
        {
            
            //spriteBatch.DrawString(spriteFont, soldiers.Count.ToString(), new Vector2(50, 50 ), Color.Aqua);
            for (int i = 0; i < soldiers.Count; i++)
            {
                if (exists && !isDead[i])
                {
                    spriteBatch.Begin();

                   // spriteBatch.DrawString(spriteFont, soldiers.Count.ToString(), new Vector2(40, 40 + 40 * i ), Color.AliceBlue);


                    spriteBatch.Draw(soldierTexture, soldierRectangle[i], soldierFrames.ElementAt<Rectangle>(currentFrame[i]), Color.White, 0f, new Vector2(0), spriteDirection, 0f);
                        //wireframe:
                       // spriteBatch.DrawRectangle(soldierRectangle[i], Color.Black);

                    spriteBatch.End();
                }

               
            }
            
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (Background.CurrentBackground == 68 || Background.CurrentBackground == 71
|| Background.CurrentBackground == 72 || Background.CurrentBackground == 73
|| Background.CurrentBackground == 74 || Background.CurrentBackground == 75
|| Background.CurrentBackground == 76 || Background.CurrentBackground == 77
|| Background.CurrentBackground == 78 || Background.CurrentBackground == 79
|| Background.CurrentBackground == 80 || Background.CurrentBackground == 81
|| Background.CurrentBackground == 82 || Background.CurrentBackground == 83
|| Background.CurrentBackground == 84 || Background.CurrentBackground == 85
|| Background.CurrentBackground == 86 || Background.CurrentBackground == 87
|| Background.CurrentBackground == 88)
            {
                exists = true;
                soldierTexture = game.Content.Load<Texture2D>("SoldierSpriteSheet");
            }
            else if (Background.CurrentBackground == 30 || Background.CurrentBackground == 19
|| Background.CurrentBackground == 29 || Background.CurrentBackground == 39
|| Background.CurrentBackground == 40 || Background.CurrentBackground == 48
|| Background.CurrentBackground == 53 || Background.CurrentBackground == 58
|| Background.CurrentBackground == 47 || Background.CurrentBackground == 52
|| Background.CurrentBackground == 57 || Background.CurrentBackground == 28
|| Background.CurrentBackground == 38 || Background.CurrentBackground == 46
|| Background.CurrentBackground == 51 || Background.CurrentBackground == 62
|| Background.CurrentBackground == 33 || Background.CurrentBackground == 42
|| Background.CurrentBackground == 50 || Background.CurrentBackground == 56
|| Background.CurrentBackground == 61 || Background.CurrentBackground == 0
|| Background.CurrentBackground == 4 || Background.CurrentBackground == 5
|| Background.CurrentBackground == 6 || Background.CurrentBackground == 7
|| Background.CurrentBackground == 31 || Background.CurrentBackground == 41
|| Background.CurrentBackground == 55 || Background.CurrentBackground == 49
|| Background.CurrentBackground == 63 || Background.CurrentBackground == 60
|| Background.CurrentBackground == 65 || Background.CurrentBackground == 64
|| Background.CurrentBackground == 67 || Background.CurrentBackground == 66
|| Background.CurrentBackground == 26 || Background.CurrentBackground == 15
|| Background.CurrentBackground == 27 || Background.CurrentBackground == 37
|| Background.CurrentBackground == 36 || Background.CurrentBackground == 45
|| Background.CurrentBackground == 13 || Background.CurrentBackground == 25
|| Background.CurrentBackground == 34 || Background.CurrentBackground == 23
|| Background.CurrentBackground == 14 || Background.CurrentBackground == 44
|| Background.CurrentBackground == 1 || Background.CurrentBackground == 17)
            {
                exists = true;
                soldierTexture = game.Content.Load<Texture2D>("OblogSpriteSheet");
            }
            else
            {
                exists = false;
            }


            for (int i = 0; i < soldiers.Count; i++)
            {

                if (exists && !isDead[i])
                {
                                
                    velocity.X = 0;
                    velocity.Y = 0;
                    #region AI
                    float elapsedTime = (float)gameTime.ElapsedGameTime.Milliseconds;
                    if (elapsedTime > 1)
                    {
                        elapsedTime = 0;
                        int changeDirection = random.Next(0, 31);
                        if (changeDirection == 30)
                        {
                            facingDirection[i] = random.Next(0, 4);
                        }
                    }
                        if (facingDirection[i] == RIGHT)
                        {
                            velocity.X = SPEED;
                        }
                        if (facingDirection[i] == LEFT)
                        {
                            velocity.X = -SPEED;
                        }
                        if (facingDirection[i] == UP)
                        {
                            velocity.Y = -SPEED;
                        }
                        if (facingDirection[i] == DOWN)
                        {
                            velocity.Y = SPEED;
                        }
                                      

                        //if (soldierRectangle[i].X > Player.PlayerRectangle.X)
                        //{
                        //    velocity.X = -SPEED;
                        //    facingDirection[i] = LEFT;
                        //}
                        //else
                        //{
                        //    velocity.X = +SPEED;
                        //    facingDirection[i] = RIGHT;

                        //}
                        //if (soldierRectangle[i].Y > Player.PlayerRectangle.Y)
                        //{
                        //    velocity.Y = -SPEED;
                        //    facingDirection[i] = UP;
                        //}
                        //else
                        //{
                        //    velocity.Y = SPEED;
                        //    facingDirection[i] = DOWN;
                        //}
                    
            
                    #endregion

                    #region collision
                    Rectangle proposedPlayer = new Rectangle(soldierRectangle[i].X + (int)velocity.X,
                                                        soldierRectangle[i].Y + (int)velocity.Y,
                                                        soldierRectangle[i].Width,
                                                        soldierRectangle[i].Height);

                        //collision against solid objects
                        Sides collisionSides = proposedPlayer.CheckCollisions(Background.RigidBodyList);

                        if ((collisionSides & Sides.RIGHT) == Sides.RIGHT)
                        {
                            if (velocity.X > 0)
                            {
                                velocity.X = 0;
                            }

                        }
                        if ((collisionSides & Sides.LEFT) == Sides.LEFT)
                        {
                            if (velocity.X < 0)
                            {
                                velocity.X = 0;
                            }
                        }
                        if ((collisionSides & Sides.TOP) == Sides.TOP)
                        {
                            if (velocity.Y < 0)
                            {
                                velocity.Y = 0;
                            }

                        }

                        if ((collisionSides & Sides.BOTTOM) == Sides.BOTTOM)
                        {
                            if (velocity.Y > 0)
                            {
                                velocity.Y = 0;
                            }
                        }

                    //collision gate
                    collisionSides = proposedPlayer.CheckCollisions(Gate.RigidBody);
                    if ((collisionSides & Sides.RIGHT) == Sides.RIGHT)
                        if (velocity.X > 0)
                            velocity.X = 0;

                    if ((collisionSides & Sides.LEFT) == Sides.LEFT)
                        if (velocity.X < 0)
                            velocity.X = 0;

                    if ((collisionSides & Sides.TOP) == Sides.TOP)
                        if (velocity.Y < 0)
                            velocity.Y = 0;

                    if ((collisionSides & Sides.BOTTOM) == Sides.BOTTOM)
                        if (velocity.Y > 0)
                            velocity.Y = 0;
                    collisionSides = proposedPlayer.CheckCollisions(Borders.RigidBodyList);

                        if ((collisionSides & Sides.RIGHT) == Sides.RIGHT)
                        {
                            if (velocity.X > 0)
                            {
                                velocity.X = 0;
                            }

                        }
                        if ((collisionSides & Sides.LEFT) == Sides.LEFT)
                        {
                            if (velocity.X < 0)
                            {
                                velocity.X = 0;
                            }
                        }
                        if ((collisionSides & Sides.TOP) == Sides.TOP)
                        {
                            if (velocity.Y < 0)
                            {
                                velocity.Y = 0;
                            }

                        }

                        if ((collisionSides & Sides.BOTTOM) == Sides.BOTTOM)
                        {
                            if (velocity.Y > 0)
                            {
                                velocity.Y = 0;
                            }

                        }
                        // collision with other soldiers
                        collisionSides = proposedPlayer.CheckCollisions(soldierRectangle);

                        if ((collisionSides & Sides.RIGHT) == Sides.RIGHT)
                        {
                            if (velocity.X > 0)
                            {
                                velocity.X = 0;
                            }

                        }
                        if ((collisionSides & Sides.LEFT) == Sides.LEFT)
                        {
                            if (velocity.X < 0)
                            {
                                velocity.X = 0;
                            }
                        }
                        if ((collisionSides & Sides.TOP) == Sides.TOP)
                        {
                            if (velocity.Y < 0)
                            {
                                velocity.Y = 0;
                            }

                        }

                        if ((collisionSides & Sides.BOTTOM) == Sides.BOTTOM)
                        {
                            if (velocity.Y > 0)
                            {
                                velocity.Y = 0;
                            }

                        }

                        //when player attacks
                        collisionSides = proposedPlayer.CheckCollisions(Player.PlayerRectangle);

                    if ((collisionSides & Sides.RIGHT) == Sides.RIGHT)
                    {
                            if (Player.IsAttacking && !isInvincible[i])
                            {
                                soldierHealth[i] -= IronSword.AttackDamage;
                            isHit = true;
                            playTime = 0;
                            }


                    }
 
                    if ((collisionSides & Sides.LEFT) == Sides.LEFT)
                    {
                        if (Player.IsAttacking && !isInvincible[i])
                        {
                                soldierHealth[i] -= IronSword.AttackDamage;
                            isHit = true;
                            playTime = 0;
                        }
                    }

                    if ((collisionSides & Sides.TOP) == Sides.TOP)
                    {
                        if (Player.IsAttacking && !isInvincible[i])
                        {
                                soldierHealth[i] -= IronSword.AttackDamage;
                            isHit = true;
                            playTime = 0;
                        }

                    }
  
                    if ((collisionSides & Sides.BOTTOM) == Sides.BOTTOM)
                    {
                        if (Player.IsAttacking && isInvincible[i])
                        {
                                soldierHealth[i] -= IronSword.AttackDamage;
                            isHit = true;
                            playTime = 0;
                        }

                    }
                    //bomb expolsion
                    collisionSides = proposedPlayer.CheckCollisions(Explosion.ExplosionRectangle);
                    if ((collisionSides & Sides.RIGHT) == Sides.RIGHT)
                    {
                        if (!isInvincible[i] && Explosion.IsAlive)
                        {
                            soldierHealth[i] -= Explosion.Damage;
                            isHit = true;
                            playTime = 0;
                        }


                    }

                    if ((collisionSides & Sides.LEFT) == Sides.LEFT)
                    {
                        if (!isInvincible[i] && Explosion.IsAlive)
                        {
                            soldierHealth[i] -= Explosion.Damage;
                            isHit = true;
                            playTime = 0;
                        }
                    }

                    if ((collisionSides & Sides.TOP) == Sides.TOP)
                    {
                        if (!isInvincible[i] && Explosion.IsAlive)
                        {
                            soldierHealth[i] -= Explosion.Damage;
                            isHit = true;
                            playTime = 0;
                        }

                    }

                    if ((collisionSides & Sides.BOTTOM) == Sides.BOTTOM)
                    {
                        if (!isInvincible[i] && Explosion.IsAlive)
                        {
                            soldierHealth[i] -= Explosion.Damage;
                            isHit = true;
                            playTime = 0;
                        }

                    }
                    collisionSides = proposedPlayer.CheckCollisions(Gate.RigidBody);
                    if ((collisionSides & Sides.RIGHT) == Sides.RIGHT)
                        if (velocity.X > 0)
                            velocity.X = 0;

                    if ((collisionSides & Sides.LEFT) == Sides.LEFT)
                        if (velocity.X < 0)
                            velocity.X = 0;

                    if ((collisionSides & Sides.TOP) == Sides.TOP)
                        if (velocity.Y < 0)
                            velocity.Y = 0;

                    if ((collisionSides & Sides.BOTTOM) == Sides.BOTTOM)
                        if (velocity.Y > 0)
                            velocity.Y = 0;
                    collisionSides = proposedPlayer.CheckCollisions(Walls.RigidBody);
                    if ((collisionSides & Sides.RIGHT) == Sides.RIGHT)
                        if (velocity.X > 0)
                            velocity.X = 0;

                    if ((collisionSides & Sides.LEFT) == Sides.LEFT)
                        if (velocity.X < 0)
                            velocity.X = 0;

                    if ((collisionSides & Sides.TOP) == Sides.TOP)
                        if (velocity.Y < 0)
                            velocity.Y = 0;

                    if ((collisionSides & Sides.BOTTOM) == Sides.BOTTOM)
                        if (velocity.Y > 0)
                            velocity.Y = 0;
                    #endregion
                    //be invincible after being hit
                    if (soldierHealth[i] < previousHealth[i])
                    {
                        isInvincible[i] = true;
                        isHit = false;
                    }
                    if (isInvincible[i])
                    {
                        currentInvincibility++;
                        if (currentInvincibility > MAXINVINCIBILITY)
                        {
                            currentInvincibility = 0;
                            isInvincible[i] = false;
                        }
                    }
                    //gives player health after death
                    if (soldierHealth[i] <= 0)
                    {
                        soldiers.RemoveAt(i);
                        isDead[i] = true;
                        getHealth = true;
                    }
                    else
                    {
                        getHealth = false;
                    }

                    #region animation
                    // anime start
                    //standing

                    if (velocity.X == 0f && velocity.Y == 0f)
                        {
                            if (facingDirection[i] == DOWN)
                            {
                                currentFrame[i] = STANDINGDOWN;
                            }
                            else if (facingDirection[i] == UP)
                            {
                                currentFrame[i] = STANDINGUP;
                            }
                            else if (facingDirection[i] == LEFT)
                            {
                                spriteDirection = SpriteEffects.None;
                            }
                            else
                            {
                                spriteDirection = SpriteEffects.FlipHorizontally;
                            }

                        }
                        //walking
                        else if (velocity.X != 0)
                        {

                            if (previousUpdate.X == 0f)
                            {
                                if (facingDirection[i] == LEFT)
                                {
                                    spriteDirection = SpriteEffects.None;
                                }
                                else if (facingDirection[i] == RIGHT)
                                {
                                    spriteDirection = SpriteEffects.FlipHorizontally;
                                }
                                currentFrame[i] = FIRSTWALKSIDE;
                            }
                            currentFrameDelay++;
                            if (currentFrameDelay > MAXFRAMEDELAY)
                            {
                                currentFrameDelay = 0;
                                currentFrame[i]++;
                            }
                            if (currentFrame[i] > WALKSIDEFRAMES)
                            {
                                currentFrame[i] = FIRSTWALKSIDE;
                            }
                        }
                        else if (velocity.Y != 0)
                        {
                            if (facingDirection[i] == DOWN)
                            {
                                if (previousUpdate.Y == 0f)
                                {
                                    currentFrame[i] = FIRSTWALKDOWN;
                                }
                                currentFrameDelay++;
                                if (currentFrameDelay > MAXFRAMEDELAY)
                                {
                                    currentFrameDelay = 0;
                                    currentFrame[i]++;
                                }
                                if (currentFrame[i] > WALKDOWNFRAMES)
                                {
                                    currentFrame[i] = FIRSTWALKDOWN;
                                }

                            }

                            if (facingDirection[i] == UP)
                            {
                                if (previousUpdate.Y == 0f)
                                {
                                    currentFrame[i] = FIRSTWALKUP;
                                }
                                currentFrameDelay++;
                                if (currentFrameDelay > MAXFRAMEDELAY)
                                {
                                    currentFrameDelay = 0;
                                    currentFrame[i]++;
                                }
                                if (currentFrame[i] > WALKUPFRAMES)
                                {
                                    currentFrame[i] = FIRSTWALKUP;
                                }
                            }

                        }
                        //attacking
                        if (isAttacking)
                        {
                            if (facingDirection[i] == LEFT)
                            {
                                spriteDirection = SpriteEffects.None;
                                currentFrame[i] = ATTACKSIDE;
                            }
                            else if (facingDirection[i] == RIGHT)
                            {
                                spriteDirection = SpriteEffects.FlipHorizontally;
                                currentFrame[i] = ATTACKSIDE;
                            }
                            else if (facingDirection[i] == UP)
                            {
                                currentFrame[i] = ATTACKUP;
                            }
                            else
                            {
                                currentFrame[i] = ATTACKDOWN;
                            }
                        }
                        if (isDead[i])
                        {
                            currentFrame[i] = DEADSTART;
                            currentFrameDelay++;
                            if (currentFrameDelay > MAXFRAMEDELAY)
                            {
                                currentFrame[i] = DEADEND;
                                currentInvincibility++;
                                if (currentInvincibility > MAXINVINCIBILITY)
                                {
                                    //soldiers.RemoveAt(i);

                                //i--;
                                }

                            }
                        }
                    #endregion
                    // anime end
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
                    //notes if a key was pressed during the previous update
                    previousUpdate.X = velocity.X;
                        previousUpdate.Y = velocity.Y;
                    previousBackground = Background.CurrentBackground;

                    //change hitbox
                        soldierRectangle[i] = new Rectangle(soldierRectangle[i].X + (int)velocity.X, soldierRectangle[i].Y + (int)velocity.Y, (int)(WIDTH * SCALE), (int)(HEIGHT * SCALE));

                    previousHealth[i] = soldierHealth[i];
                }
            }

            if (!Player.IsDead)
            {
                base.Update(gameTime);
            }           
        }
    


    }
}

