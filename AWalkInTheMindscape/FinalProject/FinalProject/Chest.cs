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

namespace FinalProject
{
    class Chest : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D chestTexture;
        static Rectangle chestRectangle;
        List<Rectangle> chestFrames;
        int currentFrame;
        const int CLOSED = 0;
        const int OPEN = 1;

        int positionX = 735;
        int positionY = 135;

        const float SCALE = 3f;
        bool hasInventory = false;
        static bool hasKey = false;
        bool hasLantern;
        static bool hasBomb;
        static bool hasSword;
        static bool[] hasContainer;




        public static bool[] HasContainer { get => hasContainer; }
        public static bool HasSword { get => hasSword; }
        public static bool HasBomb { get => hasBomb; }
        public static bool HasKey { get => hasKey; }
        public static Rectangle ChestRectangle { get => chestRectangle; }
        public Chest(Game game, SpriteBatch spriteBatch, Texture2D chestTexture) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.chestTexture = chestTexture;

            //frames
            chestFrames = new List<Rectangle>();
            chestFrames.Add(new Rectangle(0, 0, 17, 13));
            chestFrames.Add(new Rectangle(0, 13, 17, 13));

            chestRectangle = new Rectangle(positionX, positionY, (int)(17 * SCALE), (int)(13 * SCALE));
            hasContainer = new bool[8];
            for (int i = 0; i < hasContainer.Length; i++)
            {
                hasContainer[i] = false;
            }
        }
        #region draw
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            switch (Background.CurrentBackground)
            {
                case 67:
                    chestRectangle = new Rectangle(880, 366, (int)(17 * SCALE), (int)(13 * SCALE));
                    spriteBatch.Draw(chestTexture, chestRectangle, chestFrames.ElementAt<Rectangle>(currentFrame), Color.White, 0f, new Vector2(0), SpriteEffects.None, 0f);
                    //wireframe:
                    //spriteBatch.DrawRectangle(chestRectangle, Color.Purple);
                    break;
                case 80:
                    chestRectangle = new Rectangle(772, 240, (int)(17 * SCALE), (int)(13 * SCALE));
                    spriteBatch.Draw(chestTexture, chestRectangle, chestFrames.ElementAt<Rectangle>(currentFrame), Color.White, 0f, new Vector2(0), SpriteEffects.None, 0f);
                    //wireframe:
                    //spriteBatch.DrawRectangle(chestRectangle, Color.Purple);
                    break;
                case 69:
                    chestRectangle = new Rectangle(839, 349, (int)(17 * SCALE), (int)(13 * SCALE));
                    spriteBatch.Draw(chestTexture, chestRectangle, chestFrames.ElementAt<Rectangle>(currentFrame), Color.White, 0f, new Vector2(0), SpriteEffects.None, 0f);
                    //wireframe:
                   // spriteBatch.DrawRectangle(chestRectangle, Color.Purple);
                    break;
                case 88:
                    chestRectangle = new Rectangle(657, 270, (int)(17 * SCALE), (int)(13 * SCALE));
                    spriteBatch.Draw(chestTexture, chestRectangle, chestFrames.ElementAt<Rectangle>(currentFrame), Color.White, 0f, new Vector2(0), SpriteEffects.None, 0f);
                    //wireframe:
                    //spriteBatch.DrawRectangle(chestRectangle, Color.Purple);
                    break;
                    //with container
                case 71:
                    chestRectangle = new Rectangle(657, 260, (int)(17 * SCALE), (int)(13 * SCALE));
                    spriteBatch.Draw(chestTexture, chestRectangle, chestFrames.ElementAt<Rectangle>(currentFrame), Color.White, 0f, new Vector2(0), SpriteEffects.None, 0f);
                    //wireframe:
                    //spriteBatch.DrawRectangle(chestRectangle, Color.Purple);
                    break;
                case 87:
                    chestRectangle = new Rectangle(657, 270, (int)(17 * SCALE), (int)(13 * SCALE));
                    spriteBatch.Draw(chestTexture, chestRectangle, chestFrames.ElementAt<Rectangle>(currentFrame), Color.White, 0f, new Vector2(0), SpriteEffects.None, 0f);
                    //wireframe:
                    //spriteBatch.DrawRectangle(chestRectangle, Color.Purple);
                    break;
                case 85:
                    chestRectangle = new Rectangle(655, 523, (int)(17 * SCALE), (int)(13 * SCALE));
                    spriteBatch.Draw(chestTexture, chestRectangle, chestFrames.ElementAt<Rectangle>(currentFrame), Color.White, 0f, new Vector2(0), SpriteEffects.None, 0f);
                    //wireframe:
                    //spriteBatch.DrawRectangle(chestRectangle, Color.Purple);
                    break;
                case 91:
                    chestRectangle = new Rectangle(735, 135, (int)(17 * SCALE), (int)(13 * SCALE));
                    spriteBatch.Draw(chestTexture, chestRectangle, chestFrames.ElementAt<Rectangle>(currentFrame), Color.White, 0f, new Vector2(0), SpriteEffects.None, 0f);
                    //wireframe:
                   // spriteBatch.DrawRectangle(chestRectangle, Color.Purple);
                    break;
                case 70:
                    chestRectangle = new Rectangle(687, 148, (int)(17 * SCALE), (int)(13 * SCALE));
                    spriteBatch.Draw(chestTexture, chestRectangle, chestFrames.ElementAt<Rectangle>(currentFrame), Color.White, 0f, new Vector2(0), SpriteEffects.None, 0f);
                    //wireframe:
                   // spriteBatch.DrawRectangle(chestRectangle, Color.Purple);
                    break;
                case 61:
                    chestRectangle = new Rectangle(706, 478, (int)(17 * SCALE), (int)(13 * SCALE));
                    spriteBatch.Draw(chestTexture, chestRectangle, chestFrames.ElementAt<Rectangle>(currentFrame), Color.White, 0f, new Vector2(0), SpriteEffects.None, 0f);
                    //wireframe:
                   // spriteBatch.DrawRectangle(chestRectangle, Color.Purple);
                    break;
                //case 89:
                //    chestRectangle = new Rectangle(522, 431, (int)(17 * SCALE), (int)(13 * SCALE));
                //    spriteBatch.Draw(chestTexture, chestRectangle, chestFrames.ElementAt<Rectangle>(currentFrame), Color.White, 0f, new Vector2(0), SpriteEffects.None, 0f);
                //    //wireframe:
                //    spriteBatch.DrawRectangle(chestRectangle, Color.Purple);
                //    break;
                case 43:
                    chestRectangle = new Rectangle(657, 260, (int)(17 * SCALE), (int)(13 * SCALE));
                    spriteBatch.Draw(chestTexture, chestRectangle, chestFrames.ElementAt<Rectangle>(currentFrame), Color.White, 0f, new Vector2(0), SpriteEffects.None, 0f);
                    //wireframe:
                    spriteBatch.DrawRectangle(chestRectangle, Color.Purple);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        #endregion
        public override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            switch (Background.CurrentBackground)
            {
                //with key
                case 67:
                    if (Player.CanOpenChest)
                    {
                        if (keyState.IsKeyDown(Keys.K))
                        {
                            currentFrame = OPEN;
                            hasKey = true;
                        }

                    }
                    if (hasKey == false)
                    {
                        currentFrame = CLOSED;
                    }
                    break;
                    //has container
                case 80:
                    if (Player.CanOpenChest)
                    {
                        if (keyState.IsKeyDown(Keys.K))
                        {
                            currentFrame = OPEN;
                            hasContainer[0] = true;
                        }

                    }
                    if (hasContainer[0] == false)
                    {
                        currentFrame = CLOSED;
                    }
                    break;
                    //has container
                case 69:
                    if (Player.CanOpenChest)
                    {
                        if (keyState.IsKeyDown(Keys.K))
                        {
                            currentFrame = OPEN;
                            hasContainer[1] = true;
                        }

                    }
                    if (hasContainer[1] == false)
                    {
                        currentFrame = CLOSED;
                    }
                    break;
                    //has container
                case 88:
                    if (Player.CanOpenChest)
                    {
                        if (keyState.IsKeyDown(Keys.K))
                        {
                            currentFrame = OPEN;
                            hasContainer[2] = true;
                        }

                    }
                    if (hasContainer[2] == false)
                    {
                        currentFrame = CLOSED;
                    }
                    break;
                    //with container
                case 71:
                    if (Player.CanOpenChest)
                    {
                        if (keyState.IsKeyDown(Keys.K))
                        {
                            currentFrame = OPEN;
                            hasContainer[3] = true;
                        }

                    }
                    if (hasContainer[3] == false)
                    {
                        currentFrame = CLOSED;
                    }
                    break;
                    //hascontainer
                case 87:
                    if (Player.CanOpenChest)
                    {
                        if (keyState.IsKeyDown(Keys.K))
                        {
                            currentFrame = OPEN;
                            hasContainer[4] = true;
                        }

                    }
                    if (hasContainer[4] == false)
                    {
                        currentFrame = CLOSED;
                    }
                    break;
                    //hasContainer
                case 85:
                    if (Player.CanOpenChest)
                    {
                        if (keyState.IsKeyDown(Keys.K))
                        {
                            currentFrame = OPEN;
                            hasContainer[5] = true;
                        }

                    }
                    if (hasContainer[5] == false)
                    {
                        currentFrame = CLOSED;
                    }
                    break;
                    //with sword
                case 91:
                    if (Player.CanOpenChest)
                    {
                        if (keyState.IsKeyDown(Keys.K))
                        {
                            currentFrame = OPEN;
                            hasSword = true;
                        }

                    }
                    if (hasSword == false)
                    {
                        currentFrame = CLOSED;
                    }
                    break;
                    //with heart container
                case 70:
                    if (Player.CanOpenChest)
                    {
                        if (keyState.IsKeyDown(Keys.K))
                        {
                            currentFrame = OPEN;
                            hasContainer[6] = true;
                        }

                    }
                    if (hasContainer[6] == false)
                    {
                        currentFrame = CLOSED;
                    }
                    break;
                    //with bomb
                case 61:
                    if (Player.CanOpenChest)
                    {
                        if (keyState.IsKeyDown(Keys.K))
                        {
                            currentFrame = OPEN;
                            hasBomb = true;
                        }

                    }
                    if (hasBomb == false)
                    {
                        currentFrame = CLOSED;
                    }
                    break;
                //case 89:
                //    if (Player.CanOpenChest)
                //    {
                //        if (keyState.IsKeyDown(Keys.K))
                //        {
                //            currentFrame = OPEN;
                //            hasTopaz = true;
                //        }

                //    }
                //    if (hasTopaz == false)
                //    {
                //        currentFrame = CLOSED;
                //    }
                //    break;
                //hasContainer
                case 43:
                    if (Player.CanOpenChest)
                    {
                        if (keyState.IsKeyDown(Keys.K))
                        {
                            currentFrame = OPEN;
                            hasContainer[7] = true;
                        }

                    }
                    if (hasContainer[7] == false)
                    {
                        currentFrame = CLOSED;
                    }
                    break;              
            }


            base.Update(gameTime);
        }
    }
}
