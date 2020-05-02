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
    class Player : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Game game;
        Texture2D playerTexture;
        SpriteFont spriteFont;
        Bomb b;
        DeathScreen deathScreen;

        static Rectangle playerRectangle;
        Rectangle attackRectangle;
        Vector2 velocity;

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
        const int STANDINGDOWNSWORD = 18;
        const int STANDINGSIDESWORD = 19;
        const int STANDINGUPSWORD = 20;
        const int FIRSTWALKSIDESWORD = 21;
        const int WALKSIDEFRAMESSWORD = 24;
        const int FIRSTWALKDOWNSWORD = 25;
        const int WALKDOWNFRAMESSWORD = 28;
        const int FIRSTWALKUPSWORD = 29;
        const int WALKUPFRAMESSWORD = 32;
        const int DEADSTART = 33;
        const int DEADEND = 34;

        List<Rectangle> playerFrames;
        int currentFrame;

        static string direction = "";
        string facingDirection = "";

        const float SPEED = 2.3f;

        float previousUpdateX;
        float previousUpdateY;

        int currentHealth = 3;
        int maxHealth = 3;
        int previousHealth;

        const int MAXINVINCIBILITY = 300;
        int currentInvincibility;

        int currentFrameDelay = 0;
        const int MAXFRAMEDELAY = 15;

        bool isPlaying;
        int playTime;

        const float SCALE = 1.5f;

        static bool isAttacking = false;
        static bool bombPlaced = false;
        static bool inside = true;
        static bool canOpenChest = false;
        static bool canOpenGate = false;
        static bool isDead = false;
        bool isInvincible;
        bool[] gotContainer = new bool[9];

        public static bool IsDead { get => isDead; }
        public int CurrentHealth { get => currentHealth; }
        public int MaxHealth { get => maxHealth; }
        public static bool BombPlaced { get => bombPlaced; }
        public static bool IsAttacking { get => isAttacking; }
        public static bool Inside { get => inside; }
        public static bool CanOpenChest { get => canOpenChest; }
        public static bool CanOpenGate { get => canOpenGate; }
        public static string Direction { get => direction; }
        public string FacingDirection { get => facingDirection; }
        public static Rectangle PlayerRectangle { get => playerRectangle; }


        public Player(Game game, SpriteBatch spriteBatch, Texture2D playerTexture,  SpriteFont spriteFont) : base(game)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.playerTexture = playerTexture;
            this.spriteFont = spriteFont;

            const float WIDTH = 32f;
            const float HEIGHT = 38f;

            for(int i = 0; i < gotContainer.Length; i++)
            {
                gotContainer[i] = false;
            }

            //animation frames
            playerFrames = new List<Rectangle>();
            playerFrames.Add(new Rectangle(0, 0, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(32, 0, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(64, 0, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(96, 0, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(128, 0, (int)WIDTH, (int)HEIGHT - 1));
            playerFrames.Add(new Rectangle(160, 0, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(0, 38, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(32, 38, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(64, 38, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(96, 38, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(128, 38, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(160, 38, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(0, 76, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(32, 76, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(64, 76, (int)WIDTH, (int)HEIGHT ));
            playerFrames.Add(new Rectangle(96, 76, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(128, 76, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(160, 76, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(0, 114, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(32, 114, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(64, 114, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(96, 114, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(128, 114, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(160, 114, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(0, 152, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(32, 152, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(64, 152, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(96, 152, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(128, 152, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(160, 152, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(0, 184, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(32, 184, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(64, 184, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(96, 184, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(128, 184, (int)WIDTH, (int)HEIGHT));
            playerFrames.Add(new Rectangle(160, 184, (int)WIDTH, (int)HEIGHT));

            velocity = new Vector2(632, 170);
            playerRectangle = new Rectangle((int)velocity.X, (int)velocity.Y, (int)(WIDTH * SCALE), (int)(HEIGHT * SCALE));
            
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

           spriteBatch.Draw(playerTexture, playerRectangle, playerFrames.ElementAt<Rectangle>(currentFrame), Color.White, 0f, new Vector2(0), spriteDirection, 0f);
            //wireframe:
            //spriteBatch.DrawRectangle(playerRectangle, Color.Black);
            //spriteBatch.DrawString(spriteFont, currentHealth.ToString(), new Vector2(0,10), Color.Blue);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void Update()
        {
            velocity.X = 0;
            velocity.Y = 0;

            KeyboardState keyState = Keyboard.GetState();
#region userInput
            if (!isDead)
            {
                if (keyState.IsKeyDown(Keys.K))
                {
                    if (IronSword.InAButton)
                    {
                        isAttacking = true;
                        
                    }

                }
                else
                {
                    isAttacking = false;
                }
                if (keyState.IsKeyDown(Keys.J))
                {
                    if (Bomb.InBButton)
                    {
                        game.Components.Remove(b);
                        b = new Bomb(game, spriteBatch, game.Content.Load<Texture2D>("bomb"),  spriteFont);
                        game.Components.Add(b);
                        bombPlaced = true;
                    }
                }
                else
                {
                    bombPlaced = false;
                }

                if (keyState.IsKeyDown(Keys.S))
                {
                    velocity.Y = SPEED;
                    facingDirection = "down";
                }

                if (keyState.IsKeyDown(Keys.W))
                {
                    velocity.Y = -SPEED;
                    facingDirection = "up";
                }

                if (keyState.IsKeyDown(Keys.A))
                {
                    velocity.X = -SPEED;
                    facingDirection = "left";
                }
                if (keyState.IsKeyDown(Keys.D))
                {
                    velocity.X = SPEED;
                    facingDirection = "right";
                }

                #endregion

                #region collisionDetection
                Rectangle proposedPlayer = new Rectangle(playerRectangle.X + (int)velocity.X,
                                                    playerRectangle.Y + (int)velocity.Y,
                                                    playerRectangle.Width,
                                                    playerRectangle.Height);

                // collision against solid objects
                Sides collisionSides = proposedPlayer.CheckCollisions(Background.RigidBodyList);

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

                //collision on screen border
                collisionSides = proposedPlayer.CheckCollisions(Borders.RigidBodyList);
                direction = "";
                Vector2 previousPosition;
                previousPosition.X = playerRectangle.X;
                previousPosition.Y = playerRectangle.Y;
                if ((collisionSides & Sides.RIGHT) == Sides.RIGHT)
                {
                    direction = "east";
                    playerRectangle.X = 310;
                    playerRectangle.Y = (int)previousPosition.Y;

                }
                if ((collisionSides & Sides.LEFT) == Sides.LEFT)
                {
                    direction = "west";
                    playerRectangle.X = 1000;
                    playerRectangle.Y = (int)previousPosition.Y;
                }
                if ((collisionSides & Sides.TOP) == Sides.TOP)
                {
                    direction = "north";
                    playerRectangle.Y = 650;
                    playerRectangle.X = (int)previousPosition.X;
                }
                if ((collisionSides & Sides.BOTTOM) == Sides.BOTTOM)
                {
                    direction = "south";
                    playerRectangle.Y = 10;
                    playerRectangle.X = (int)previousPosition.X;
                }
                //collision on dragon
                collisionSides = proposedPlayer.CheckCollisions(Dragon.DragonRectangle);
                if ((collisionSides & Sides.RIGHT) == Sides.RIGHT)
                {
                    if (velocity.X > 0)
                    {
                        velocity.X = 0;
                    }
                    if (Dragon.IsBiting && !isInvincible)
                    {
                        currentHealth -= 1;
                    }

                }
                if ((collisionSides & Sides.LEFT) == Sides.LEFT)
                {
                    if (velocity.X < 0)
                    {
                        velocity.X = 0;
                    }
                    if (Dragon.IsBiting && !isInvincible)
                    {
                        currentHealth -= 1;
                    }
                }
                if ((collisionSides & Sides.TOP) == Sides.TOP)
                {
                    if (velocity.Y < 0)
                    {
                        velocity.Y = 0;
                    }
                    if (Dragon.IsBiting && !isInvincible)
                    {
                        currentHealth -= 1;
                    }

                }
                if ((collisionSides & Sides.BOTTOM) == Sides.BOTTOM)
                {
                    if (velocity.Y > 0)
                    {
                        velocity.Y = 0;
                    }
                    if (Dragon.IsBiting && !isInvincible)
                    {
                        currentHealth -= 1;
                    }

                }
                //collision on fire
                collisionSides = proposedPlayer.CheckCollisions(Fire.FireBall);
                if ((collisionSides & Sides.RIGHT) == Sides.RIGHT)
                {
                    if (!isInvincible)
                    {
                        currentHealth -= 1;
                    }
                    
                }
                if ((collisionSides & Sides.LEFT) == Sides.LEFT)
                {

                    if (!isInvincible)
                    {
                        currentHealth -= 1;
                    }

                }
                if ((collisionSides & Sides.TOP) == Sides.TOP)
                {

                    if (!isInvincible)
                    {
                        currentHealth -= 1;
                    }

                }
                if ((collisionSides & Sides.BOTTOM) == Sides.BOTTOM)
                {
                    if (!isInvincible)
                    {
                        currentHealth -= 1;
                    }

                }
                //collision on soldier
                for (int i = 0; i < Soldier.SoldierRectangle.Count; i++)
                {
                    if (!Soldier.IsDead[i] && Soldier.Exists)
                    {

                        collisionSides = proposedPlayer.CheckCollisions(Soldier.SoldierRectangle[i]);
                        if ((collisionSides & Sides.RIGHT) == Sides.RIGHT)
                        {
                            if (!isAttacking && !isInvincible)
                            {
                                currentHealth -= 1;
                            }

                        }
                        if ((collisionSides & Sides.LEFT) == Sides.LEFT)
                        {
                            if (!isAttacking && !isInvincible)
                            {
                                currentHealth -= 1;
                            }
                        }
                        if ((collisionSides & Sides.TOP) == Sides.TOP)
                        {
                            if (!isAttacking && !isInvincible)
                            {
                                currentHealth -= 1;
                            }
                        }
                        if ((collisionSides & Sides.BOTTOM) == Sides.BOTTOM)
                        {
                            if (!isAttacking && !isInvincible)
                            {
                                currentHealth -= 1;
                            }
                        }
                    }
                }
                //bomb expolsion
                collisionSides = proposedPlayer.CheckCollisions(Explosion.ExplosionRectangle);
                if ((collisionSides & Sides.RIGHT) == Sides.RIGHT)
                {
                    if (!isInvincible && Explosion.IsAlive)
                    {
                        currentHealth -= Explosion.Damage;
                    }
                }

                if ((collisionSides & Sides.LEFT) == Sides.LEFT)
                {
                    if (!isInvincible && Explosion.IsAlive)
                    {
                        currentHealth -= Explosion.Damage;
                    }
                }

                if ((collisionSides & Sides.TOP) == Sides.TOP)
                {
                    if (!isInvincible && Explosion.IsAlive)
                    {
                        currentHealth -= Explosion.Damage;
                    }

                }

                if ((collisionSides & Sides.BOTTOM) == Sides.BOTTOM)
                {
                    if (!isInvincible && Explosion.IsAlive)
                    {
                        currentHealth -= Explosion.Damage;
                    }

                }
                //collision on doors
                collisionSides = proposedPlayer.CheckCollisions(VilliageDoors.RigidBodyList);
                    if ((collisionSides & Sides.RIGHT) == Sides.RIGHT)
                    {
                        direction = "east";
                        if (Background.CurrentBackground == 91)
                        {
                            playerRectangle.X = 468;
                            playerRectangle.Y = 625;
                            inside = false;
                        }
                    }
                    if ((collisionSides & Sides.LEFT) == Sides.LEFT)
                    {
                        direction = "west";
                        if (Background.CurrentBackground == 2)
                        {
                            playerRectangle.X = 794;
                            playerRectangle.Y = 326;
                            inside = true;
                        }
                    }
                    //opening chests
                    collisionSides = proposedPlayer.CheckCollisions(Chest.ChestRectangle);
                    if ((collisionSides & Sides.TOP) == Sides.TOP)
                    {
                        canOpenChest = true;
                    }
                    else
                    {
                        canOpenChest = false;
                    }
                //opening gate
                collisionSides = proposedPlayer.CheckCollisions(Gate.GateRectangle);
                if ((collisionSides & Sides.TOP) == Sides.TOP)
                {
                    canOpenGate = true;
                }
                else
                {
                    canOpenGate = false;
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
                if (currentHealth <= 0)
                {
                    isDead = true;
                }
                //be invincible after being hit
                if (currentHealth < previousHealth)
                {
                    isInvincible = true;
                }
                if (isInvincible)
                {
                    currentInvincibility++;
                    if (currentInvincibility > MAXINVINCIBILITY)
                    {
                        currentInvincibility = 0;
                        isInvincible = false;
                    }
                }
                for(int i = 0; i < Chest.HasContainer.Length; i++)
                {
                    if (Chest.HasContainer[i])
                    {
                        if (!gotContainer[i])
                        {
                            maxHealth++;
                            currentHealth = maxHealth;
                            gotContainer[i] = true;
                        }
                    }
                }
                if (Soldier.GetHealth)
                {
                    if (currentHealth != maxHealth)
                    {
                        currentHealth++;
                    }
                }

                #region animation
                // anime start
                //standing no sword
                if (!Chest.HasSword)
                {
                    if (velocity.X == 0f && velocity.Y == 0f)
                    {
                        if (facingDirection == "down")
                        {
                            currentFrame = STANDINGDOWN;
                        }
                        else if (facingDirection == "up")
                        {
                            currentFrame = STANDINGUP;
                        }
                        else if (facingDirection == "left")
                        {
                            spriteDirection = SpriteEffects.None;
                        }
                        else
                        {
                            spriteDirection = SpriteEffects.FlipHorizontally;
                        }

                    }
                    //walking no sword
                    else if (velocity.X != 0)
                    {

                        if (previousUpdateX == 0f)
                        {
                            if (facingDirection == "left")
                            {
                                spriteDirection = SpriteEffects.None;
                            }
                            else if (facingDirection == "right")
                            {
                                spriteDirection = SpriteEffects.FlipHorizontally;
                            }
                            currentFrame = FIRSTWALKSIDE;
                        }
                        currentFrameDelay++;
                        if (currentFrameDelay > MAXFRAMEDELAY)
                        {
                            currentFrameDelay = 0;
                            currentFrame++;
                        }
                        if (currentFrame > WALKSIDEFRAMES)
                        {
                            currentFrame = FIRSTWALKSIDE;
                        }
                    }
                    else if (velocity.Y != 0)
                    {
                        if (facingDirection == "down")
                        {
                            if (previousUpdateY == 0f)
                            {
                                currentFrame = FIRSTWALKDOWN;
                            }
                            currentFrameDelay++;
                            if (currentFrameDelay > MAXFRAMEDELAY)
                            {
                                currentFrameDelay = 0;
                                currentFrame++;
                            }
                            if (currentFrame > WALKDOWNFRAMES)
                            {
                                currentFrame = FIRSTWALKDOWN;
                            }

                        }

                        if (facingDirection == "up")
                        {
                            if (previousUpdateY == 0f)
                            {
                                currentFrame = FIRSTWALKUP;
                            }
                            currentFrameDelay++;
                            if (currentFrameDelay > MAXFRAMEDELAY)
                            {
                                currentFrameDelay = 0;
                                currentFrame++;
                            }
                            if (currentFrame > WALKUPFRAMES)
                            {
                                currentFrame = FIRSTWALKUP;
                            }
                        }
                    }
                }
                else
                {
                    //attacking
                    if (isAttacking)
                    {
                        if (facingDirection == "left")
                        {
                            spriteDirection = SpriteEffects.None;
                            currentFrame = ATTACKSIDE;
                            //playerRectangle.Width = (int)(32 * SCALE);
                            //playerRectangle.Height = (int)(32 * SCALE);
                        }
                        else if (facingDirection == "right")
                        {
                            spriteDirection = SpriteEffects.FlipHorizontally;
                            currentFrame = ATTACKSIDE;
                            //playerRectangle.Width = (int)(32 * SCALE);
                            //playerRectangle.Height = (int)(32 * SCALE);
                        }
                        else if (facingDirection == "up")
                        {
                            currentFrame = ATTACKUP;
                            //playerRectangle.Width = (int)(22 * SCALE);
                            //playerRectangle.Height = (int)(32 * SCALE);
                        }
                        else
                        {
                            currentFrame = ATTACKDOWN;
                            //playerRectangle.Width = (int)(32 * SCALE);
                            //playerRectangle.Height = (int)(38 * SCALE);
                        }
                    }
                    //standing with sword

                    if (velocity.X == 0f && velocity.Y == 0f)
                    {
                        if (facingDirection == "down")
                        {
                            currentFrame = STANDINGDOWNSWORD;
                            //playerRectangle.Width = (int)(22 * SCALE);
                            //playerRectangle.Height = (int)(32 * SCALE);
                        }
                        else if (facingDirection == "up")
                        {
                            currentFrame = STANDINGUPSWORD;
                            //playerRectangle.Width = (int)(22 * SCALE);
                            //playerRectangle.Height = (int)(32 * SCALE);
                        }
                        else if (facingDirection == "left")
                        {
                            spriteDirection = SpriteEffects.None;
                            //playerRectangle.Width = (int)(20 * SCALE);
                            //playerRectangle.Height = (int)(32 * SCALE);
                        }
                        else
                        {
                            spriteDirection = SpriteEffects.FlipHorizontally;
                            //playerRectangle.Width = (int)(20 * SCALE);
                            //playerRectangle.Height = (int)(32 * SCALE);
                        }

                    }
                    //walking with sword
                    else if (velocity.X != 0)
                    {

                        if (previousUpdateX == 0f)
                        {
                            if (facingDirection == "left")
                            {
                                spriteDirection = SpriteEffects.None;
                            }
                            else if (facingDirection == "right")
                            {
                                spriteDirection = SpriteEffects.FlipHorizontally;
                            }
                            currentFrame = FIRSTWALKSIDESWORD;
                        }
                        currentFrameDelay++;
                        if (currentFrameDelay > MAXFRAMEDELAY)
                        {
                            currentFrameDelay = 0;
                            currentFrame++;
                        }
                        if (currentFrame > WALKSIDEFRAMESSWORD)
                        {
                            currentFrame = FIRSTWALKSIDESWORD;
                        }
                    }
                    else if (velocity.Y != 0)
                    {
                        if (facingDirection == "down")
                        {
                            if (previousUpdateY == 0f)
                            {
                                currentFrame = FIRSTWALKDOWNSWORD;
                            }
                            currentFrameDelay++;
                            if (currentFrameDelay > MAXFRAMEDELAY)
                            {
                                currentFrameDelay = 0;
                                currentFrame++;
                            }
                            if (currentFrame > WALKDOWNFRAMESSWORD)
                            {
                                currentFrame = FIRSTWALKDOWNSWORD;
                            }

                        }

                        if (facingDirection == "up")
                        {
                            if (previousUpdateY == 0f)
                            {
                                currentFrame = FIRSTWALKUPSWORD;
                            }
                            currentFrameDelay++;
                            if (currentFrameDelay > MAXFRAMEDELAY)
                            {
                                currentFrameDelay = 0;
                                currentFrame++;
                            }
                            if (currentFrame > WALKUPFRAMESSWORD)
                            {
                                currentFrame = FIRSTWALKUPSWORD;
                            }
                        }
                    }
                }


            }
            if (isDead)
            {
                currentFrame = DEADSTART;
                currentFrameDelay++;
                if (currentFrameDelay > MAXFRAMEDELAY)
                {
                    currentFrame = DEADEND;
                    currentInvincibility++;
                    if(currentInvincibility > MAXINVINCIBILITY)
                    {
                        deathScreen = new DeathScreen(game, spriteBatch, game.Content.Load<Texture2D>("deathScreen"));
                        game.Components.Add(deathScreen);
                    }
                }

            }

            // anime end
            #endregion
            #region soundEffects
            //sound effects
            SoundEffect soundEffect;
            if (isAttacking)
            {
                if (!isPlaying)
                {
                    soundEffect = game.Content.Load<SoundEffect>("WeaponSwing");
                    soundEffect.Play();
                    isPlaying = true;
                    playTime = 0;
                }
                else
                {
                    playTime += 1;
                    if(playTime > 30)
                    {
                        isPlaying = false;
 
                    }
                }
            }
#endregion 
            //notes if a key was pressed during the previous update
            previousUpdateX = velocity.X;
            previousUpdateY = velocity.Y;

            previousHealth = currentHealth;
            //change hitbox
            playerRectangle.X = playerRectangle.X + (int)velocity.X;
            playerRectangle.Y = playerRectangle.Y + (int)velocity.Y;
            //base.Update(gameTime);
        }
    }
}
