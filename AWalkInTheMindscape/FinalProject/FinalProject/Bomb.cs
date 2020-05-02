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
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Bomb : DrawableGameComponent
    {
        Game game;
        SpriteBatch spriteBatch;
        Texture2D bombTexture;
        static Rectangle bombRectangle;
        SpriteFont spriteFont;

        Vector2 position;

        const int SIZE = 16;
        const float SCALE = 3f;

        int currentFrameCount = 0;
            const int MAXFRAMELIFE = 60;

        static bool inAButton;
        static bool inBButton;
        static bool bombWait = false;
        static bool blowUp = false;

        public static Rectangle BombRectangle { get => bombRectangle; }
        public static bool BombWait { get => bombWait; }
        public static bool BlowUp { get => blowUp; }
        public static bool InAButton { get => inAButton; }
        public static bool InBButton { get => inBButton; }
        public Bomb(Game game, SpriteBatch spriteBatch, Texture2D bombTexture, SpriteFont spriteFont) : base(game)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.bombTexture = bombTexture;
            this.spriteFont = spriteFont;
            this.position.X = Player.PlayerRectangle.X;
            this.position.Y = Player.PlayerRectangle.Y;

            bombRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(SIZE * SCALE), (int)(SIZE * SCALE));
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
           // spriteBatch.DrawString(spriteFont, bombWait.ToString(), new Vector2(50), Color.AliceBlue);
            if (bombWait)
            {             
                spriteBatch.Draw(bombTexture, bombRectangle, Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            
            if (Chest.HasBomb)
            {
                inBButton = true;
            }
            if (Player.BombPlaced)
            {
                bombWait = true;
            }
            if (bombWait)
            {
                if (currentFrameCount > MAXFRAMELIFE)
                {
                    currentFrameCount = 0;
                    blowUp = true;
                    Explosion e = new Explosion(game, spriteBatch, game.Content.Load<Texture2D>("explosion"));
                    game.Components.Add(e);
                    SoundEffect soundEffect = game.Content.Load<SoundEffect>("BombExplosion");
                    soundEffect.Play(0.3f, 0f, 0f);
                    bombWait = false;
                }

                currentFrameCount++;

            }

            base.Update(gameTime);
        }
    }
}
