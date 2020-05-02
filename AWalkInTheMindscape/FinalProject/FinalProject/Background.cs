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
    class Background : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D backGroundTexture;
        SpriteFont spriteFont;
        static List<Rectangle> rigidBodyList = new List<Rectangle>();
        Rectangle background;
        const int SCALE = 3;

        static int currentBackground = 91;
        int previousBackground;

        //backgrounds
        //const int FOREST0 = 0;
        //const int FOREST1 = 1;
        //const int VILLIAGE2 = 2;
        //const int GRASS3 = 3;
        //const int ROAD = 4;
        //const int FOREST5 = 5;
        //const int FOREST6 = 6;
        //const int FOREST7 = 7;
        //const int ROAD8 = 8;
        //const int VILLIAGE9 = 9;
        //const int ROAD10 = 10;
        //const int ROAD11 = 11;
        //const int ROAD12 = 12;
        //const int GATE13 = 13;
        //const int FOREST14 = 14;
        //const int FOREST15 = 15;
        //const int RIVER16 = 16;
        //const int FOREST17 = 17;
        //const int FOREST18 = 18;
        //const int SWAMP19 = 19;
        //const int GRASS20 = 20;
        //const int RIVER21 = 21;
        //const int ROAD22 = 22;
        //const int WALL23 = 23;
        //const int RIVER24 = 24;
        //const int WALL25 = 25;
        //const int FOREST26 = 26;
        //const int FOREST27 = 27;
        //const int SWAMP28 = 28;
        //const int SWAMP29 = 29;
        //const int SWAMP30 = 30;
        //const int ROAD31 = 31;
        //const int ROAD32 = 32;
        //const int SWAMP33 = 33;
        //const int WALL34 = 34;
        //const int RIVER35 = 35;
        //const int RIVER36 = 36;
        //const int FOREST37 = 37;
        //const int SWAMP38 = 38;
        //const int SWAMP39 = 39;
        //const int SWAMP40 = 40;
        //const int BRIDGE41 = 41;
        //const int SWAMP42 = 42;
        //const int HOLE43 = 43;
        //const int WALL44 = 44;
        //const int WALL45 = 45;
        //const int SWAMP46 = 46;
        //const int SWAMP47 = 47;
        //const int SWAMP48 = 48;
        //const int ROAD49 = 49;
        //const int SWAMP50 = 50;
        //const int SWAMP51 = 51;
        //const int SWAMP52 = 52;
        //const int SWAMP53 = 53;
        //const int CAVE54 = 54;
        //const int MOUNTAIN55 = 55;
        //const int SWAMP56 = 56;
        //const int SWAMP57 = 57;
        //const int SWAMP58 = 58;
        //const int CAVE59 = 59;
        //const int MOUNTAIN60 = 60;
        //const int SWAMP61 = 61;
        //const int SWAMP62 = 62;
        //const int MOUNTAIN63 = 63;
        //const int MOUNTAIN64 = 64;
        //const int MOUNTAIN65 = 65;
        //const int MOUNTAIN66 = 66;
        //const int MOUNTAIN67 = 67;
        //const int CASTLE68 = 68;
        //const int FOUNTAIN69 = 69;
        //const int CAVE70 = 70;
        //const int CASTLE71 = 71;
        //const int CASTLE72 = 72;
        //const int CASTLE73 = 73;
        //const int CASTLE74 = 74;
        //const int CASTLE75 = 75;
        //const int CASTLE76 = 76;
        //const int CASTLE77 = 77;
        //const int CASTLE78 = 78;
        //const int CASTLE79 = 79;
        //const int CASTLE80 = 80;
        //const int CASTLE81 = 81;
        //const int CASLTE82 = 82;
        //const int CASTLE83 = 83;
        //const int CASTLE84 = 84;
        //const int CASTLE85 = 85;
        //const int CASTLE86 = 86;
        //const int CASTLE87 = 87;
        //const int CASTLE88 = 88;
        //const int SWAMP91 = 89;
        //const int CASTLE92 = 90;
        //const int PLAYERHOUSE = 91;

        List<Rectangle> backgroundFrames;


        const int BACKGROUNDWIDTH = 461;
        const int BACKGROUNDHEIGHT = 240;

        Game game;

        int mouseX;
        int mouseY;
        public static int CurrentBackground { get => currentBackground; }
        public static List<Rectangle> RigidBodyList { get => rigidBodyList; }
        public Background(Game game, SpriteBatch spriteBatch, Texture2D backGroundTexture, SpriteFont spriteFont) : base(game)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.backGroundTexture = backGroundTexture;
            this.spriteFont = spriteFont;

            //backgrounds
            backgroundFrames = new List<Rectangle>();
            backgroundFrames.Add(new Rectangle(0, 0, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(461, 0, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(922, 0, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1383, 0, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1844, 0, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2305, 0, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2766, 0, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(0, 240, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(461, 240, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(922, 240, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1383, 240, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1844, 240, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2305, 240, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2766, 240, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(0, 480, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(461, 480, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(922, 480, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1383, 480, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1844, 480, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2305, 480, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2766, 480, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(0, 720, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(461, 720, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(922, 720, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1383, 720, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1844, 720, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2305, 720, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2766, 720, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(0, 960, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(461, 960, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(922, 960, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1383, 960, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1844, 960, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2305, 960, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2766, 960, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(0, 1200, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(461, 1200, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(922, 1200, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1383, 1200, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1844, 1200, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2305, 1200, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2766, 1200, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(0, 1440, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(461, 1440, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(922, 1440, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1383, 1440, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1844, 1440, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2305, 1440, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2766, 1440, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(0, 1680, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(461, 1680, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(922, 1680, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1383, 1680, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1844, 1680, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2305, 1680, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2766, 1680, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(0, 1920, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(461, 1920, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(922, 1920, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1383, 1920, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1844, 1920, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2305, 1920, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2766, 1920, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(0, 2160, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(461, 2160, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(922, 2160, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1383, 2160, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1844, 2160, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2305, 2160, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2766, 2160, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(0, 2400, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(461, 2400, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(922, 2400, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1383, 2400, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1844, 2400, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2305, 2400, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2766, 2400, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(0, 2640, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(461, 2640, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(922, 2640, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1383, 2640, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1844, 2640, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2305, 2640, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2766, 2640, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(0, 2880, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(461, 2880, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(922, 2880, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1383, 2880, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1844, 2880, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2305, 2880, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2766, 2880, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(0, 3120, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(461, 3120, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(922, 3120, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1383, 3120, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(1844, 3120, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2305, 3120, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));
            backgroundFrames.Add(new Rectangle(2766, 3120, BACKGROUNDWIDTH, BACKGROUNDHEIGHT));

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

            background = new Rectangle(0, 0, (int)(BACKGROUNDWIDTH * SCALE), (int)(BACKGROUNDHEIGHT * SCALE));

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(backGroundTexture, background, backgroundFrames.ElementAt<Rectangle>(currentBackground), Color.White, 0f, new Vector2(0), SpriteEffects.None, 0f);
            //spriteBatch.DrawString(spriteFont, mouseX.ToString() + ", " + mouseY.ToString(), new Vector2(0), Color.Red);
            //spriteBatch.DrawString(spriteFont, currentBackground.ToString(), new Vector2(20), Color.Yellow);
            //wireframe:
            //foreach (var rigidBody in rigidBodyList)
              //  spriteBatch.DrawRectangle(rigidBody, Color.Red);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();

            mouseX = ms.X;
            mouseY = ms.Y;


            //change background
            if (Player.Direction == "east")
            {
                switch (currentBackground)
                {
                    case 0:
                        currentBackground = 3;
                        break;
                    case 1:
                        currentBackground = 6;
                        break;
                    case 2:
                        currentBackground = 9;
                        break;
                    case 3:
                        currentBackground = 11;
                        break;
                    case 4:
                        currentBackground = 0;
                        break;
                    case 5:
                        currentBackground = 14;
                        break;
                    case 6:
                        currentBackground = 16;
                        break;
                    case 7:
                        currentBackground = 1;
                        break;
                    case 8:
                        currentBackground = 2;
                        break;
                    case 9:
                        currentBackground = 21;
                        break;
                    case 10:
                        currentBackground = 20;
                        break;
                    case 11:
                        currentBackground = 11;
                        break;
                    case 12:
                        currentBackground = 4;
                        break;
                    case 13:
                        currentBackground = 23;
                        break;
                    case 14:
                        currentBackground = 24;
                        break;
                    case 15:
                        currentBackground = 5;
                        break;
                    case 16:
                        currentBackground = 16;
                        break;
                    case 17:
                        currentBackground = 7;
                        break;
                    case 18:
                        currentBackground = 10;
                        break;
                    case 19:
                        currentBackground = 8;
                        break;
                    case 20:
                        currentBackground = 32;
                        break;
                    case 21:
                        currentBackground = 21;
                        break;
                    case 22:
                        currentBackground = 31;
                        break;
                    case 23:
                        currentBackground = 34;
                        break;
                    case 24:
                        currentBackground = 35;
                        break;
                    case 25:
                        currentBackground = 13;
                        break;
                    case 26:
                        currentBackground = 15;
                        break;
                    case 27:
                        currentBackground = 17;
                        break;
                    case 28:
                        currentBackground = 22;
                        break;
                    case 29:
                        currentBackground = 18;
                        break;
                    case 30:
                        currentBackground = 19;
                        break;
                    case 31:
                        currentBackground = 41;
                        break;
                    case 32:
                        currentBackground = 32;
                        break;
                    case 33:
                        currentBackground = 33;
                        break;
                    case 34:
                        currentBackground = 44;
                        break;
                    case 35:
                        currentBackground = 35;
                        break;
                    case 36:
                        currentBackground = 25;
                        break;
                    case 37:
                        currentBackground = 26;
                        break;
                    case 38:
                        currentBackground = 33;
                        break;
                    case 39:
                        currentBackground = 28;
                        break;
                    case 40:
                        currentBackground = 29;
                        break;
                    case 41:
                        currentBackground = 49;
                        break;
                    case 42:
                        currentBackground = 42;
                        break;
                    case 43:
                        currentBackground = 43;
                        break;
                    case 44:
                        currentBackground = 44;
                        break;
                    case 45:
                        currentBackground = 36;
                        break;
                    case 46:
                        currentBackground = 42;
                        break;
                    case 47:
                        currentBackground = 38;
                        break;
                    case 48:
                        currentBackground = 39;
                        break;
                    case 49:
                        currentBackground = 49;
                        break;
                    case 50:
                        currentBackground = 50;
                        break;
                    case 51:
                        currentBackground = 50;
                        break;
                    case 52:
                        currentBackground = 46;
                        break;
                    case 53:
                        currentBackground = 47;
                        break;
                    case 54:
                        currentBackground = 54;
                        break;
                    case 55:
                        currentBackground = 55;
                        break;
                    case 56:
                        currentBackground = 56;
                        break;
                    case 57:
                        currentBackground = 51;
                        break;
                    case 58:
                        currentBackground = 52;
                        break;
                    case 59:
                        currentBackground = 59;
                        break;
                    case 60:
                        currentBackground = 60;
                        break;
                    case 61:
                        currentBackground = 61;
                        break;
                    case 62:
                        currentBackground = 56;
                        break;
                    case 63:
                        currentBackground = 60;
                        break;
                    case 64:
                        currentBackground = 64;
                        break;
                    case 65:
                        currentBackground = 66;
                        break;
                    case 66:
                        currentBackground = 66;
                        break;
                    case 67:
                        currentBackground = 67;
                        break;
                    case 68:
                        currentBackground = 68;
                        break;
                    case 69:
                        currentBackground = 12;
                        break;
                    case 70:
                        currentBackground = 70;
                        break;
                    case 71:
                        currentBackground = 71;
                        break;
                    case 72:
                        currentBackground = 68;
                        break;
                    case 73:
                        currentBackground = 72;
                        break;
                    case 74:
                        currentBackground = 74;
                        break;
                    case 75:
                        currentBackground = 76;
                        break;
                    case 76:
                        currentBackground = 78;
                        break;
                    case 77:
                        currentBackground = 75;
                        break;
                    case 78:
                        currentBackground = 81;
                        break;
                    case 79:
                        currentBackground = 79;
                        break;
                    case 80:
                        currentBackground = 80;
                        break;
                    case 81:
                        currentBackground = 82;
                        break;
                    case 82:
                        currentBackground = 84;
                        break;
                    case 83:
                        currentBackground = 83;
                        break;
                    case 84:
                        currentBackground = 84;
                        break;
                    case 85:
                        currentBackground = 85;
                        break;
                    case 86:
                        currentBackground = 86;
                        break;
                    case 87:
                        currentBackground = 87;
                        break;
                    case 88:
                        currentBackground = 88;
                        break;
                    case 89:
                        currentBackground = 62;
                        break;
                    case 90:
                        currentBackground = 90;
                        break;
                    case 91:                        
                        currentBackground = 2;
                        break;
                }
            }
            else if (Player.Direction == "west")
            {
                switch (currentBackground)
                {
                    case 0:
                        currentBackground = 4;
                        break;
                    case 1:
                        currentBackground = 7;
                        break;
                    case 2:
                        if (Player.Inside)
                        {
                            currentBackground = 91;
                        }
                        else
                        {
                            currentBackground = 8;
                        }                      
                        break;
                    case 3:
                        currentBackground = 0;
                        break;
                    case 4:
                        currentBackground = 12;
                        break;
                    case 5:
                        currentBackground = 15;
                        break;
                    case 6:
                        currentBackground = 1;
                        break;
                    case 7:
                        currentBackground = 17;
                        break;
                    case 8:
                        currentBackground = 19;
                        break;
                    case 9:
                        currentBackground = 2;
                        break;
                    case 10:
                        currentBackground = 18;
                        break;
                    case 11:
                        currentBackground = 3;
                        break;
                    case 12:
                        currentBackground = 69;
                        break;
                    case 13:
                        currentBackground = 25;
                        break;
                    case 14:
                        currentBackground = 5;
                        break;
                    case 15:
                        currentBackground = 26;
                        break;
                    case 16:
                        currentBackground = 6;
                        break;
                    case 17:
                        currentBackground = 27;
                        break;
                    case 18:
                        currentBackground = 29;
                        break;
                    case 19:
                        currentBackground = 30;
                        break;
                    case 20:
                        currentBackground = 10;
                        break;
                    case 21:
                        currentBackground = 9;
                        break;
                    case 22:
                        currentBackground = 28;
                        break;
                    case 23:
                        currentBackground = 13;
                        break;
                    case 24:
                        currentBackground = 14;
                        break;
                    case 25:
                        currentBackground = 36;
                        break;
                    case 26:
                        currentBackground = 37;
                        break;
                    case 27:
                        currentBackground = 27;
                        break;
                    case 28:
                        currentBackground = 39;
                        break;
                    case 29:
                        currentBackground = 40;
                        break;
                    case 30:
                        currentBackground = 30;
                        break;
                    case 31:
                        currentBackground = 22;
                        break;
                    case 32:
                        currentBackground = 20;
                        break;
                    case 33:
                        currentBackground = 38;
                        break;
                    case 34:
                        currentBackground = 23;
                        break;
                    case 35:
                        currentBackground = 24;
                        break;
                    case 36:
                        currentBackground = 45;
                        break;
                    case 37:
                        currentBackground = 37;
                        break;
                    case 38:
                        currentBackground = 47;
                        break;
                    case 39:
                        currentBackground = 48;
                        break;
                    case 40:
                        currentBackground = 40;
                        break;
                    case 41:
                        currentBackground = 31;
                        break;
                    case 42:
                        currentBackground = 46;
                        break;
                    case 43:
                        currentBackground = 43;
                        break;
                    case 44:
                        currentBackground = 34;
                        break;
                    case 45:
                        currentBackground = 45;
                        break;
                    case 46:
                        currentBackground = 52;
                        break;
                    case 47:
                        currentBackground = 53;
                        break;
                    case 48:
                        currentBackground = 48;
                        break;
                    case 49:
                        currentBackground = 41;
                        break;
                    case 50:
                        currentBackground = 51;
                        break;
                    case 51:
                        currentBackground = 57;
                        break;
                    case 52:
                        currentBackground = 58;
                        break;
                    case 53:
                        currentBackground = 53;
                        break;
                    case 54:
                        currentBackground = 54;
                        break;
                    case 55:
                        currentBackground = 55;
                        break;
                    case 56:
                        currentBackground = 62;
                        break;
                    case 57:
                        currentBackground = 57;
                        break;
                    case 58:
                        currentBackground = 58;
                        break;
                    case 59:
                        currentBackground = 59;
                        break;
                    case 60:
                        currentBackground = 63;
                        break;
                    case 61:
                        currentBackground = 61;
                        break;
                    case 62:
                        currentBackground = 89;
                        break;
                    case 63:
                        currentBackground = 63;
                        break;
                    case 64:
                        currentBackground = 64;
                        break;
                    case 65:
                        currentBackground = 65;
                        break;
                    case 66:
                        currentBackground = 65;
                        break;
                    case 67:
                        currentBackground = 67;
                        break;
                    case 68:
                        currentBackground = 72;
                        break;
                    case 69:
                        currentBackground = 69;
                        break;
                    case 70:
                        currentBackground = 70;
                        break;
                    case 71:
                        currentBackground = 71;
                        break;
                    case 72:
                        currentBackground = 73;
                        break;
                    case 73:
                        currentBackground = 73;
                        break;
                    case 74:
                        currentBackground = 74;
                        break;
                    case 75:
                        currentBackground = 77;
                        break;
                    case 76:
                        currentBackground = 75;
                        break;
                    case 77:
                        currentBackground = 77;
                        break;
                    case 78:
                        currentBackground = 76;
                        break;
                    case 79:
                        currentBackground = 79;
                        break;
                    case 80:
                        currentBackground = 80;
                        break;
                    case 81:
                        currentBackground = 78;
                        break;
                    case 82:
                        currentBackground = 81;
                        break;
                    case 83:
                        currentBackground = 83;
                        break;
                    case 84:
                        currentBackground = 82;
                        break;
                    case 85:
                        currentBackground = 85;
                        break;
                    case 86:
                        currentBackground = 86;
                        break;
                    case 87:
                        currentBackground = 87;
                        break;
                    case 88:
                        currentBackground = 88;
                        break;
                    case 89:
                        currentBackground = 89;
                        break;
                    case 90:
                        currentBackground = 90;
                        break;
                }
            }
            if (Player.Direction == "north")
            {
                switch (currentBackground)
                {
                    case 0:
                        currentBackground = 1;
                        break;
                    case 1:
                        currentBackground = 5;
                        break;
                    case 2:
                        currentBackground = 0;
                        break;
                    case 3:
                        currentBackground = 6;
                        break;
                    case 4:
                        currentBackground = 7;
                        break;
                    case 5:
                        currentBackground = 13;
                        break;
                    case 6:
                        currentBackground = 14;
                        break;
                    case 7:
                        currentBackground = 15;
                        break;
                    case 8:
                        currentBackground = 4;
                        break;
                    case 9:
                        currentBackground = 3;
                        break;
                    case 10:
                        currentBackground = 2;
                        break;
                    case 11:
                        currentBackground = 16;
                        break;
                    case 12:
                        currentBackground = 17;
                        break;
                    case 13:
                        currentBackground = 68;
                        break;
                    case 14:
                        currentBackground = 23;
                        break;
                    case 15:
                        currentBackground = 25;
                        break;
                    case 16:
                        currentBackground = 24;
                        break;
                    case 17:
                        currentBackground = 26;
                        break;
                    case 18:
                        currentBackground = 8;
                        break;
                    case 19:
                        currentBackground = 12;
                        break;
                    case 20:
                        currentBackground = 9;
                        break;
                    case 21:
                        currentBackground = 11;
                        break;
                    case 22:
                        currentBackground = 10;
                        break;
                    case 23:
                        currentBackground = 23;
                        break;
                    case 24:
                        currentBackground = 34;
                        break;
                    case 25:
                        currentBackground = 25;
                        break;
                    case 26:
                        currentBackground = 36;
                        break;
                    case 27:
                        currentBackground = 37;
                        break;
                    case 28:
                        currentBackground = 18;
                        break;
                    case 29:
                        currentBackground = 19;
                        break;
                    case 30:
                        currentBackground = 30;
                        break;
                    case 31:
                        currentBackground = 20;
                        break;
                    case 32:
                        currentBackground = 21;
                        break;
                    case 33:
                        currentBackground = 22;
                        break;
                    case 34:
                        currentBackground = 43;
                        break;
                    case 35:
                        currentBackground = 44;
                        break;
                    case 36:
                        currentBackground = 36;
                        break;
                    case 37:
                        currentBackground = 45;
                        break;
                    case 38:
                        currentBackground = 28;
                        break;
                    case 39:
                        currentBackground = 29;
                        break;
                    case 40:
                        currentBackground = 30;
                        break;
                    case 41:
                        currentBackground = 32;
                        break;
                    case 42:
                        currentBackground = 33;
                        break;
                    case 43:
                        currentBackground = 43;
                        break;
                    case 44:
                        currentBackground = 44;
                        break;
                    case 45:
                        currentBackground = 45;
                        break;
                    case 46:
                        currentBackground = 38;
                        break;
                    case 47:
                        currentBackground = 39;
                        break;
                    case 48:
                        currentBackground = 40;
                        break;
                    case 49:
                        currentBackground = 54;
                        break;
                    case 50:
                        currentBackground = 42;
                        break;
                    case 51:
                        currentBackground = 46;
                        break;
                    case 52:
                        currentBackground = 47;
                        break;
                    case 53:
                        currentBackground = 48;
                        break;
                    case 54:
                        currentBackground = 59;
                        break;
                    case 55:
                        currentBackground = 49;
                        break;
                    case 56:
                        currentBackground = 50;
                        break;
                    case 57:
                        currentBackground = 52;
                        break;
                    case 58:
                        currentBackground = 53;
                        break;
                    case 59:
                        currentBackground = 70;
                        break;
                    case 60:
                        currentBackground = 55;
                        break;
                    case 61:
                        currentBackground = 56;
                        break;
                    case 62:
                        currentBackground = 51;
                        break;
                    case 63:
                        currentBackground = 63;
                        break;
                    case 64:
                        currentBackground = 63;
                        break;
                    case 65:
                        currentBackground = 64;
                        break;
                    case 66:
                        currentBackground = 66;
                        break;
                    case 67:
                        currentBackground = 66;
                        break;
                    case 68:
                        currentBackground = 71;
                        break;
                    case 69:
                        currentBackground = 69;
                        break;
                    case 70:
                        currentBackground = 70;
                        break;
                    case 71:
                        currentBackground = 78;
                        break;
                    case 72:
                        currentBackground = 72;
                        break;
                    case 73:
                        currentBackground = 74;
                        break;
                    case 74:
                        currentBackground = 75;
                        break;
                    case 75:
                        currentBackground = 75;
                        break;
                    case 76:
                        currentBackground = 76;
                        break;
                    case 77:
                        currentBackground = 79;
                        break;
                    case 78:
                        currentBackground = 80;
                        break;
                    case 79:
                        currentBackground = 88;
                        break;
                    case 80:
                        currentBackground = 90;
                        break;
                    case 81:
                        currentBackground = 81;
                        break;
                    case 82:
                        currentBackground = 82;
                        break;
                    case 83:
                        currentBackground = 81;
                        break;
                    case 84:
                        currentBackground = 86;
                        break;
                    case 85:
                        currentBackground = 84;
                        break;
                    case 86:
                        currentBackground = 87;
                        break;
                    case 87:
                        currentBackground = 87;
                        break;
                    case 88:
                        currentBackground = 88;
                        break;
                    case 89:
                        currentBackground = 57;
                        break;
                    case 90:
                        currentBackground = 90;
                        break;
                }
            }
            else if (Player.Direction == "south")
            {
                switch (currentBackground)
                {
                    case 0:
                        currentBackground = 2;
                        break;
                    case 1:
                        currentBackground = 0;
                        break;
                    case 2:
                        currentBackground = 10;
                        break;
                    case 3:
                        currentBackground = 9;
                        break;
                    case 4:
                        currentBackground = 8;
                        break;
                    case 5:
                        currentBackground = 1;
                        break;
                    case 6:
                        currentBackground = 3;
                        break;
                    case 7:
                        currentBackground = 4;
                        break;
                    case 8:
                        currentBackground = 18;
                        break;
                    case 9:
                        currentBackground = 20;
                        break;
                    case 10:
                        currentBackground = 22;
                        break;
                    case 11:
                        currentBackground = 21;
                        break;
                    case 12:
                        currentBackground = 19;
                        break;
                    case 13:
                        currentBackground = 5;
                        break;
                    case 14:
                        currentBackground = 6;
                        break;
                    case 15:
                        currentBackground = 7;
                        break;
                    case 16:
                        currentBackground = 11;
                        break;
                    case 17:
                        currentBackground = 12;
                        break;
                    case 18:
                        currentBackground = 28;
                        break;
                    case 19:
                        currentBackground = 29;
                        break;
                    case 20:
                        currentBackground = 31;
                        break;
                    case 21:
                        currentBackground = 32;
                        break;
                    case 22:
                        currentBackground = 33;
                        break;
                    case 23:
                        currentBackground = 14;
                        break;
                    case 24:
                        currentBackground = 16;
                        break;
                    case 25:
                        currentBackground = 15;
                        break;
                    case 26:
                        currentBackground = 17;
                        break;
                    case 27:
                        currentBackground = 27;
                        break;
                    case 28:
                        currentBackground = 38;
                        break;
                    case 29:
                        currentBackground = 39;
                        break;
                    case 30:
                        currentBackground = 40;
                        break;
                    case 31:
                        currentBackground = 31;
                        break;
                    case 32:
                        currentBackground = 41;
                        break;
                    case 33:
                        currentBackground = 42;
                        break;
                    case 34:
                        currentBackground = 24;
                        break;
                    case 35:
                        currentBackground = 35;
                        break;
                    case 36:
                        currentBackground = 26;
                        break;
                    case 37:
                        currentBackground = 27;
                        break;
                    case 38:
                        currentBackground = 46;
                        break;
                    case 39:
                        currentBackground = 47;
                        break;
                    case 40:
                        currentBackground = 48;
                        break;
                    case 41:
                        currentBackground = 41;
                        break;
                    case 42:
                        currentBackground = 50;
                        break;
                    case 43:
                        currentBackground = 34;
                        break;
                    case 44:
                        currentBackground = 35;
                        break;
                    case 45:
                        currentBackground = 37;
                        break;
                    case 46:
                        currentBackground = 51;
                        break;
                    case 47:
                        currentBackground = 52;
                        break;
                    case 48:
                        currentBackground = 53;
                        break;
                    case 49:
                        currentBackground = 55;
                        break;
                    case 50:
                        currentBackground = 56;
                        break;
                    case 51:
                        currentBackground = 62;
                        break;
                    case 52:
                        currentBackground = 57;
                        break;
                    case 53:
                        currentBackground = 58;
                        break;
                    case 54:
                        currentBackground = 49;
                        break;
                    case 55:
                        currentBackground = 60;
                        break;
                    case 56:
                        currentBackground = 61;
                        break;
                    case 57:
                        currentBackground = 89;
                        break;
                    case 58:
                        currentBackground = 58;
                        break;
                    case 59:
                        currentBackground = 54;
                        break;
                    case 60:
                        currentBackground = 60;
                        break;
                    case 61:
                        currentBackground = 61;
                        break;
                    case 62:
                        currentBackground = 62;
                        break;
                    case 63:
                        currentBackground = 64;
                        break;
                    case 64:
                        currentBackground = 65;
                        break;
                    case 65:
                        currentBackground = 65;
                        break;
                    case 66:
                        currentBackground = 67;
                        break;
                    case 67:
                        currentBackground = 67;
                        break;
                    case 68:
                        currentBackground = 13;
                        break;
                    case 69:
                        currentBackground = 69;
                        break;
                    case 70:
                        currentBackground = 59;
                        break;
                    case 71:
                        currentBackground = 68;
                        break;
                    case 72:
                        currentBackground = 72;
                        break;
                    case 73:
                        currentBackground = 73;
                        break;
                    case 74:
                        currentBackground = 73;
                        break;
                    case 75:
                        currentBackground = 74;
                        break;
                    case 76:
                        currentBackground = 76;
                        break;
                    case 77:
                        currentBackground = 77;
                        break;
                    case 78:
                        currentBackground = 71;
                        break;
                    case 79:
                        currentBackground = 77;
                        break;
                    case 80:
                        currentBackground = 78;
                        break;
                    case 81:
                        currentBackground = 83;
                        break;
                    case 82:
                        currentBackground = 82;
                        break;
                    case 83:
                        currentBackground = 83;
                        break;
                    case 84:
                        currentBackground = 85;
                        break;
                    case 85:
                        currentBackground = 85;
                        break;
                    case 86:
                        currentBackground = 84;
                        break;
                    case 87:
                        currentBackground = 86;
                        break;
                    case 88:
                        currentBackground = 79;
                        break;
                    case 89:
                        currentBackground = 89;
                        break;
                    case 90:
                        currentBackground = 80;
                        break;
                }
            }
            //remove hitboxes then add the new ones for
            //the background
            if (previousBackground != currentBackground)
            {
                rigidBodyList.Clear();
                switch (currentBackground)
                {
                    case 0:
                        //rigidBodyList.Add(new Rectangle(350, 156, 48, 32));
                        //rigidBodyList.Add(new Rectangle(532, 111, 48, 32));
                        //rigidBodyList.Add(new Rectangle(846, 66, 48, 32));
                        //rigidBodyList.Add(new Rectangle(443, 291, 48, 32));
                        //rigidBodyList.Add(new Rectangle(801, 202, 48, 32));
                        //rigidBodyList.Add(new Rectangle(892, 337, 48, 32));
                        //rigidBodyList.Add(new Rectangle(487, 516, 48, 32));
                        //rigidBodyList.Add(new Rectangle(397, 605, 48, 32));
                        //rigidBodyList.Add(new Rectangle(757, 605, 48, 32));
                        //rigidBodyList.Add(new Rectangle(982, 517, 48, 32));
                        //rigidBodyList.Add(new Rectangle(1027, 111, 48, 32));
                        rigidBodyList.Add(new Rectangle(350, 132, 48, 56));
                        rigidBodyList.Add(new Rectangle(532, 87, 48, 56));
                        rigidBodyList.Add(new Rectangle(846, 42, 48, 56));
                        rigidBodyList.Add(new Rectangle(443, 267, 48, 56));
                        rigidBodyList.Add(new Rectangle(801, 178, 48, 56));
                        rigidBodyList.Add(new Rectangle(892, 313, 48, 56));
                        rigidBodyList.Add(new Rectangle(487, 492, 48, 56));
                        rigidBodyList.Add(new Rectangle(397, 581, 48, 56));
                        rigidBodyList.Add(new Rectangle(757, 581, 48, 56));
                        rigidBodyList.Add(new Rectangle(982, 493, 48, 56));
                        rigidBodyList.Add(new Rectangle(1027, 87, 48, 56));
                        break;
                    case 1:
                        rigidBodyList.Add(new Rectangle(350, 132, 48, 56));
                        rigidBodyList.Add(new Rectangle(532, 87, 48, 56));
                        rigidBodyList.Add(new Rectangle(846, 42, 48, 56));
                        rigidBodyList.Add(new Rectangle(443, 267, 48, 56));
                        rigidBodyList.Add(new Rectangle(801, 178, 48, 56));
                        rigidBodyList.Add(new Rectangle(892, 313, 48, 56));
                        rigidBodyList.Add(new Rectangle(487, 492, 48, 56));
                        rigidBodyList.Add(new Rectangle(397, 581, 48, 56));
                        rigidBodyList.Add(new Rectangle(757, 581, 48, 56));
                        rigidBodyList.Add(new Rectangle(982, 493, 48, 56));
                        rigidBodyList.Add(new Rectangle(1027, 87, 48, 56));
                        break;
                    case 2:
                        rigidBodyList.Add(new Rectangle(438, 2, 185, 94));
                        rigidBodyList.Add(new Rectangle(438, 180, 185, 94));
                        rigidBodyList.Add(new Rectangle(438, 405, 185, 94));
                        rigidBodyList.Add(new Rectangle(305, 555, 142, 415));
                        rigidBodyList.Add(new Rectangle(712, 408, 49, 94));
                        rigidBodyList.Add(new Rectangle(712, 586, 49, 94));
                        rigidBodyList.Add(new Rectangle(922, 518, 211, 72));
                        rigidBodyList.Add(new Rectangle(714, 33, 495, 145));
                        rigidBodyList.Add(new Rectangle(1029, 33, 58, 245));
                        break;
                    case 3:
                        break;
                    case 4:
                        rigidBodyList.Add(new Rectangle(441, 100, 48, 56));
                        rigidBodyList.Add(new Rectangle(568, 256, 48, 56));
                        rigidBodyList.Add(new Rectangle(714, 78, 48, 56));
                        rigidBodyList.Add(new Rectangle(745, 292, 48, 56));
                        rigidBodyList.Add(new Rectangle(931, 172, 48, 56));
                        rigidBodyList.Add(new Rectangle(882, 373, 48, 56));
                        rigidBodyList.Add(new Rectangle(814, 515, 48, 56));
                        break;
                    case 5:
                        rigidBodyList.Add(new Rectangle(350, 132, 48, 56));
                        rigidBodyList.Add(new Rectangle(532, 87, 48, 56));
                        rigidBodyList.Add(new Rectangle(846, 42, 48, 56));
                        rigidBodyList.Add(new Rectangle(443, 267, 48, 56));
                        rigidBodyList.Add(new Rectangle(801, 178, 48, 56));
                        rigidBodyList.Add(new Rectangle(892, 313, 48, 56));
                        rigidBodyList.Add(new Rectangle(487, 492, 48, 56));
                        rigidBodyList.Add(new Rectangle(397, 581, 48, 56));
                        rigidBodyList.Add(new Rectangle(757, 581, 48, 56));
                        rigidBodyList.Add(new Rectangle(982, 493, 48, 56));
                        rigidBodyList.Add(new Rectangle(1027, 87, 48, 56));
                        break;
                    case 6:
                        rigidBodyList.Add(new Rectangle(442, 42, 48, 56));
                        rigidBodyList.Add(new Rectangle(351, 222, 48, 56));
                        rigidBodyList.Add(new Rectangle(442, 537, 48, 56));
                        rigidBodyList.Add(new Rectangle(424, 809, 48, 56));
                        rigidBodyList.Add(new Rectangle(622, 313, 48, 56));
                        rigidBodyList.Add(new Rectangle(801, 88, 48, 56));
                        rigidBodyList.Add(new Rectangle(938, 178, 48, 56));
                        rigidBodyList.Add(new Rectangle(712, 573, 48, 56));
                        rigidBodyList.Add(new Rectangle(986, 444, 48, 56));
                        break;
                    case 7:
                        rigidBodyList.Add(new Rectangle(442, 42, 48, 56));
                        rigidBodyList.Add(new Rectangle(351, 222, 48, 56));
                        rigidBodyList.Add(new Rectangle(442, 537, 48, 56));
                        rigidBodyList.Add(new Rectangle(424, 809, 48, 56));
                        rigidBodyList.Add(new Rectangle(622, 313, 48, 56));
                        rigidBodyList.Add(new Rectangle(801, 88, 48, 56));
                        rigidBodyList.Add(new Rectangle(938, 178, 48, 56));
                        rigidBodyList.Add(new Rectangle(712, 573, 48, 56));
                        rigidBodyList.Add(new Rectangle(986, 444, 48, 56));
                        break;
                    case 8:
                        rigidBodyList.Add(new Rectangle(353, 63, 78, 56));
                        rigidBodyList.Add(new Rectangle(430, 203, 78, 56));
                        rigidBodyList.Add(new Rectangle(507, 378, 78, 56));
                        rigidBodyList.Add(new Rectangle(371, 554, 78, 56));
                        break;
                    case 9:
                        rigidBodyList.Add(new Rectangle(305, 33, 96, 245));
                        rigidBodyList.Add(new Rectangle(440, 90, 228, 85));
                        rigidBodyList.Add(new Rectangle(889, 2, 185, 94));
                        rigidBodyList.Add(new Rectangle(889, 181, 185, 94));
                        rigidBodyList.Add(new Rectangle(305, 521, 109, 72));
                        rigidBodyList.Add(new Rectangle(757, 466, 230, 127));
                        rigidBodyList.Add(new Rectangle(437, 460, 141, 121));
                        rigidBodyList.Add(new Rectangle(493, 404, 175, 85));
                        rigidBodyList.Add(new Rectangle(1433, 86, 58, 357));
                        break;
                    case 10:
                        rigidBodyList.Add(new Rectangle(470, 457, 78, 56));
                        break;
                    case 11:
                        rigidBodyList.Add(new Rectangle(580, 2, 248, 495));
                        rigidBodyList.Add(new Rectangle(539, 89, 248, 35));
                        rigidBodyList.Add(new Rectangle(553, 362, 248, 1));
                        rigidBodyList.Add(new Rectangle(548, 640, 188, 212));
                        rigidBodyList.Add(new Rectangle(591, 596, 61, 148));
                        rigidBodyList.Add(new Rectangle(627, 496, 61, 148));
                        break;
                    case 12:
                        rigidBodyList.Add(new Rectangle(422, 516, 78, 56));
                        rigidBodyList.Add(new Rectangle(594, 420, 78, 56));
                        rigidBodyList.Add(new Rectangle(650, 536, 78, 56));
                        rigidBodyList.Add(new Rectangle(898, 552, 78, 56));
                        break;
                    case 13:
                        rigidBodyList.Add(new Rectangle(305, 0, 354, 135));
                        rigidBodyList.Add(new Rectangle(718, 0, 354, 135));
                        rigidBodyList.Add(new Rectangle(397, 223, 48, 56));
                        rigidBodyList.Add(new Rectangle(487, 537, 48, 56));
                        rigidBodyList.Add(new Rectangle(893, 443, 48, 56));
                        rigidBodyList.Add(new Rectangle(983, 267, 48, 56));
                        break;
                    case 14:
                        rigidBodyList.Add(new Rectangle(442, 42, 48, 56));
                        rigidBodyList.Add(new Rectangle(351, 222, 48, 56));
                        rigidBodyList.Add(new Rectangle(442, 537, 48, 56));
                        rigidBodyList.Add(new Rectangle(424, 809, 48, 56));
                        rigidBodyList.Add(new Rectangle(622, 313, 48, 56));
                        rigidBodyList.Add(new Rectangle(801, 88, 48, 56));
                        rigidBodyList.Add(new Rectangle(938, 178, 48, 56));
                        rigidBodyList.Add(new Rectangle(712, 573, 48, 56));
                        rigidBodyList.Add(new Rectangle(986, 444, 48, 56));
                        break;
                    case 15:
                        rigidBodyList.Add(new Rectangle(442, 42, 48, 56));
                        rigidBodyList.Add(new Rectangle(351, 222, 48, 56));
                        rigidBodyList.Add(new Rectangle(442, 537, 48, 56));
                        rigidBodyList.Add(new Rectangle(424, 809, 48, 56));
                        rigidBodyList.Add(new Rectangle(622, 313, 48, 56));
                        rigidBodyList.Add(new Rectangle(801, 88, 48, 56));
                        rigidBodyList.Add(new Rectangle(938, 178, 48, 56));
                        rigidBodyList.Add(new Rectangle(712, 573, 48, 56));
                        rigidBodyList.Add(new Rectangle(986, 444, 48, 56));
                        break;
                    case 16:
                        rigidBodyList.Add(new Rectangle(580, 2, 248, 495));
                        rigidBodyList.Add(new Rectangle(539, 89, 248, 35));
                        rigidBodyList.Add(new Rectangle(553, 362, 248, 1));
                        rigidBodyList.Add(new Rectangle(548, 640, 188, 212));
                        rigidBodyList.Add(new Rectangle(591, 596, 61, 148));
                        rigidBodyList.Add(new Rectangle(627, 496, 61, 148));
                        break;
                    case 17:
                        rigidBodyList.Add(new Rectangle(442, 42, 48, 56));
                        rigidBodyList.Add(new Rectangle(351, 222, 48, 56));
                        rigidBodyList.Add(new Rectangle(442, 537, 48, 56));
                        rigidBodyList.Add(new Rectangle(424, 809, 48, 56));
                        rigidBodyList.Add(new Rectangle(622, 313, 48, 56));
                        rigidBodyList.Add(new Rectangle(801, 88, 48, 56));
                        rigidBodyList.Add(new Rectangle(938, 178, 48, 56));
                        rigidBodyList.Add(new Rectangle(712, 573, 48, 56));
                        rigidBodyList.Add(new Rectangle(986, 444, 48, 56));
                        break;
                    case 18:
                        rigidBodyList.Add(new Rectangle(518, 104, 78, 56));
                        rigidBodyList.Add(new Rectangle(413, 219, 78, 56));
                        rigidBodyList.Add(new Rectangle(579, 326, 78, 56));
                        rigidBodyList.Add(new Rectangle(519, 495, 78, 56));
                        rigidBodyList.Add(new Rectangle(747, 516, 78, 56));
                        rigidBodyList.Add(new Rectangle(891, 450, 78, 56));
                        break;
                    case 19:
                        rigidBodyList.Add(new Rectangle(384, 178, 78, 56));
                        rigidBodyList.Add(new Rectangle(432, 357, 78, 56));
                        rigidBodyList.Add(new Rectangle(564, 492, 78, 56));
                        rigidBodyList.Add(new Rectangle(927, 81, 78, 56));
                        rigidBodyList.Add(new Rectangle(879, 396, 78, 56));
                        rigidBodyList.Add(new Rectangle(793, 541, 78, 56));
                        rigidBodyList.Add(new Rectangle(665, 223, 94, 56));
                        break;
                    case 20:
                        break;
                    case 21:
                        rigidBodyList.Add(new Rectangle(580, 2, 248, 495));
                        rigidBodyList.Add(new Rectangle(539, 89, 248, 35));
                        rigidBodyList.Add(new Rectangle(553, 362, 248, 1));
                        rigidBodyList.Add(new Rectangle(548, 640, 188, 212));
                        rigidBodyList.Add(new Rectangle(591, 596, 61, 148));
                        rigidBodyList.Add(new Rectangle(627, 496, 61, 148));
                        break;
                    case 22:
                        rigidBodyList.Add(new Rectangle(518, 104, 78, 56));
                        rigidBodyList.Add(new Rectangle(413, 219, 78, 56));
                        rigidBodyList.Add(new Rectangle(579, 326, 78, 56));
                        rigidBodyList.Add(new Rectangle(519, 495, 78, 56));
                        rigidBodyList.Add(new Rectangle(747, 516, 78, 56));
                        rigidBodyList.Add(new Rectangle(891, 450, 78, 56));
                        break;
                    case 23:
                        rigidBodyList.Add(new Rectangle(305, 0, 769, 135));
                        rigidBodyList.Add(new Rectangle(396, 267, 48, 56));
                        rigidBodyList.Add(new Rectangle(445, 447, 48, 56));
                        rigidBodyList.Add(new Rectangle(533, 540, 48, 56));
                        rigidBodyList.Add(new Rectangle(712, 401, 48, 56));
                        rigidBodyList.Add(new Rectangle(806, 219, 48, 56));
                        rigidBodyList.Add(new Rectangle(934, 578, 48, 56));
                        rigidBodyList.Add(new Rectangle(983, 354, 48, 56));
                        break;
                    case 24:
                        rigidBodyList.Add(new Rectangle(584, 569, 248, 151));
                        rigidBodyList.Add(new Rectangle(790, 264, 283, 95));
                        rigidBodyList.Add(new Rectangle(606, 517, 248, 95));
                        rigidBodyList.Add(new Rectangle(639, 435, 188, 212));
                        rigidBodyList.Add(new Rectangle(670, 360, 61, 148));
                        rigidBodyList.Add(new Rectangle(691, 329, 61, 148));
                        rigidBodyList.Add(new Rectangle(725, 275, 211, 156));
                        rigidBodyList.Add(new Rectangle(653, 390, 495, 164));
                        rigidBodyList.Add(new Rectangle(437, 380, 48, 56));
                        rigidBodyList.Add(new Rectangle(514, 155, 48, 56));
                        rigidBodyList.Add(new Rectangle(577, 312, 48, 56));
                        rigidBodyList.Add(new Rectangle(694, 91, 48, 56));
                        rigidBodyList.Add(new Rectangle(914, 164, 48, 56));

                        break;
                    case 25:
                        rigidBodyList.Add(new Rectangle(305, 0, 769, 135));
                        rigidBodyList.Add(new Rectangle(396, 267, 48, 56));
                        rigidBodyList.Add(new Rectangle(445, 447, 48, 56));
                        rigidBodyList.Add(new Rectangle(533, 540, 48, 56));
                        rigidBodyList.Add(new Rectangle(712, 401, 48, 56));
                        rigidBodyList.Add(new Rectangle(806, 219, 48, 56));
                        rigidBodyList.Add(new Rectangle(934, 578, 48, 56));
                        rigidBodyList.Add(new Rectangle(983, 354, 48, 56));
                        break;
                    case 26:
                        rigidBodyList.Add(new Rectangle(442, 42, 48, 56));
                        rigidBodyList.Add(new Rectangle(351, 222, 48, 56));
                        rigidBodyList.Add(new Rectangle(442, 537, 48, 56));
                        rigidBodyList.Add(new Rectangle(424, 809, 48, 56));
                        rigidBodyList.Add(new Rectangle(622, 313, 48, 56));
                        rigidBodyList.Add(new Rectangle(801, 88, 48, 56));
                        rigidBodyList.Add(new Rectangle(938, 178, 48, 56));
                        rigidBodyList.Add(new Rectangle(712, 573, 48, 56));
                        rigidBodyList.Add(new Rectangle(986, 444, 48, 56));
                        break;
                    case 27:
                        rigidBodyList.Add(new Rectangle(442, 42, 48, 56));
                        rigidBodyList.Add(new Rectangle(351, 222, 48, 56));
                        rigidBodyList.Add(new Rectangle(442, 537, 48, 56));
                        rigidBodyList.Add(new Rectangle(424, 809, 48, 56));
                        rigidBodyList.Add(new Rectangle(622, 313, 48, 56));
                        rigidBodyList.Add(new Rectangle(801, 88, 48, 56));
                        rigidBodyList.Add(new Rectangle(938, 178, 48, 56));
                        rigidBodyList.Add(new Rectangle(712, 573, 48, 56));
                        rigidBodyList.Add(new Rectangle(986, 444, 48, 56));
                        rigidBodyList.Add(new Rectangle(305, 0, 74, 720));
                        rigidBodyList.Add(new Rectangle(305, 581, 769, 139));
                        break;
                    case 28:
                        rigidBodyList.Add(new Rectangle(384, 178, 78, 56));
                        rigidBodyList.Add(new Rectangle(432, 357, 78, 56));
                        rigidBodyList.Add(new Rectangle(564, 492, 78, 56));
                        rigidBodyList.Add(new Rectangle(927, 81, 78, 56));
                        rigidBodyList.Add(new Rectangle(879, 396, 78, 56));
                        rigidBodyList.Add(new Rectangle(793, 541, 78, 56));
                        rigidBodyList.Add(new Rectangle(665, 223, 94, 56));
                        break;
                    case 29:
                        rigidBodyList.Add(new Rectangle(384, 178, 78, 56));
                        rigidBodyList.Add(new Rectangle(432, 357, 78, 56));
                        rigidBodyList.Add(new Rectangle(564, 492, 78, 56));
                        rigidBodyList.Add(new Rectangle(927, 81, 78, 56));
                        rigidBodyList.Add(new Rectangle(879, 396, 78, 56));
                        rigidBodyList.Add(new Rectangle(793, 541, 78, 56));
                        rigidBodyList.Add(new Rectangle(665, 223, 94, 56));
                        break;
                    case 30:
                        rigidBodyList.Add(new Rectangle(384, 178, 78, 56));
                        rigidBodyList.Add(new Rectangle(432, 357, 78, 56));
                        rigidBodyList.Add(new Rectangle(564, 492, 78, 56));
                        rigidBodyList.Add(new Rectangle(927, 81, 78, 56));
                        rigidBodyList.Add(new Rectangle(879, 396, 78, 56));
                        rigidBodyList.Add(new Rectangle(793, 541, 78, 56));
                        rigidBodyList.Add(new Rectangle(424, 590, 78, 56));
                        rigidBodyList.Add(new Rectangle(305, 0, 769, 72));
                        rigidBodyList.Add(new Rectangle(305, 0, 141, 720));
                        break;
                    case 31:
                        rigidBodyList.Add(new Rectangle(305, 566, 769, 95));
                        rigidBodyList.Add(new Rectangle(305, 476, 222, 95));
                        rigidBodyList.Add(new Rectangle(644, 521, 296, 95));
                        rigidBodyList.Add(new Rectangle(393, 427, 44, 212));
                        rigidBodyList.Add(new Rectangle(697, 480, 61, 148));
                        rigidBodyList.Add(new Rectangle(840, 480, 57, 148));
                        rigidBodyList.Add(new Rectangle(528, 513, 53, 156));
                        break;
                    case 32:
                        rigidBodyList.Add(new Rectangle(580, 2, 248, 495));
                        rigidBodyList.Add(new Rectangle(539, 89, 248, 35));
                        rigidBodyList.Add(new Rectangle(553, 362, 248, 1));
                        rigidBodyList.Add(new Rectangle(548, 640, 188, 212));
                        rigidBodyList.Add(new Rectangle(591, 596, 61, 148));
                        rigidBodyList.Add(new Rectangle(627, 496, 61, 148));
                        break;
                    case 33:
                        rigidBodyList.Add(new Rectangle(386, 219, 78, 56));
                        rigidBodyList.Add(new Rectangle(521, 447, 78, 56));
                        rigidBodyList.Add(new Rectangle(611, 131, 78, 56));
                        rigidBodyList.Add(new Rectangle(931, 0, 148, 720));
                        rigidBodyList.Add(new Rectangle(836, 493, 78, 219));
                        rigidBodyList.Add(new Rectangle(784, 582, 78, 10));
                        rigidBodyList.Add(new Rectangle(886, 83, 78, 249));
                        rigidBodyList.Add(new Rectangle(835, 132, 78, 10));
                        rigidBodyList.Add(new Rectangle(835, 264, 78, 25));
                        rigidBodyList.Add(new Rectangle(875, 445, 78, 25));
                        break;
                    case 34:
                        rigidBodyList.Add(new Rectangle(305, 0, 319, 135));
                        rigidBodyList.Add(new Rectangle(759, 0, 769, 135));
                        rigidBodyList.Add(new Rectangle(396, 267, 48, 56));
                        rigidBodyList.Add(new Rectangle(445, 447, 48, 56));
                        rigidBodyList.Add(new Rectangle(533, 540, 48, 56));
                        rigidBodyList.Add(new Rectangle(712, 401, 48, 56));
                        rigidBodyList.Add(new Rectangle(806, 219, 48, 56));
                        rigidBodyList.Add(new Rectangle(934, 578, 48, 56));
                        rigidBodyList.Add(new Rectangle(983, 354, 48, 56));
                        break;
                    case 35:
                        rigidBodyList.Add(new Rectangle(971, 0, 248, 306));
                        rigidBodyList.Add(new Rectangle(544, 320, 748, 95));
                        rigidBodyList.Add(new Rectangle(305, 313, 169, 95));
                        rigidBodyList.Add(new Rectangle(474, 365, 188, 212));
                        rigidBodyList.Add(new Rectangle(375, 280, 61, 148));
                        rigidBodyList.Add(new Rectangle(681, 280, 27, 148));
                        rigidBodyList.Add(new Rectangle(905, 274, 211, 156));
                        rigidBodyList.Add(new Rectangle(996, 86, 495, 164));
                        rigidBodyList.Add(new Rectangle(1433, 86, 58, 357));
                        rigidBodyList.Add(new Rectangle(524, 169, 48, 56));
                        rigidBodyList.Add(new Rectangle(794, 91, 48, 56));
                        rigidBodyList.Add(new Rectangle(983, 354, 48, 56));
                        break;
                    case 36:
                        rigidBodyList.Add(new Rectangle(305, 0, 769, 135));
                        rigidBodyList.Add(new Rectangle(396, 267, 48, 56));
                        rigidBodyList.Add(new Rectangle(445, 447, 48, 56));
                        rigidBodyList.Add(new Rectangle(533, 540, 48, 56));
                        rigidBodyList.Add(new Rectangle(712, 401, 48, 56));
                        rigidBodyList.Add(new Rectangle(806, 219, 48, 56));
                        rigidBodyList.Add(new Rectangle(934, 578, 48, 56));
                        rigidBodyList.Add(new Rectangle(983, 354, 48, 56));
                        break;
                    case 37:
                        rigidBodyList.Add(new Rectangle(442, 42, 48, 56));
                        rigidBodyList.Add(new Rectangle(351, 222, 48, 56));
                        rigidBodyList.Add(new Rectangle(442, 537, 48, 56));
                        rigidBodyList.Add(new Rectangle(424, 809, 48, 56));
                        rigidBodyList.Add(new Rectangle(622, 313, 48, 56));
                        rigidBodyList.Add(new Rectangle(801, 88, 48, 56));
                        rigidBodyList.Add(new Rectangle(938, 178, 48, 56));
                        rigidBodyList.Add(new Rectangle(712, 573, 48, 56));
                        rigidBodyList.Add(new Rectangle(986, 444, 48, 56));
                        rigidBodyList.Add(new Rectangle(305, 0, 74, 720));
                        break;
                    case 38:
                        rigidBodyList.Add(new Rectangle(384, 178, 78, 56));
                        rigidBodyList.Add(new Rectangle(432, 357, 78, 56));
                        rigidBodyList.Add(new Rectangle(564, 492, 78, 56));
                        rigidBodyList.Add(new Rectangle(927, 81, 78, 56));
                        rigidBodyList.Add(new Rectangle(879, 396, 78, 56));
                        rigidBodyList.Add(new Rectangle(793, 541, 78, 56));
                        rigidBodyList.Add(new Rectangle(665, 223, 94, 56));
                        break;
                    case 39:
                        rigidBodyList.Add(new Rectangle(384, 178, 78, 56));
                        rigidBodyList.Add(new Rectangle(432, 357, 78, 56));
                        rigidBodyList.Add(new Rectangle(564, 492, 78, 56));
                        rigidBodyList.Add(new Rectangle(927, 81, 78, 56));
                        rigidBodyList.Add(new Rectangle(879, 396, 78, 56));
                        rigidBodyList.Add(new Rectangle(793, 541, 78, 56));
                        rigidBodyList.Add(new Rectangle(665, 223, 94, 56));
                        break;
                    case 40:
                        rigidBodyList.Add(new Rectangle(384, 178, 78, 56));
                        rigidBodyList.Add(new Rectangle(432, 357, 78, 56));
                        rigidBodyList.Add(new Rectangle(564, 492, 78, 56));
                        rigidBodyList.Add(new Rectangle(927, 81, 78, 56));
                        rigidBodyList.Add(new Rectangle(879, 396, 78, 56));                      
                        rigidBodyList.Add(new Rectangle(305, 0, 141, 720));
                        break;
                    case 41:
                        rigidBodyList.Add(new Rectangle(305, 566, 769, 95));
                        rigidBodyList.Add(new Rectangle(305, 476, 222, 95));
                        rigidBodyList.Add(new Rectangle(644, 521, 296, 95));
                        rigidBodyList.Add(new Rectangle(393, 427, 44, 212));
                        rigidBodyList.Add(new Rectangle(697, 480, 61, 148));
                        rigidBodyList.Add(new Rectangle(840, 480, 57, 148));
                        rigidBodyList.Add(new Rectangle(528, 513, 53, 156));
                        rigidBodyList.Add(new Rectangle(580, 2, 200, 230));
                        rigidBodyList.Add(new Rectangle(539, 89, 258, 35));
                        rigidBodyList.Add(new Rectangle(548, 640, 188, 212));
                        rigidBodyList.Add(new Rectangle(573, 438, 319, 319));
                        rigidBodyList.Add(new Rectangle(490, 477, 61, 148));
                        rigidBodyList.Add(new Rectangle(820, 0, 253, 140));
                        break;
                    case 42:
                        rigidBodyList.Add(new Rectangle(386, 219, 78, 56));
                        rigidBodyList.Add(new Rectangle(521, 447, 78, 56));
                        rigidBodyList.Add(new Rectangle(611, 131, 78, 56));
                        rigidBodyList.Add(new Rectangle(931, 0, 148, 720));
                        rigidBodyList.Add(new Rectangle(836, 493, 78, 219));
                        rigidBodyList.Add(new Rectangle(784, 582, 78, 10));
                        rigidBodyList.Add(new Rectangle(886, 83, 78, 249));
                        rigidBodyList.Add(new Rectangle(835, 132, 78, 10));
                        rigidBodyList.Add(new Rectangle(835, 264, 78, 25));
                        rigidBodyList.Add(new Rectangle(875, 445, 78, 25));
                        break;
                    case 43:
                        rigidBodyList.Add(new Rectangle(305, 0, 768, 89));
                        rigidBodyList.Add(new Rectangle(305, 0, 89, 720));
                        rigidBodyList.Add(new Rectangle(984, 0, 89, 720));
                        rigidBodyList.Add(new Rectangle(305, 631, 319, 89));
                        rigidBodyList.Add(new Rectangle(759, 631, 314, 89));           
                        break;
                    case 44:
                        rigidBodyList.Add(new Rectangle(305, 0, 769, 135));
                        rigidBodyList.Add(new Rectangle(396, 267, 48, 56));
                        rigidBodyList.Add(new Rectangle(445, 447, 48, 56));
                        rigidBodyList.Add(new Rectangle(533, 540, 48, 56));
                        rigidBodyList.Add(new Rectangle(712, 401, 48, 56));
                        rigidBodyList.Add(new Rectangle(806, 219, 48, 56));
                        rigidBodyList.Add(new Rectangle(934, 578, 48, 56));
                        rigidBodyList.Add(new Rectangle(983, 354, 48, 56));
                        rigidBodyList.Add(new Rectangle(982, 136, 48, 584));
                        break;
                    case 45:
                        rigidBodyList.Add(new Rectangle(305, 0, 769, 135));
                        rigidBodyList.Add(new Rectangle(396, 267, 48, 56));
                        rigidBodyList.Add(new Rectangle(445, 447, 48, 56));
                        rigidBodyList.Add(new Rectangle(533, 540, 48, 56));
                        rigidBodyList.Add(new Rectangle(712, 401, 48, 56));
                        rigidBodyList.Add(new Rectangle(806, 219, 48, 56));
                        rigidBodyList.Add(new Rectangle(934, 578, 48, 56));
                        rigidBodyList.Add(new Rectangle(983, 354, 48, 56));
                        rigidBodyList.Add(new Rectangle(381, 612, 48, 56));
                        rigidBodyList.Add(new Rectangle(412, 627, 48, 56));
                        rigidBodyList.Add(new Rectangle(305, 136, 72, 584));
                        break;
                    case 46:
                        rigidBodyList.Add(new Rectangle(384, 178, 78, 56));
                        rigidBodyList.Add(new Rectangle(432, 357, 78, 56));
                        rigidBodyList.Add(new Rectangle(564, 492, 78, 56));
                        rigidBodyList.Add(new Rectangle(927, 81, 78, 56));
                        rigidBodyList.Add(new Rectangle(879, 396, 78, 56));
                        rigidBodyList.Add(new Rectangle(793, 541, 78, 56));
                        rigidBodyList.Add(new Rectangle(665, 223, 94, 56));
                        break;
                    case 47:
                        rigidBodyList.Add(new Rectangle(384, 178, 78, 56));
                        rigidBodyList.Add(new Rectangle(432, 357, 78, 56));
                        rigidBodyList.Add(new Rectangle(564, 492, 78, 56));
                        rigidBodyList.Add(new Rectangle(927, 81, 78, 56));
                        rigidBodyList.Add(new Rectangle(879, 396, 78, 56));
                        rigidBodyList.Add(new Rectangle(793, 541, 78, 56));
                        rigidBodyList.Add(new Rectangle(665, 223, 94, 56));
                        break;
                    case 48:
                        rigidBodyList.Add(new Rectangle(384, 178, 78, 56));
                        rigidBodyList.Add(new Rectangle(432, 357, 78, 56));
                        rigidBodyList.Add(new Rectangle(564, 492, 78, 56));
                        rigidBodyList.Add(new Rectangle(927, 81, 78, 56));
                        rigidBodyList.Add(new Rectangle(879, 396, 78, 56));
                        rigidBodyList.Add(new Rectangle(305, 0, 141, 720));
                        break;
                    case 49:
                        rigidBodyList.Add(new Rectangle(931, 0, 148, 720));
                        rigidBodyList.Add(new Rectangle(836, 493, 78, 219));
                        rigidBodyList.Add(new Rectangle(784, 582, 78, 10));
                        rigidBodyList.Add(new Rectangle(886, 83, 78, 249));
                        rigidBodyList.Add(new Rectangle(835, 132, 78, 10));
                        rigidBodyList.Add(new Rectangle(835, 264, 78, 25));
                        rigidBodyList.Add(new Rectangle(875, 445, 78, 25));
                        rigidBodyList.Add(new Rectangle(780, 0, 293, 238));
                        rigidBodyList.Add(new Rectangle(305, 0, 333, 144));
                        rigidBodyList.Add(new Rectangle(430, 0, 70, 186));
                        rigidBodyList.Add(new Rectangle(569, 0, 70, 186));
                        rigidBodyList.Add(new Rectangle(305, 600, 291, 186));
                        rigidBodyList.Add(new Rectangle(305, 547, 227, 186));
                        rigidBodyList.Add(new Rectangle(395, 510, 45, 25));
                        break;
                    case 50:
                        rigidBodyList.Add(new Rectangle(386, 219, 78, 56));
                        rigidBodyList.Add(new Rectangle(521, 447, 78, 56));
                        rigidBodyList.Add(new Rectangle(611, 131, 78, 56));
                        rigidBodyList.Add(new Rectangle(931, 0, 148, 720));
                        rigidBodyList.Add(new Rectangle(836, 493, 78, 219));
                        rigidBodyList.Add(new Rectangle(784, 582, 78, 10));
                        rigidBodyList.Add(new Rectangle(886, 83, 78, 249));
                        rigidBodyList.Add(new Rectangle(835, 132, 78, 10));
                        rigidBodyList.Add(new Rectangle(835, 264, 78, 25));
                        rigidBodyList.Add(new Rectangle(875, 445, 78, 25));
                        break;
                    case 51:
                        rigidBodyList.Add(new Rectangle(384, 178, 78, 56));
                        rigidBodyList.Add(new Rectangle(432, 357, 78, 56));
                        rigidBodyList.Add(new Rectangle(564, 492, 78, 56));
                        rigidBodyList.Add(new Rectangle(927, 81, 78, 56));
                        rigidBodyList.Add(new Rectangle(879, 396, 78, 56));
                        rigidBodyList.Add(new Rectangle(793, 541, 78, 56));
                        rigidBodyList.Add(new Rectangle(665, 223, 94, 56));
                        break;
                    case 52:
                        rigidBodyList.Add(new Rectangle(384, 178, 78, 56));
                        rigidBodyList.Add(new Rectangle(432, 357, 78, 56));
                        rigidBodyList.Add(new Rectangle(564, 492, 78, 56));
                        rigidBodyList.Add(new Rectangle(927, 81, 78, 56));
                        rigidBodyList.Add(new Rectangle(879, 396, 78, 56));
                        rigidBodyList.Add(new Rectangle(793, 541, 78, 56));
                        rigidBodyList.Add(new Rectangle(665, 223, 94, 56));
                        break;
                    case 53:
                        rigidBodyList.Add(new Rectangle(384, 178, 78, 56));
                        rigidBodyList.Add(new Rectangle(432, 357, 78, 56));
                        rigidBodyList.Add(new Rectangle(564, 492, 78, 56));
                        rigidBodyList.Add(new Rectangle(927, 81, 78, 56));
                        rigidBodyList.Add(new Rectangle(879, 396, 78, 56));
                        rigidBodyList.Add(new Rectangle(305, 0, 141, 720));
                        break;
                    case 54:
                        rigidBodyList.Add(new Rectangle(931, 0, 148, 720));
                        rigidBodyList.Add(new Rectangle(836, 493, 78, 219));
                        rigidBodyList.Add(new Rectangle(784, 582, 78, 10));
                        rigidBodyList.Add(new Rectangle(886, 83, 78, 249));
                        rigidBodyList.Add(new Rectangle(835, 132, 78, 10));
                        rigidBodyList.Add(new Rectangle(835, 264, 78, 25));
                        rigidBodyList.Add(new Rectangle(875, 445, 78, 25));

                        rigidBodyList.Add(new Rectangle(305, 0, 148, 720));
                        rigidBodyList.Add(new Rectangle(467, 493, 78, 219));
                        rigidBodyList.Add(new Rectangle(512, 582, 78, 10));
                        rigidBodyList.Add(new Rectangle(419, 83, 78, 249));
                        rigidBodyList.Add(new Rectangle(468, 132, 78, 10));
                        rigidBodyList.Add(new Rectangle(465, 264, 78, 25));
                        rigidBodyList.Add(new Rectangle(429, 445, 78, 25));
                        break;
                    case 55:
                        rigidBodyList.Add(new Rectangle(931, 0, 148, 720));
                        rigidBodyList.Add(new Rectangle(836, 493, 78, 219));
                        rigidBodyList.Add(new Rectangle(784, 582, 78, 10));
                        rigidBodyList.Add(new Rectangle(886, 83, 78, 249));
                        rigidBodyList.Add(new Rectangle(835, 132, 78, 10));
                        rigidBodyList.Add(new Rectangle(835, 264, 78, 25));
                        rigidBodyList.Add(new Rectangle(875, 445, 78, 25));
                        rigidBodyList.Add(new Rectangle(305, 0, 120, 720));
                        break;
                    case 56:
                        rigidBodyList.Add(new Rectangle(386, 219, 78, 56));
                        rigidBodyList.Add(new Rectangle(521, 447, 78, 56));
                        rigidBodyList.Add(new Rectangle(611, 131, 78, 56));
                        rigidBodyList.Add(new Rectangle(931, 0, 148, 720));
                        rigidBodyList.Add(new Rectangle(836, 493, 78, 219));
                        rigidBodyList.Add(new Rectangle(784, 582, 78, 10));
                        rigidBodyList.Add(new Rectangle(886, 83, 78, 249));
                        rigidBodyList.Add(new Rectangle(835, 132, 78, 10));
                        rigidBodyList.Add(new Rectangle(835, 264, 78, 25));
                        rigidBodyList.Add(new Rectangle(875, 445, 78, 25));
                        break;
                    case 57:
                        rigidBodyList.Add(new Rectangle(384, 178, 78, 56));
                        rigidBodyList.Add(new Rectangle(432, 357, 78, 56));
                        rigidBodyList.Add(new Rectangle(564, 492, 78, 56));
                        rigidBodyList.Add(new Rectangle(927, 81, 78, 56));
                        rigidBodyList.Add(new Rectangle(879, 396, 78, 56));
                        rigidBodyList.Add(new Rectangle(305, 0, 141, 720));                      
                        rigidBodyList.Add(new Rectangle(665, 223, 94, 56));
                        break;
                    case 58:
                        rigidBodyList.Add(new Rectangle(384, 178, 78, 56));
                        rigidBodyList.Add(new Rectangle(432, 357, 78, 56));
                        rigidBodyList.Add(new Rectangle(564, 492, 78, 56));
                        rigidBodyList.Add(new Rectangle(927, 81, 78, 56));
                        rigidBodyList.Add(new Rectangle(879, 396, 78, 56));
                        rigidBodyList.Add(new Rectangle(305, 0, 141, 720));
                        rigidBodyList.Add(new Rectangle(305, 596, 768, 100));
                        break;
                    case 59:
                        rigidBodyList.Add(new Rectangle(931, 0, 148, 720));
                        rigidBodyList.Add(new Rectangle(836, 493, 78, 219));
                        rigidBodyList.Add(new Rectangle(784, 582, 78, 10));
                        rigidBodyList.Add(new Rectangle(886, 83, 78, 249));
                        rigidBodyList.Add(new Rectangle(835, 132, 78, 10));
                        rigidBodyList.Add(new Rectangle(835, 264, 78, 25));
                        rigidBodyList.Add(new Rectangle(875, 445, 78, 25));

                        rigidBodyList.Add(new Rectangle(305, 0, 148, 720));
                        rigidBodyList.Add(new Rectangle(467, 493, 78, 219));
                        rigidBodyList.Add(new Rectangle(512, 582, 78, 10));
                        rigidBodyList.Add(new Rectangle(419, 83, 78, 249));
                        rigidBodyList.Add(new Rectangle(468, 132, 78, 10));
                        rigidBodyList.Add(new Rectangle(465, 264, 78, 25));
                        rigidBodyList.Add(new Rectangle(429, 445, 78, 25));
                        break;
                    case 60:
                        rigidBodyList.Add(new Rectangle(931, 0, 148, 720));
                        rigidBodyList.Add(new Rectangle(836, 493, 78, 219));
                        rigidBodyList.Add(new Rectangle(784, 582, 78, 10));
                        rigidBodyList.Add(new Rectangle(886, 83, 78, 249));
                        rigidBodyList.Add(new Rectangle(835, 132, 78, 10));
                        rigidBodyList.Add(new Rectangle(835, 264, 78, 25));
                        rigidBodyList.Add(new Rectangle(875, 445, 78, 25));
                        rigidBodyList.Add(new Rectangle(702, 547, 100, 25));
                        rigidBodyList.Add(new Rectangle(494, 593, 200, 25));
                        rigidBodyList.Add(new Rectangle(646, 572, 200, 25));
                        rigidBodyList.Add(new Rectangle(305, 630, 200, 25));
                        rigidBodyList.Add(new Rectangle(461, 614, 200, 25));
                        rigidBodyList.Add(new Rectangle(305, 0, 184, 190));
                        rigidBodyList.Add(new Rectangle(305, 0, 162, 241));
                        rigidBodyList.Add(new Rectangle(305, 0, 97, 279));
                        break;
                    case 61:
                        rigidBodyList.Add(new Rectangle(386, 219, 78, 56));
                        rigidBodyList.Add(new Rectangle(521, 447, 78, 56));
                        rigidBodyList.Add(new Rectangle(611, 131, 78, 56));
                        rigidBodyList.Add(new Rectangle(931, 0, 148, 720));
                        rigidBodyList.Add(new Rectangle(836, 493, 78, 219));
                        rigidBodyList.Add(new Rectangle(784, 582, 78, 10));
                        rigidBodyList.Add(new Rectangle(886, 83, 78, 249));
                        rigidBodyList.Add(new Rectangle(835, 132, 78, 10));
                        rigidBodyList.Add(new Rectangle(835, 264, 78, 25));
                        rigidBodyList.Add(new Rectangle(875, 445, 78, 25));
                        rigidBodyList.Add(new Rectangle(305, 0, 141, 720));
                        rigidBodyList.Add(new Rectangle(305, 596, 768, 100));
                        break;
                    case 62:
                        rigidBodyList.Add(new Rectangle(305, 596, 768, 100));
                        rigidBodyList.Add(new Rectangle(384, 178, 78, 56));
                        rigidBodyList.Add(new Rectangle(432, 357, 78, 56));
                        rigidBodyList.Add(new Rectangle(564, 492, 78, 56));
                        rigidBodyList.Add(new Rectangle(927, 81, 78, 56));
                        rigidBodyList.Add(new Rectangle(879, 396, 78, 56));
                        rigidBodyList.Add(new Rectangle(793, 541, 78, 56));
                        rigidBodyList.Add(new Rectangle(665, 223, 94, 56));
                        break;
                    case 63:
                        rigidBodyList.Add(new Rectangle(305, 0, 768, 270));
                        rigidBodyList.Add(new Rectangle(911, 630, 248, 95));
                        rigidBodyList.Add(new Rectangle(305, 0, 189, 720));
                        rigidBodyList.Add(new Rectangle(305, 0, 230, 370));                       
                        break;
                    case 64:
                        rigidBodyList.Add(new Rectangle(931, 0, 148, 720));
                        rigidBodyList.Add(new Rectangle(836, 493, 78, 219));
                        rigidBodyList.Add(new Rectangle(784, 582, 78, 10));
                        rigidBodyList.Add(new Rectangle(886, 83, 78, 249));
                        rigidBodyList.Add(new Rectangle(835, 132, 78, 10));
                        rigidBodyList.Add(new Rectangle(835, 264, 78, 25));
                        rigidBodyList.Add(new Rectangle(875, 445, 78, 25));
                        rigidBodyList.Add(new Rectangle(305, 0, 120, 720));
                        break;
                    case 65:
                        rigidBodyList.Add(new Rectangle(305, 0, 148, 720));
                        rigidBodyList.Add(new Rectangle(467, 493, 78, 219));
                        rigidBodyList.Add(new Rectangle(467, 582, 78, 10));
                        rigidBodyList.Add(new Rectangle(423, 83, 78, 249));
                        rigidBodyList.Add(new Rectangle(467, 132, 78, 10));
                        rigidBodyList.Add(new Rectangle(467, 264, 78, 25));
                        rigidBodyList.Add(new Rectangle(423, 445, 78, 25));
                        rigidBodyList.Add(new Rectangle(580, 547, 100, 25));
                        rigidBodyList.Add(new Rectangle(695, 593, 200, 25));
                        rigidBodyList.Add(new Rectangle(536, 572, 200, 25));
                        rigidBodyList.Add(new Rectangle(305, 630, 200, 25));
                        rigidBodyList.Add(new Rectangle(873, 614, 200, 25));
                        rigidBodyList.Add(new Rectangle(884, 0, 184, 190));
                        rigidBodyList.Add(new Rectangle(914, 0, 162, 241));
                        rigidBodyList.Add(new Rectangle(979, 0, 97, 279));
                        break;
                    case 66:
                        rigidBodyList.Add(new Rectangle(305, 0, 768, 270));
                        rigidBodyList.Add(new Rectangle(305, 630, 167, 95));
                        rigidBodyList.Add(new Rectangle(882, 0, 189, 720));
                        rigidBodyList.Add(new Rectangle(841, 0, 230, 370));
                        break;
                    case 67:
                        rigidBodyList.Add(new Rectangle(931, 0, 148, 720));
                        rigidBodyList.Add(new Rectangle(836, 493, 78, 219));
                        rigidBodyList.Add(new Rectangle(784, 582, 78, 10));
                        rigidBodyList.Add(new Rectangle(886, 83, 78, 249));
                        rigidBodyList.Add(new Rectangle(835, 132, 78, 10));
                        rigidBodyList.Add(new Rectangle(835, 264, 78, 25));
                        rigidBodyList.Add(new Rectangle(875, 445, 78, 25));
                        rigidBodyList.Add(new Rectangle(305, 0, 120, 720));
                        rigidBodyList.Add(new Rectangle(305, 528, 768, 78));
                        break;
                    case 68:
                        //Soldier soldier = new Soldier(game, spriteBatch, game.Content.Load<Texture2D>("SoldierSpriteSheet"), new Vector2(400), spriteFont);
                        //game.Components.Add(soldier);
                        rigidBodyList.Add(new Rectangle(305, 0, 90, 90));
                        rigidBodyList.Add(new Rectangle(305, 626, 90, 90));
                        rigidBodyList.Add(new Rectangle(983, 0, 90, 720));                       
                        break;
                    case 69:
                        rigidBodyList.Add(new Rectangle(305, 0, 769, 135));
                        rigidBodyList.Add(new Rectangle(305, 136, 72, 584));
                        rigidBodyList.Add(new Rectangle(305, 0, 74, 720));
                        rigidBodyList.Add(new Rectangle(305, 581, 769, 139));
                        rigidBodyList.Add(new Rectangle(305, 0, 532, 720));
                        break;
                    case 70:
                        rigidBodyList.Add(new Rectangle(931, 0, 148, 720));
                        rigidBodyList.Add(new Rectangle(836, 493, 78, 219));
                        rigidBodyList.Add(new Rectangle(784, 582, 78, 10));
                        rigidBodyList.Add(new Rectangle(886, 83, 78, 249));
                        rigidBodyList.Add(new Rectangle(835, 132, 78, 10));
                        rigidBodyList.Add(new Rectangle(835, 264, 78, 25));
                        rigidBodyList.Add(new Rectangle(875, 445, 78, 25));

                        rigidBodyList.Add(new Rectangle(305, 0, 148, 720));
                        rigidBodyList.Add(new Rectangle(467, 493, 78, 219));
                        rigidBodyList.Add(new Rectangle(512, 582, 78, 10));
                        rigidBodyList.Add(new Rectangle(419, 83, 78, 249));
                        rigidBodyList.Add(new Rectangle(468, 132, 78, 10));
                        rigidBodyList.Add(new Rectangle(465, 264, 78, 25));
                        rigidBodyList.Add(new Rectangle(429, 445, 78, 25));
                        rigidBodyList.Add(new Rectangle(305, 0, 768, 148));
                        rigidBodyList.Add(new Rectangle(305, 0, 381, 191));
                        rigidBodyList.Add(new Rectangle(748, 0, 381, 191));
                        break;
                    case 71:
                        rigidBodyList.Add(new Rectangle(983, 0, 90, 720));
                        rigidBodyList.Add(new Rectangle(305, 0, 90, 720));
                        rigidBodyList.Add(new Rectangle(305, 327, 768, 54));
                        break;
                    case 72:
                        rigidBodyList.Add(new Rectangle(305, 0, 768, 90));
                        rigidBodyList.Add(new Rectangle(305, 630, 768, 90));
                        break;
                    case 73:
                        rigidBodyList.Add(new Rectangle(305, 630, 768, 90));
                        rigidBodyList.Add(new Rectangle(983, 0, 90, 90));
                        rigidBodyList.Add(new Rectangle(305, 0, 90, 720));
                        break;
                    case 74:
                        rigidBodyList.Add(new Rectangle(305, 0, 90, 720));
                        rigidBodyList.Add(new Rectangle(983, 0, 90, 720));
                        break;
                    case 75:
                        rigidBodyList.Add(new Rectangle(305, 0, 768, 90));
                        rigidBodyList.Add(new Rectangle(983, 630, 90, 90));
                        rigidBodyList.Add(new Rectangle(305, 630, 90, 90));
                        break;
                    case 76:
                        rigidBodyList.Add(new Rectangle(305, 0, 768, 90));
                        rigidBodyList.Add(new Rectangle(305, 630, 768, 90));
                        break;
                    case 77:
                        rigidBodyList.Add(new Rectangle(305, 630, 768, 90));
                        rigidBodyList.Add(new Rectangle(983, 0, 90, 90));
                        rigidBodyList.Add(new Rectangle(305, 0, 90, 720));
                        break;
                    case 78:
                        rigidBodyList.Add(new Rectangle(983, 0, 90, 90));
                        rigidBodyList.Add(new Rectangle(305, 0, 90, 90));
                        rigidBodyList.Add(new Rectangle(983, 630, 90, 90));
                        rigidBodyList.Add(new Rectangle(305, 630, 90, 90));
                        break;
                    case 79:
                        rigidBodyList.Add(new Rectangle(305, 0, 90, 720));
                        rigidBodyList.Add(new Rectangle(983, 0, 90, 720));
                        break;
                    case 80:
                        rigidBodyList.Add(new Rectangle(305, 0, 90, 720));
                        rigidBodyList.Add(new Rectangle(983, 0, 90, 720));
                        rigidBodyList.Add(new Rectangle(305, 0, 332, 90));
                        rigidBodyList.Add(new Rectangle(802, 0, 90, 90));
                        rigidBodyList.Add(new Rectangle(640, 147, 95, 50));
                        rigidBodyList.Add(new Rectangle(634, 165, 20, 102));
                        rigidBodyList.Add(new Rectangle(722, 165, 20, 102));
                        break;
                    case 81:
                        rigidBodyList.Add(new Rectangle(305, 0, 768, 90));
                        rigidBodyList.Add(new Rectangle(983, 630, 90, 90));
                        rigidBodyList.Add(new Rectangle(305, 630, 90, 90));
                        break;
                    case 82:
                        rigidBodyList.Add(new Rectangle(305, 0, 768, 90));
                        rigidBodyList.Add(new Rectangle(305, 630, 768, 90));
                        break;
                    case 83:
                        rigidBodyList.Add(new Rectangle(305, 0, 90, 720));
                        rigidBodyList.Add(new Rectangle(983, 0, 90, 720));
                        rigidBodyList.Add(new Rectangle(305, 630, 768, 90));                      
                        break;
                    case 84:
                        rigidBodyList.Add(new Rectangle(305, 0, 90, 90));
                        rigidBodyList.Add(new Rectangle(305, 626, 90, 90));
                        rigidBodyList.Add(new Rectangle(983, 0, 90, 720));
                        break;
                    case 85:
                        rigidBodyList.Add(new Rectangle(305, 0, 90, 720));
                        rigidBodyList.Add(new Rectangle(983, 0, 90, 720));
                        rigidBodyList.Add(new Rectangle(305, 630, 768, 90));
                        break;
                    case 86:
                        rigidBodyList.Add(new Rectangle(305, 0, 90, 720));
                        rigidBodyList.Add(new Rectangle(983, 0, 90, 720));
                        break;
                    case 87:
                        rigidBodyList.Add(new Rectangle(305, 0, 90, 720));
                        rigidBodyList.Add(new Rectangle(983, 0, 90, 720));
                        rigidBodyList.Add(new Rectangle(305, 0, 768, 90));
                        break;
                    case 88:
                        rigidBodyList.Add(new Rectangle(305, 0, 90, 720));
                        rigidBodyList.Add(new Rectangle(983, 0, 90, 720));
                        rigidBodyList.Add(new Rectangle(305, 0, 768, 90));
                        break;
                    case 89:
                        rigidBodyList.Add(new Rectangle(305, 0, 141, 720));
                        rigidBodyList.Add(new Rectangle(305, 596, 768, 100));
                        break;
                    case 90:
                        rigidBodyList.Add(new Rectangle(305, 0, 90, 720));
                        rigidBodyList.Add(new Rectangle(983, 0, 90, 720));
                        rigidBodyList.Add(new Rectangle(305, 0, 768, 90));
                        rigidBodyList.Add(new Rectangle(305, 0, 768, 367));
                        break;
                    case 91:
                        rigidBodyList.Add(new Rectangle(440, 42, 90, 633));
                        rigidBodyList.Add(new Rectangle(440, 42, 496, 90));
                        rigidBodyList.Add(new Rectangle(845, 42, 90, 633));
                        rigidBodyList.Add(new Rectangle(440, 582, 496, 90));
                        rigidBodyList.Add(new Rectangle(440, 42, 183, 197));
                        rigidBodyList.Add(new Rectangle(440, 447, 183, 197));
                        rigidBodyList.Add(new Rectangle(440, 312, 136, 50));
                        rigidBodyList.Add(new Rectangle(665, 489, 180, 100));
                        break;
                }
            }


                previousBackground = currentBackground;

            base.Update(gameTime);
        }
        
    }
}
