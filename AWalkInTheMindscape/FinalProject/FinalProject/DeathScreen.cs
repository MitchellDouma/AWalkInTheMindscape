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
using AllInOneMono;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class DeathScreen : DrawableGameComponent
    {
        Game game;
        private SpriteBatch spriteBatch;
        private Texture2D deathTexture;
        Rectangle deathScreenSize;

        bool hide;

        const int BACKGROUNDWIDTH = 461;
        const int BACKGROUNDHEIGHT = 240;
        const int SCALE = 3;
        public DeathScreen(Game game, SpriteBatch spriteBatch, Texture2D deathTexture) : base(game)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.deathTexture = deathTexture;
            deathScreenSize = new Rectangle(0, 0, (int)(BACKGROUNDWIDTH * SCALE), (int)(BACKGROUNDHEIGHT * SCALE));

        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Escape))
            {
                hide = true;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (!hide)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(deathTexture, deathScreenSize, Color.White);
                spriteBatch.End();
            }
           

            base.Draw(gameTime);
        }
    }
}
