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
    class HotButtons : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D hotButtonTexture;
        Rectangle hotButtonRectangle;

        const int WIDTH = 64;
        const int HEIGHT = 32;
        const float SCALE = 3f;

        public HotButtons(Game game, SpriteBatch spriteBatch, Texture2D hotButtonTexture) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.hotButtonTexture = hotButtonTexture;

            hotButtonRectangle = new Rectangle(1080, 30, (int)(WIDTH * SCALE), (int)(HEIGHT * SCALE));
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(hotButtonTexture, hotButtonRectangle, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
