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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using C3.XNA;
using PROG2370CollisionLibrary;
using System.Linq;
using AllInOneMono;

namespace FinalProject
{
    public class Fire : DrawableGameComponent
    {
        const int SPRITEDISPLAYWIDTH = 25;
        const int SPRITEDISPLAYHEIGHT = 25;

        const int SPRITEWIDTH = 25;
        const int SPRITEHEIGHT = 25;

        const float ROTATIONANGLEDELTA = 0.5f;

        const int PERFRAMEDISTANCE = 3;
        const int MAXFRAMELIFE = 400;
        int currentFrameCount = 0;
        const int FRAMEDELAYMAXCOUNT = 2;  
        int currentFrameDelayCount = 0;          

        SpriteBatch spriteBatch;
        Texture2D fireTexture;

        int direction;

        static Rectangle fire;
        Rectangle spriteFrame;
        Rectangle hitFire;

        bool isAlive = false;

        public static Rectangle FireBall { get => fire; }
        public bool IsAlive { get => isAlive; }
        public Fire(Game game, SpriteBatch spriteBatch, Texture2D fireTexture, Vector2 startLocation, int direction) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.direction = direction;

            Game1 g = game as Game1;
            this.fireTexture = fireTexture;
            

            isAlive = true;
            fire = new Rectangle((int)startLocation.X, (int)startLocation.Y, SPRITEDISPLAYWIDTH, SPRITEDISPLAYHEIGHT);
            spriteFrame = new Rectangle(0 + 22, 0 + 22, SPRITEWIDTH, SPRITEHEIGHT);
        }

        public override void Draw(GameTime gameTime)
        {
            if (isAlive)
            {
                spriteBatch.Begin();

                spriteBatch.Draw(fireTexture, fire, spriteFrame, Color.White, 0f, new Vector2(SPRITEDISPLAYWIDTH / 2, SPRITEDISPLAYHEIGHT / 2), SpriteEffects.None, 0f);
                //wireFrame
               // spriteBatch.DrawRectangle(hitFire, Color.Yellow);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (isAlive)
            {
                if (currentFrameCount > MAXFRAMELIFE)
                {
                    isAlive = false;
                }
                    
                currentFrameCount++;

                currentFrameDelayCount++;
                if (currentFrameDelayCount > FRAMEDELAYMAXCOUNT)
                {
                    fire.Y += PERFRAMEDISTANCE;


                    hitFire.X = fire.X - SPRITEDISPLAYWIDTH / 2;
                    hitFire.Y = fire.Y - SPRITEDISPLAYHEIGHT / 2;
                    hitFire.Width = SPRITEDISPLAYWIDTH;
                    hitFire.Height = SPRITEDISPLAYHEIGHT;

                    currentFrameDelayCount = 0;
                }
            }
            else
            {
                isAlive = false;
            }
            base.Update(gameTime);
        }
    }
}
