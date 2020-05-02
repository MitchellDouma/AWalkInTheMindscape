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
    class Key : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D keyTexture;
        Rectangle keyRectangle;

        const int WIDTH = 8;
        const int HEIGHT = 16;
        const float SCALE = 3f;

        public Key(Game game, SpriteBatch spriteBatch, Texture2D keyTexture) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.keyTexture = keyTexture;

            keyRectangle = new Rectangle(1100, 300, (int)(WIDTH * SCALE), (int)(HEIGHT * SCALE));
        }

        public override void Draw(GameTime gameTime)
        {
            if (Chest.HasKey)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(keyTexture, keyRectangle, Color.White);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
