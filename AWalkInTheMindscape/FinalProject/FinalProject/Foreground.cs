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
    class Foreground : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D foregroundTexture;
        SpriteFont spriteFont;
        Rectangle foreground;
        const int SCALE = 3;

        static int currentForeground = 91;
        int previousForeground;

        
        List<Rectangle> foregroundFrames;


        const int foregroundWIDTH = 461;
        const int foregroundHEIGHT = 240;

        Game game;

        int mouseX;
        int mouseY;
        public static int CurrentForeground { get => currentForeground; }
        public Foreground(Game game, SpriteBatch spriteBatch, Texture2D foregroundTexture, SpriteFont spriteFont) : base(game)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.foregroundTexture = foregroundTexture;
            this.spriteFont = spriteFont;

            //foregrounds
            foregroundFrames = new List<Rectangle>();
            foregroundFrames.Add(new Rectangle(0, 0, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(461, 0, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(922, 0, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1383, 0, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1844, 0, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2305, 0, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2766, 0, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(0, 240, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(461, 240, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(922, 240, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1383, 240, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1844, 240, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2305, 240, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2766, 240, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(0, 480, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(461, 480, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(922, 480, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1383, 480, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1844, 480, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2305, 480, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2766, 480, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(0, 720, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(461, 720, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(922, 720, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1383, 720, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1844, 720, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2305, 720, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2766, 720, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(0, 960, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(461, 960, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(922, 960, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1383, 960, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1844, 960, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2305, 960, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2766, 960, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(0, 1200, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(461, 1200, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(922, 1200, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1383, 1200, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1844, 1200, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2305, 1200, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2766, 1200, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(0, 1440, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(461, 1440, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(922, 1440, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1383, 1440, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1844, 1440, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2305, 1440, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2766, 1440, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(0, 1680, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(461, 1680, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(922, 1680, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1383, 1680, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1844, 1680, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2305, 1680, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2766, 1680, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(0, 1920, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(461, 1920, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(922, 1920, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1383, 1920, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1844, 1920, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2305, 1920, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2766, 1920, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(0, 2160, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(461, 2160, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(922, 2160, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1383, 2160, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1844, 2160, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2305, 2160, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2766, 2160, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(0, 2400, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(461, 2400, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(922, 2400, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1383, 2400, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1844, 2400, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2305, 2400, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2766, 2400, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(0, 2640, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(461, 2640, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(922, 2640, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1383, 2640, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1844, 2640, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2305, 2640, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2766, 2640, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(0, 2880, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(461, 2880, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(922, 2880, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1383, 2880, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1844, 2880, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2305, 2880, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2766, 2880, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(0, 3120, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(461, 3120, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(922, 3120, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1383, 3120, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(1844, 3120, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2305, 3120, foregroundWIDTH, foregroundHEIGHT));
            foregroundFrames.Add(new Rectangle(2766, 3120, foregroundWIDTH, foregroundHEIGHT));

            //hitboxes
            //rigidBodyList.Add(new Rectangle(350, 132, 48, 56));
            //rigidBodyList.Add(new Rectangle(532, 87, 48, 56));
            //rigidBodyList.Add(new Rectangle(846, 42, 48, 56));
            //rigidBodyList.Add(new Rectangle(443, 267, 48, 56));
            //rigidBodyList.Add(new Rectangle(801, 178, 48, 56));
            //rigidBodyList.Add(new Rectangle(892, 313, 48, 56));
            //rigidBodyList.Add(new Rectangle(487, 492, 48, 56));
            //rigidBodyList.Add(new Rectangle(397, 581, 48, 56));
            //rigidBodyList.Add(new Rectangle(757, 581, 48, 56));
            //rigidBodyList.Add(new Rectangle(982, 493, 48, 56));
            //rigidBodyList.Add(new Rectangle(1027, 87, 48, 56));

            foreground = new Rectangle(0, 0, (int)(foregroundWIDTH * SCALE), (int)(foregroundHEIGHT * SCALE));

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(foregroundTexture, foreground, foregroundFrames.ElementAt<Rectangle>(currentForeground), Color.White, 0f, new Vector2(0), SpriteEffects.None, 0f);
            // spriteBatch.DrawString(spriteFont, mouseX.ToString() + ", " + mouseY.ToString(), new Vector2(0), Color.Red);
            //spriteBatch.DrawString(spriteFont, currentForeground.ToString(), new Vector2(20), Color.Yellow);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();

            mouseX = ms.X;
            mouseY = ms.Y;


            //change foreground
            if (Player.Direction == "east")
            {
                switch (currentForeground)
                {
                    case 0:
                        currentForeground = 3;
                        break;
                    case 1:
                        currentForeground = 6;
                        break;
                    case 2:
                        currentForeground = 9;
                        break;
                    case 3:
                        currentForeground = 11;
                        break;
                    case 4:
                        currentForeground = 0;
                        break;
                    case 5:
                        currentForeground = 14;
                        break;
                    case 6:
                        currentForeground = 16;
                        break;
                    case 7:
                        currentForeground = 1;
                        break;
                    case 8:
                        currentForeground = 2;
                        break;
                    case 9:
                        currentForeground = 21;
                        break;
                    case 10:
                        currentForeground = 20;
                        break;
                    case 11:
                        currentForeground = 11;
                        break;
                    case 12:
                        currentForeground = 4;
                        break;
                    case 13:
                        currentForeground = 23;
                        break;
                    case 14:
                        currentForeground = 24;
                        break;
                    case 15:
                        currentForeground = 5;
                        break;
                    case 16:
                        currentForeground = 16;
                        break;
                    case 17:
                        currentForeground = 7;
                        break;
                    case 18:
                        currentForeground = 10;
                        break;
                    case 19:
                        currentForeground = 8;
                        break;
                    case 20:
                        currentForeground = 32;
                        break;
                    case 21:
                        currentForeground = 21;
                        break;
                    case 22:
                        currentForeground = 31;
                        break;
                    case 23:
                        currentForeground = 34;
                        break;
                    case 24:
                        currentForeground = 35;
                        break;
                    case 25:
                        currentForeground = 13;
                        break;
                    case 26:
                        currentForeground = 15;
                        break;
                    case 27:
                        currentForeground = 17;
                        break;
                    case 28:
                        currentForeground = 22;
                        break;
                    case 29:
                        currentForeground = 18;
                        break;
                    case 30:
                        currentForeground = 19;
                        break;
                    case 31:
                        currentForeground = 41;
                        break;
                    case 32:
                        currentForeground = 32;
                        break;
                    case 33:
                        currentForeground = 33;
                        break;
                    case 34:
                        currentForeground = 44;
                        break;
                    case 35:
                        currentForeground = 35;
                        break;
                    case 36:
                        currentForeground = 25;
                        break;
                    case 37:
                        currentForeground = 26;
                        break;
                    case 38:
                        currentForeground = 33;
                        break;
                    case 39:
                        currentForeground = 28;
                        break;
                    case 40:
                        currentForeground = 29;
                        break;
                    case 41:
                        currentForeground = 49;
                        break;
                    case 42:
                        currentForeground = 42;
                        break;
                    case 43:
                        currentForeground = 43;
                        break;
                    case 44:
                        currentForeground = 44;
                        break;
                    case 45:
                        currentForeground = 36;
                        break;
                    case 46:
                        currentForeground = 42;
                        break;
                    case 47:
                        currentForeground = 38;
                        break;
                    case 48:
                        currentForeground = 39;
                        break;
                    case 49:
                        currentForeground = 49;
                        break;
                    case 50:
                        currentForeground = 50;
                        break;
                    case 51:
                        currentForeground = 50;
                        break;
                    case 52:
                        currentForeground = 46;
                        break;
                    case 53:
                        currentForeground = 47;
                        break;
                    case 54:
                        currentForeground = 54;
                        break;
                    case 55:
                        currentForeground = 55;
                        break;
                    case 56:
                        currentForeground = 56;
                        break;
                    case 57:
                        currentForeground = 51;
                        break;
                    case 58:
                        currentForeground = 52;
                        break;
                    case 59:
                        currentForeground = 59;
                        break;
                    case 60:
                        currentForeground = 60;
                        break;
                    case 61:
                        currentForeground = 61;
                        break;
                    case 62:
                        currentForeground = 56;
                        break;
                    case 63:
                        currentForeground = 60;
                        break;
                    case 64:
                        currentForeground = 64;
                        break;
                    case 65:
                        currentForeground = 66;
                        break;
                    case 66:
                        currentForeground = 66;
                        break;
                    case 67:
                        currentForeground = 67;
                        break;
                    case 68:
                        currentForeground = 68;
                        break;
                    case 69:
                        currentForeground = 12;
                        break;
                    case 70:
                        currentForeground = 70;
                        break;
                    case 71:
                        currentForeground = 71;
                        break;
                    case 72:
                        currentForeground = 68;
                        break;
                    case 73:
                        currentForeground = 72;
                        break;
                    case 74:
                        currentForeground = 74;
                        break;
                    case 75:
                        currentForeground = 76;
                        break;
                    case 76:
                        currentForeground = 78;
                        break;
                    case 77:
                        currentForeground = 75;
                        break;
                    case 78:
                        currentForeground = 81;
                        break;
                    case 79:
                        currentForeground = 79;
                        break;
                    case 80:
                        currentForeground = 80;
                        break;
                    case 81:
                        currentForeground = 82;
                        break;
                    case 82:
                        currentForeground = 84;
                        break;
                    case 83:
                        currentForeground = 83;
                        break;
                    case 84:
                        currentForeground = 84;
                        break;
                    case 85:
                        currentForeground = 85;
                        break;
                    case 86:
                        currentForeground = 86;
                        break;
                    case 87:
                        currentForeground = 87;
                        break;
                    case 88:
                        currentForeground = 88;
                        break;
                    case 89:
                        currentForeground = 62;
                        break;
                    case 90:
                        currentForeground = 90;
                        break;
                    case 91:
                        currentForeground = 2;
                        break;
                }
            }
            else if (Player.Direction == "west")
            {
                switch (currentForeground)
                {
                    case 0:
                        currentForeground = 4;
                        break;
                    case 1:
                        currentForeground = 7;
                        break;
                    case 2:
                        if (Player.Inside)
                        {
                            currentForeground = 91;
                        }
                        else
                        {
                            currentForeground = 8;
                        }
                        break;
                    case 3:
                        currentForeground = 0;
                        break;
                    case 4:
                        currentForeground = 12;
                        break;
                    case 5:
                        currentForeground = 15;
                        break;
                    case 6:
                        currentForeground = 1;
                        break;
                    case 7:
                        currentForeground = 17;
                        break;
                    case 8:
                        currentForeground = 19;
                        break;
                    case 9:
                        currentForeground = 2;
                        break;
                    case 10:
                        currentForeground = 18;
                        break;
                    case 11:
                        currentForeground = 3;
                        break;
                    case 12:
                        currentForeground = 69;
                        break;
                    case 13:
                        currentForeground = 25;
                        break;
                    case 14:
                        currentForeground = 5;
                        break;
                    case 15:
                        currentForeground = 26;
                        break;
                    case 16:
                        currentForeground = 6;
                        break;
                    case 17:
                        currentForeground = 27;
                        break;
                    case 18:
                        currentForeground = 29;
                        break;
                    case 19:
                        currentForeground = 30;
                        break;
                    case 20:
                        currentForeground = 10;
                        break;
                    case 21:
                        currentForeground = 9;
                        break;
                    case 22:
                        currentForeground = 28;
                        break;
                    case 23:
                        currentForeground = 13;
                        break;
                    case 24:
                        currentForeground = 14;
                        break;
                    case 25:
                        currentForeground = 36;
                        break;
                    case 26:
                        currentForeground = 37;
                        break;
                    case 27:
                        currentForeground = 27;
                        break;
                    case 28:
                        currentForeground = 39;
                        break;
                    case 29:
                        currentForeground = 40;
                        break;
                    case 30:
                        currentForeground = 30;
                        break;
                    case 31:
                        currentForeground = 22;
                        break;
                    case 32:
                        currentForeground = 20;
                        break;
                    case 33:
                        currentForeground = 38;
                        break;
                    case 34:
                        currentForeground = 23;
                        break;
                    case 35:
                        currentForeground = 24;
                        break;
                    case 36:
                        currentForeground = 45;
                        break;
                    case 37:
                        currentForeground = 37;
                        break;
                    case 38:
                        currentForeground = 47;
                        break;
                    case 39:
                        currentForeground = 48;
                        break;
                    case 40:
                        currentForeground = 40;
                        break;
                    case 41:
                        currentForeground = 31;
                        break;
                    case 42:
                        currentForeground = 46;
                        break;
                    case 43:
                        currentForeground = 43;
                        break;
                    case 44:
                        currentForeground = 34;
                        break;
                    case 45:
                        currentForeground = 45;
                        break;
                    case 46:
                        currentForeground = 52;
                        break;
                    case 47:
                        currentForeground = 53;
                        break;
                    case 48:
                        currentForeground = 48;
                        break;
                    case 49:
                        currentForeground = 41;
                        break;
                    case 50:
                        currentForeground = 51;
                        break;
                    case 51:
                        currentForeground = 57;
                        break;
                    case 52:
                        currentForeground = 58;
                        break;
                    case 53:
                        currentForeground = 53;
                        break;
                    case 54:
                        currentForeground = 54;
                        break;
                    case 55:
                        currentForeground = 55;
                        break;
                    case 56:
                        currentForeground = 62;
                        break;
                    case 57:
                        currentForeground = 57;
                        break;
                    case 58:
                        currentForeground = 58;
                        break;
                    case 59:
                        currentForeground = 59;
                        break;
                    case 60:
                        currentForeground = 63;
                        break;
                    case 61:
                        currentForeground = 61;
                        break;
                    case 62:
                        currentForeground = 89;
                        break;
                    case 63:
                        currentForeground = 63;
                        break;
                    case 64:
                        currentForeground = 64;
                        break;
                    case 65:
                        currentForeground = 65;
                        break;
                    case 66:
                        currentForeground = 65;
                        break;
                    case 67:
                        currentForeground = 67;
                        break;
                    case 68:
                        currentForeground = 72;
                        break;
                    case 69:
                        currentForeground = 69;
                        break;
                    case 70:
                        currentForeground = 70;
                        break;
                    case 71:
                        currentForeground = 71;
                        break;
                    case 72:
                        currentForeground = 73;
                        break;
                    case 73:
                        currentForeground = 73;
                        break;
                    case 74:
                        currentForeground = 74;
                        break;
                    case 75:
                        currentForeground = 77;
                        break;
                    case 76:
                        currentForeground = 75;
                        break;
                    case 77:
                        currentForeground = 77;
                        break;
                    case 78:
                        currentForeground = 76;
                        break;
                    case 79:
                        currentForeground = 79;
                        break;
                    case 80:
                        currentForeground = 80;
                        break;
                    case 81:
                        currentForeground = 78;
                        break;
                    case 82:
                        currentForeground = 81;
                        break;
                    case 83:
                        currentForeground = 83;
                        break;
                    case 84:
                        currentForeground = 82;
                        break;
                    case 85:
                        currentForeground = 85;
                        break;
                    case 86:
                        currentForeground = 86;
                        break;
                    case 87:
                        currentForeground = 87;
                        break;
                    case 88:
                        currentForeground = 88;
                        break;
                    case 89:
                        currentForeground = 89;
                        break;
                    case 90:
                        currentForeground = 90;
                        break;
                }
            }
            if (Player.Direction == "north")
            {
                switch (currentForeground)
                {
                    case 0:
                        currentForeground = 1;
                        break;
                    case 1:
                        currentForeground = 5;
                        break;
                    case 2:
                        currentForeground = 0;
                        break;
                    case 3:
                        currentForeground = 6;
                        break;
                    case 4:
                        currentForeground = 7;
                        break;
                    case 5:
                        currentForeground = 13;
                        break;
                    case 6:
                        currentForeground = 14;
                        break;
                    case 7:
                        currentForeground = 15;
                        break;
                    case 8:
                        currentForeground = 4;
                        break;
                    case 9:
                        currentForeground = 3;
                        break;
                    case 10:
                        currentForeground = 2;
                        break;
                    case 11:
                        currentForeground = 16;
                        break;
                    case 12:
                        currentForeground = 17;
                        break;
                    case 13:
                        currentForeground = 68;
                        break;
                    case 14:
                        currentForeground = 23;
                        break;
                    case 15:
                        currentForeground = 25;
                        break;
                    case 16:
                        currentForeground = 24;
                        break;
                    case 17:
                        currentForeground = 26;
                        break;
                    case 18:
                        currentForeground = 8;
                        break;
                    case 19:
                        currentForeground = 12;
                        break;
                    case 20:
                        currentForeground = 9;
                        break;
                    case 21:
                        currentForeground = 11;
                        break;
                    case 22:
                        currentForeground = 10;
                        break;
                    case 23:
                        currentForeground = 23;
                        break;
                    case 24:
                        currentForeground = 34;
                        break;
                    case 25:
                        currentForeground = 25;
                        break;
                    case 26:
                        currentForeground = 36;
                        break;
                    case 27:
                        currentForeground = 37;
                        break;
                    case 28:
                        currentForeground = 18;
                        break;
                    case 29:
                        currentForeground = 19;
                        break;
                    case 30:
                        currentForeground = 30;
                        break;
                    case 31:
                        currentForeground = 20;
                        break;
                    case 32:
                        currentForeground = 21;
                        break;
                    case 33:
                        currentForeground = 22;
                        break;
                    case 34:
                        currentForeground = 43;
                        break;
                    case 35:
                        currentForeground = 44;
                        break;
                    case 36:
                        currentForeground = 36;
                        break;
                    case 37:
                        currentForeground = 45;
                        break;
                    case 38:
                        currentForeground = 28;
                        break;
                    case 39:
                        currentForeground = 29;
                        break;
                    case 40:
                        currentForeground = 30;
                        break;
                    case 41:
                        currentForeground = 32;
                        break;
                    case 42:
                        currentForeground = 33;
                        break;
                    case 43:
                        currentForeground = 43;
                        break;
                    case 44:
                        currentForeground = 44;
                        break;
                    case 45:
                        currentForeground = 45;
                        break;
                    case 46:
                        currentForeground = 38;
                        break;
                    case 47:
                        currentForeground = 39;
                        break;
                    case 48:
                        currentForeground = 40;
                        break;
                    case 49:
                        currentForeground = 54;
                        break;
                    case 50:
                        currentForeground = 42;
                        break;
                    case 51:
                        currentForeground = 46;
                        break;
                    case 52:
                        currentForeground = 47;
                        break;
                    case 53:
                        currentForeground = 48;
                        break;
                    case 54:
                        currentForeground = 59;
                        break;
                    case 55:
                        currentForeground = 49;
                        break;
                    case 56:
                        currentForeground = 50;
                        break;
                    case 57:
                        currentForeground = 52;
                        break;
                    case 58:
                        currentForeground = 53;
                        break;
                    case 59:
                        currentForeground = 70;
                        break;
                    case 60:
                        currentForeground = 55;
                        break;
                    case 61:
                        currentForeground = 56;
                        break;
                    case 62:
                        currentForeground = 51;
                        break;
                    case 63:
                        currentForeground = 63;
                        break;
                    case 64:
                        currentForeground = 63;
                        break;
                    case 65:
                        currentForeground = 64;
                        break;
                    case 66:
                        currentForeground = 66;
                        break;
                    case 67:
                        currentForeground = 66;
                        break;
                    case 68:
                        currentForeground = 71;
                        break;
                    case 69:
                        currentForeground = 69;
                        break;
                    case 70:
                        currentForeground = 70;
                        break;
                    case 71:
                        currentForeground = 78;
                        break;
                    case 72:
                        currentForeground = 72;
                        break;
                    case 73:
                        currentForeground = 74;
                        break;
                    case 74:
                        currentForeground = 75;
                        break;
                    case 75:
                        currentForeground = 75;
                        break;
                    case 76:
                        currentForeground = 76;
                        break;
                    case 77:
                        currentForeground = 79;
                        break;
                    case 78:
                        currentForeground = 80;
                        break;
                    case 79:
                        currentForeground = 88;
                        break;
                    case 80:
                        currentForeground = 90;
                        break;
                    case 81:
                        currentForeground = 81;
                        break;
                    case 82:
                        currentForeground = 82;
                        break;
                    case 83:
                        currentForeground = 81;
                        break;
                    case 84:
                        currentForeground = 86;
                        break;
                    case 85:
                        currentForeground = 84;
                        break;
                    case 86:
                        currentForeground = 87;
                        break;
                    case 87:
                        currentForeground = 87;
                        break;
                    case 88:
                        currentForeground = 88;
                        break;
                    case 89:
                        currentForeground = 57;
                        break;
                    case 90:
                        currentForeground = 90;
                        break;
                }
            }
            else if (Player.Direction == "south")
            {
                switch (currentForeground)
                {
                    case 0:
                        currentForeground = 2;
                        break;
                    case 1:
                        currentForeground = 0;
                        break;
                    case 2:
                        currentForeground = 10;
                        break;
                    case 3:
                        currentForeground = 9;
                        break;
                    case 4:
                        currentForeground = 8;
                        break;
                    case 5:
                        currentForeground = 1;
                        break;
                    case 6:
                        currentForeground = 3;
                        break;
                    case 7:
                        currentForeground = 4;
                        break;
                    case 8:
                        currentForeground = 18;
                        break;
                    case 9:
                        currentForeground = 20;
                        break;
                    case 10:
                        currentForeground = 22;
                        break;
                    case 11:
                        currentForeground = 21;
                        break;
                    case 12:
                        currentForeground = 19;
                        break;
                    case 13:
                        currentForeground = 5;
                        break;
                    case 14:
                        currentForeground = 6;
                        break;
                    case 15:
                        currentForeground = 7;
                        break;
                    case 16:
                        currentForeground = 11;
                        break;
                    case 17:
                        currentForeground = 12;
                        break;
                    case 18:
                        currentForeground = 28;
                        break;
                    case 19:
                        currentForeground = 29;
                        break;
                    case 20:
                        currentForeground = 31;
                        break;
                    case 21:
                        currentForeground = 32;
                        break;
                    case 22:
                        currentForeground = 33;
                        break;
                    case 23:
                        currentForeground = 14;
                        break;
                    case 24:
                        currentForeground = 16;
                        break;
                    case 25:
                        currentForeground = 15;
                        break;
                    case 26:
                        currentForeground = 17;
                        break;
                    case 27:
                        currentForeground = 27;
                        break;
                    case 28:
                        currentForeground = 38;
                        break;
                    case 29:
                        currentForeground = 39;
                        break;
                    case 30:
                        currentForeground = 40;
                        break;
                    case 31:
                        currentForeground = 31;
                        break;
                    case 32:
                        currentForeground = 41;
                        break;
                    case 33:
                        currentForeground = 42;
                        break;
                    case 34:
                        currentForeground = 24;
                        break;
                    case 35:
                        currentForeground = 35;
                        break;
                    case 36:
                        currentForeground = 26;
                        break;
                    case 37:
                        currentForeground = 27;
                        break;
                    case 38:
                        currentForeground = 46;
                        break;
                    case 39:
                        currentForeground = 47;
                        break;
                    case 40:
                        currentForeground = 48;
                        break;
                    case 41:
                        currentForeground = 41;
                        break;
                    case 42:
                        currentForeground = 50;
                        break;
                    case 43:
                        currentForeground = 34;
                        break;
                    case 44:
                        currentForeground = 35;
                        break;
                    case 45:
                        currentForeground = 37;
                        break;
                    case 46:
                        currentForeground = 51;
                        break;
                    case 47:
                        currentForeground = 52;
                        break;
                    case 48:
                        currentForeground = 53;
                        break;
                    case 49:
                        currentForeground = 55;
                        break;
                    case 50:
                        currentForeground = 56;
                        break;
                    case 51:
                        currentForeground = 62;
                        break;
                    case 52:
                        currentForeground = 57;
                        break;
                    case 53:
                        currentForeground = 58;
                        break;
                    case 54:
                        currentForeground = 49;
                        break;
                    case 55:
                        currentForeground = 60;
                        break;
                    case 56:
                        currentForeground = 61;
                        break;
                    case 57:
                        currentForeground = 89;
                        break;
                    case 58:
                        currentForeground = 58;
                        break;
                    case 59:
                        currentForeground = 54;
                        break;
                    case 60:
                        currentForeground = 60;
                        break;
                    case 61:
                        currentForeground = 61;
                        break;
                    case 62:
                        currentForeground = 62;
                        break;
                    case 63:
                        currentForeground = 64;
                        break;
                    case 64:
                        currentForeground = 65;
                        break;
                    case 65:
                        currentForeground = 65;
                        break;
                    case 66:
                        currentForeground = 67;
                        break;
                    case 67:
                        currentForeground = 67;
                        break;
                    case 68:
                        currentForeground = 13;
                        break;
                    case 69:
                        currentForeground = 69;
                        break;
                    case 70:
                        currentForeground = 59;
                        break;
                    case 71:
                        currentForeground = 68;
                        break;
                    case 72:
                        currentForeground = 72;
                        break;
                    case 73:
                        currentForeground = 73;
                        break;
                    case 74:
                        currentForeground = 73;
                        break;
                    case 75:
                        currentForeground = 74;
                        break;
                    case 76:
                        currentForeground = 76;
                        break;
                    case 77:
                        currentForeground = 77;
                        break;
                    case 78:
                        currentForeground = 71;
                        break;
                    case 79:
                        currentForeground = 77;
                        break;
                    case 80:
                        currentForeground = 78;
                        break;
                    case 81:
                        currentForeground = 83;
                        break;
                    case 82:
                        currentForeground = 82;
                        break;
                    case 83:
                        currentForeground = 83;
                        break;
                    case 84:
                        currentForeground = 85;
                        break;
                    case 85:
                        currentForeground = 85;
                        break;
                    case 86:
                        currentForeground = 84;
                        break;
                    case 87:
                        currentForeground = 86;
                        break;
                    case 88:
                        currentForeground = 79;
                        break;
                    case 89:
                        currentForeground = 89;
                        break;
                    case 90:
                        currentForeground = 80;
                        break;
                }
            }
  


            previousForeground = currentForeground;

            base.Update(gameTime);
        }

    }
}
