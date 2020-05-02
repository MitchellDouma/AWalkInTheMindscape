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

namespace FinalProject
{
    class Gate : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D gateTexture;
        static Rectangle gateRectangle;
        static Rectangle rigidBody;

        bool isOpen = false;

        const int WIDTH = 68;
            const int HEIGHT = 45;
        const float SCALE = 3;

        public static Rectangle GateRectangle { get => gateRectangle; }
        public static Rectangle RigidBody { get => rigidBody; }
        public Gate(Game game, SpriteBatch spriteBatch, Texture2D gateTexture) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.gateTexture = gateTexture;
            
           
        }

        public override void Draw(GameTime gameTime)
        {
            if (!isOpen && Background.CurrentBackground == 13)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(gateTexture, gateRectangle, Color.White);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            if(Background.CurrentBackground == 13)
            {
                gateRectangle = new Rectangle(587, 44, (int)(WIDTH * SCALE), (int)(HEIGHT * SCALE));
                rigidBody = new Rectangle(587, 44, (int)(WIDTH * SCALE), (int)(HEIGHT * 2));
                if (Player.CanOpenGate)
                {
                    if (keyState.IsKeyDown(Keys.K))
                    {
                        if (Chest.HasKey)
                        {
                            isOpen = true;
                        }
                    }

                }
                if (isOpen)
                {
                    rigidBody = new Rectangle(0, 0, 0, 0);
                }
            }
            else
            {
                gateRectangle = new Rectangle(0,0,0,0);
                rigidBody = new Rectangle(0,0,0,0);
            }
    

            base.Update(gameTime);
        }
    }
}
