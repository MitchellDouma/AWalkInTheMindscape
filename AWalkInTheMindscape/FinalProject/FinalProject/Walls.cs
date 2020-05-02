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
using PROG2370CollisionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Walls : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D wallTexture;
        Rectangle wallRectangle;
        static Rectangle rigidBody;

        bool isOpen34;
        bool isOpen80;

        const int WIDTH = 56;
        const int HEIGHT = 30;
        const float SCALE = 3;

        public static Rectangle RigidBody { get => rigidBody; }
        public Walls(Game game, SpriteBatch spriteBatch, Texture2D wallTexture) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.wallTexture = wallTexture;

        }

        public override void Draw(GameTime gameTime)
        {
            if (!isOpen34 && Background.CurrentBackground == 34)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(wallTexture, wallRectangle, Color.White);
                spriteBatch.End();
            }
            if (!isOpen80 && Background.CurrentBackground == 80)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(wallTexture, wallRectangle, Color.White);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if(Background.CurrentBackground == 34)
            {
                wallRectangle = new Rectangle(624, 61, (int)(WIDTH * SCALE), (int)(HEIGHT * 4));
                rigidBody = new Rectangle(624, 61, (int)(WIDTH * SCALE), (int)(HEIGHT * 2));
            }
            else if(Background.CurrentBackground == 80)
            {
                wallRectangle = new Rectangle(639, 0, (int)(WIDTH * SCALE), (int)(HEIGHT * SCALE));
                rigidBody = new Rectangle(639, 0, (int)(WIDTH * SCALE), (int)(HEIGHT * 2));
            }
            else
            {
                wallRectangle = new Rectangle(0, 0,0,0);
                rigidBody = new Rectangle(0, 0, 0, 0);
            }
            if (isOpen34)
            {
                rigidBody = new Rectangle(0, 0, 0, 0);
            }
            if (isOpen80)
            {
                rigidBody = new Rectangle(0, 0, 0, 0);
            }
            Rectangle proposedPlayer = new Rectangle(wallRectangle.X,
                                                   wallRectangle.Y,
                                                   wallRectangle.Width,
                                                   wallRectangle.Height);
            //bomb expolsion
            Sides collisionSides = proposedPlayer.CheckCollisions(Explosion.ExplosionRectangle);
            if ((collisionSides & Sides.RIGHT) == Sides.RIGHT)
            {
                if (Background.CurrentBackground == 34)
                {
                    isOpen34 = true;
                }
                else if(Background.CurrentBackground == 80)
                {
                    isOpen80 = true;
                }
                            
            }

            if ((collisionSides & Sides.LEFT) == Sides.LEFT)
            {
                if (Background.CurrentBackground == 43)
                {
                    isOpen34 = true;
                }
                else if (Background.CurrentBackground == 80)
                {
                    isOpen80 = true;
                }
            }

            if ((collisionSides & Sides.TOP) == Sides.TOP)
            {
                if (Background.CurrentBackground == 43)
                {
                    isOpen34 = true;
                }
                else if (Background.CurrentBackground == 80)
                {
                    isOpen80 = true;
                }
            }

            if ((collisionSides & Sides.BOTTOM) == Sides.BOTTOM)
            {
                if (Background.CurrentBackground == 43)
                {
                    isOpen34 = true;
                }
                else if (Background.CurrentBackground == 80)
                {
                    isOpen80 = true;
                }
            }
            base.Update(gameTime);
        }
    }
}
