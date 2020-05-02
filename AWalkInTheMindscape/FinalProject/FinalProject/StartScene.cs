using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AllInOneMono
{
    public class StartScene : GameScene
    {
        public MenuComponent Menu { get; set; }

        private SpriteBatch spriteBatch;
        Texture2D titleScreen;
        Rectangle titleScreenSize;
        const int BACKGROUNDWIDTH = 461;
        const int BACKGROUNDHEIGHT = 240;
        const int SCALE = 3;
        string[] menuItems = {"New Game",
                                "How To Play",
                                "Help",
                                "About",
                                "Quit"};
        public StartScene(Game game): base(game)
        {
            Game1 g = (Game1)game;

            this.spriteBatch = g.spriteBatch;
            SpriteFont regularFont = g.Content.Load<SpriteFont>("regularFont");
            SpriteFont highlightFont = game.Content.Load<SpriteFont>("hilightFont");
            Song song = game.Content.Load<Song>("mainTheme");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            titleScreen = g.Content.Load<Texture2D>("titleScreen");
            titleScreenSize = new Rectangle(0, 0, (int)(BACKGROUNDWIDTH * SCALE), (int)(BACKGROUNDHEIGHT * SCALE));
            Menu = new MenuComponent(game, spriteBatch,regularFont,highlightFont, menuItems);
            this.Components.Add(Menu);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(titleScreen, titleScreenSize, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
