using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AllInOneMono
{
    public class HelpScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D helpText;
        Rectangle helpScreenSize;

        const int BACKGROUNDWIDTH = 461;
        const int BACKGROUNDHEIGHT = 240;
        const int SCALE = 3;
        public HelpScene(Game game): base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            helpText = g.Content.Load<Texture2D>("HelpScreen");
            helpScreenSize = new Rectangle(0, 0, (int)(BACKGROUNDWIDTH * SCALE), (int)(BACKGROUNDHEIGHT * SCALE));

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(helpText, helpScreenSize, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
