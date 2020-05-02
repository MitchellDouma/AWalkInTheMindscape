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
    class Hearts : DrawableGameComponent
    {
        Game game;
        SpriteBatch spriteBatch;
        Texture2D heartTexture;
        Player player;
        Rectangle heartRectangle;
        SpriteFont spriteFont;

        int previousMaxHealth;

        List<Hearts> hearts = new List<Hearts>();

        List<Rectangle> heartFrames;

        const int FULLHEART = 0;
        const int HALFHEART = 1;
        const int EMPTYHEART = 2;

        const int WIDTH = 8;
        const int HEIGHT = 8;
        const float SCALE = 3f;

        const int OFFSET = 8;

        List<int> currentFrame = new List<int>();

        bool healthLoaded = false;

        public Hearts(Game game, SpriteBatch spriteBatch, Texture2D heartTexture, Player player, SpriteFont spriteFont) : base(game)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.heartTexture = heartTexture;
            this.player = player;
            this.spriteFont = spriteFont;

            heartFrames = new List<Rectangle>();
            heartFrames.Add(new Rectangle(0, 0, (int)(WIDTH), (int)(HEIGHT)));
            heartFrames.Add(new Rectangle(8, 0, (int)(WIDTH), (int)(HEIGHT)));
            heartFrames.Add(new Rectangle(0, 8, (int)(WIDTH), (int)(HEIGHT)));

            heartRectangle = new Rectangle();

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
           
                for(int i = 0; i < hearts.Count; i++)
                {
                    heartRectangle = new Rectangle((int)(1080 + (i * OFFSET * SCALE)), 3, (int)(WIDTH * SCALE), (int)(HEIGHT * SCALE));
                    spriteBatch.Draw(heartTexture, heartRectangle, heartFrames.ElementAt<Rectangle>(currentFrame[i]), Color.White);
                }
 
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if(player.MaxHealth > previousMaxHealth)
            {
                healthLoaded = false;
            }
            if (!healthLoaded)
            {
                LoadHealth();
                healthLoaded = true;
            }
            for(int i = 0; i < player.MaxHealth; i++)
            {
                if(player.CurrentHealth == player.MaxHealth - i)
                {
                    currentFrame[i] = FULLHEART;
                    break;
                }
                else
                {
                    currentFrame[i] = EMPTYHEART;
                }
            }
            previousMaxHealth = player.MaxHealth;
            base.Update(gameTime);
        }
        public void LoadHealth()
        {
                hearts.Clear();
            for (int i = 0; i < player.MaxHealth; i++)
            {               
                 hearts.Add(new Hearts(game, spriteBatch, heartTexture, player, spriteFont));
                currentFrame.Add(0);
            }
        }
    }
}
