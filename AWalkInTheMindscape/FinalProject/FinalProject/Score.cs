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
    class Score : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        int score = 0;
        TimeSpan timer = new TimeSpan(0, 0, 1);

        public Score(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;


        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, score.ToString(), new Vector2(300, 10), Color.Yellow);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (!Player.IsDead)
            {
                if (timer > TimeSpan.Zero)
                {
                    timer -= gameTime.ElapsedGameTime;
                    if (timer <= TimeSpan.Zero)
                    {
                        score += 10;
                        timer = new TimeSpan(0, 0, 1);
                    }
                }
            }
            base.Update(gameTime);
        }
    }
}
