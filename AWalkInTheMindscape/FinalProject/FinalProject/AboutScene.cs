using AllInOneMono;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class AboutScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D aboutText;
        Rectangle aboutScreenSize;

        const int BACKGROUNDWIDTH = 461;
        const int BACKGROUNDHEIGHT = 240;
        const int SCALE = 3;
        public AboutScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            aboutText = g.Content.Load<Texture2D>("About");
            aboutScreenSize = new Rectangle(0, 0, (int)(BACKGROUNDWIDTH * SCALE), (int)(BACKGROUNDHEIGHT * SCALE));

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(aboutText, aboutScreenSize, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
