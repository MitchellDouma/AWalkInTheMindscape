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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Explosion : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D explosionTexture;
        Vector2 position;
        static Rectangle explosionRectangle;

        const int damage = 5;

        const int SIZE = 32;
        const int SCALE = 3;

        static bool isAlive = false;
        int currentFrameCount;
        const int MAXFRAMELIFE = 60;

        public static bool IsAlive { get => isAlive; }
        public static int Damage { get => damage; }
        public static Rectangle ExplosionRectangle { get => explosionRectangle; }
        public Explosion(Game game, SpriteBatch spriteBatch, Texture2D explosionTexture) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.explosionTexture = explosionTexture;
            this.position.X = Bomb.BombRectangle.X;
            this.position.Y = Bomb.BombRectangle.Y;


            explosionRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(SIZE * SCALE), (int)(SIZE * SCALE));
        }

        public override void Draw(GameTime gameTime)
        {
            if (isAlive)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(explosionTexture, explosionRectangle, Color.White);
                spriteBatch.End();
            }
  
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (Bomb.BlowUp)
            {
                isAlive = true;
            }
            if (isAlive)
            {
                if (currentFrameCount > MAXFRAMELIFE)
                {
                    isAlive = false;
                }

                currentFrameCount++;

            }
            else
            {
                isAlive = false;
            }
            base.Update(gameTime);
        }
    }
}
