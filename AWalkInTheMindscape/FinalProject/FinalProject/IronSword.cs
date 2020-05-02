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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using C3.XNA;

namespace FinalProject
{
    class IronSword : DrawableGameComponent
    {
        Game game;
        SpriteBatch spriteBatch;
        Texture2D swordTexture;
        SpriteEffects spriteEffect;

        static Rectangle swordRectangle;
        Rectangle bombRectangle;
        List<Rectangle> swordFrames;
        int currentFrame;

        const int POSITIONX = 1120;
        const int POSITIONY = 55;

        const int DOWN = 0;
        const int UP = 1;
        const int SIDE = 2;
        const int ATTACK = 3;

        static int attackDamage = 1;

        const int WIDTH = 6;
        const int HEIGHT = 19;
        const int SIZE = 16;
        const float SCALE = 3f;

        static bool inAButton;
        static bool inBButton;

        public static bool InAButton { get => inAButton; }
        public static bool InBButton { get => inBButton; }
        public static int AttackDamage { get => attackDamage; }
        public static Rectangle SwordRectangle { get => swordRectangle; }

        public IronSword(Game game, SpriteBatch spriteBatch, Texture2D swordTexture) : base(game)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.swordTexture = swordTexture;

            //frames
            swordFrames = new List<Rectangle>();
            swordFrames.Add(new Rectangle(0, 0, 6, 19));
            swordFrames.Add(new Rectangle(15, 0, 6, 19));
            swordFrames.Add(new Rectangle(0, 19, 10, 15));
            swordFrames.Add(new Rectangle(15, 19, 15, 19));

            swordRectangle = new Rectangle(POSITIONX, POSITIONY, (int)(WIDTH * SCALE), (int)(HEIGHT * SCALE));
            bombRectangle = new Rectangle(POSITIONX, POSITIONY, (int)(WIDTH * SCALE), (int)(HEIGHT * SCALE));
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (inAButton)
            {
                swordRectangle = new Rectangle(POSITIONX, POSITIONY, (int)(WIDTH * SCALE), (int)(HEIGHT * SCALE));
                spriteBatch.Draw(swordTexture, swordRectangle, swordFrames.ElementAt<Rectangle>(currentFrame), Color.White);              
            }
            if (Bomb.InBButton)
            {
                bombRectangle = new Rectangle((int)POSITIONX + (int)(22 * SCALE), (int)POSITIONY, (int)(SIZE * SCALE), (int)(SIZE * SCALE));
                spriteBatch.Draw(game.Content.Load<Texture2D>("bomb"), bombRectangle, Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            if (Chest.HasSword)
            {
                inAButton = true;
            }

            base.Update(gameTime);
        }
    }
}
