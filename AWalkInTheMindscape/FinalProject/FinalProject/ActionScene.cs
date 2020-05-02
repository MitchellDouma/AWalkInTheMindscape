using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FinalProject;

namespace AllInOneMono
{
    public class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        SpriteFont defaultFont;

        Texture2D backgroundTexture;
        Texture2D playerTexture;
        Texture2D heartTexture;
        Texture2D swordTexture;
        Texture2D soldierTexture;
        Texture2D chestTexture;
         Texture2D dragonTexture;
       Texture2D hotButtonTexture;
        Texture2D keyTexture;
        Texture2D gateTexture;
        Texture2D bombTexture;
        Texture2D wallTexture;
         Texture2D fireTexture;
        Game1 g;


        const float WIDTH = 22f;
        const float HEIGHT = 32f;
        const float SCALE = 1.5f;

        //Rectangle soldierRectangle;

        int previousBackground;

        Player player;
        Score score;
        List<Soldier> soldiers = new List<Soldier>();
        Soldier soldier;

        

        Dragon dragon;
        // Fire fire;

        Random random = new Random();
        Vector2 randomPosition;

        Keys[] oldKeys = new Keys[0];

        bool paused = false;

        //private Bat bat;
        public ActionScene(Game game) : base(game)
        {
            g = (Game1)game;
            this.spriteBatch = g.spriteBatch;


            // TODO: use this.Content to load your game content here
            defaultFont = g.Content.Load<SpriteFont>("defaultFont");

            Music music = new Music(g);
            this.Components.Add(music);

            backgroundTexture = g.Content.Load<Texture2D>("backgroundSpriteSheet");
            Background b = new Background(g, spriteBatch, backgroundTexture, defaultFont);
            this.Components.Add(b);

            Borders border = new Borders(g, spriteBatch);
            this.Components.Add(border);

            VilliageDoors v = new VilliageDoors(g, spriteBatch);
            this.Components.Add(v);

            chestTexture = g.Content.Load<Texture2D>("chestSpriteSheet");
            Chest c = new Chest(g, spriteBatch, chestTexture);
            this.Components.Add(c);

            gateTexture = g.Content.Load<Texture2D>("gate");
            Gate gate = new Gate(g, spriteBatch, gateTexture);
            this.Components.Add(gate);

            wallTexture = g.Content.Load<Texture2D>("brokenWall");
            Walls wall = new Walls(g, spriteBatch, wallTexture);
            this.Components.Add(wall);

            dragonTexture = g.Content.Load<Texture2D>("DragonHeadSpriteSheet");
            dragon = new Dragon(g, spriteBatch, dragonTexture, defaultFont);
            this.Components.Add(dragon);

            //Fire fire = new Fire(g, spriteBatch, new Vector2(0), 1);
            //this.Components.Add(fire);

            soldierTexture = g.Content.Load<Texture2D>("SoldierSpriteSheet");

            soldiers.Add(new Soldier(g, spriteBatch, soldierTexture, soldiers, defaultFont));
            
            foreach (Soldier soldier in soldiers)
            {
                this.Components.Add(soldier);
            }

            //score = new Score(g, spriteBatch, defaultFont);
            //this.Components.Add(score);

            playerTexture = g.Content.Load<Texture2D>("PlayerSpriteSheet");
            player = new Player(g, spriteBatch, playerTexture, defaultFont);
            this.Components.Add(player);

            heartTexture = g.Content.Load<Texture2D>("heart");
            Hearts heart = new Hearts(g, spriteBatch, heartTexture, player, defaultFont);
            this.Components.Add(heart);

            hotButtonTexture = g.Content.Load<Texture2D>("HotButtons");
            HotButtons hB = new HotButtons(g, spriteBatch, hotButtonTexture);
            this.Components.Add(hB);

            swordTexture = g.Content.Load<Texture2D>("ironSwordSpriteSheet");
            IronSword s = new IronSword(g, spriteBatch, swordTexture);
            this.Components.Add(s);

            bombTexture = g.Content.Load<Texture2D>("bomb");
            Bomb bomb = new Bomb(g, spriteBatch, bombTexture,  defaultFont);
            this.Components.Add(bomb);

            keyTexture = g.Content.Load<Texture2D>("key");
            Key k = new Key(g, spriteBatch, keyTexture);
            this.Components.Add(k);

            //foreground
            backgroundTexture = g.Content.Load<Texture2D>("foregroundSpriteSheet");
            Foreground f = new Foreground(g, spriteBatch, backgroundTexture, defaultFont);
            this.Components.Add(f);
        }
        public override void Update(GameTime gameTime)
        {
            //randomPosition.X = random.Next(400, 900);
            //randomPosition.Y = random.Next(10, 600);

            KeyboardState keyState = Keyboard.GetState();
            Keys[] pressedKeys = keyState.GetPressedKeys();
            for (int i = 0; i < pressedKeys.Length; i++)
            {
                bool foundIt = false;
                for (int j = 0; j < oldKeys.Length; j++)
                {
                    if (pressedKeys[i] == oldKeys[j])
                    {
                        foundIt = true;
                    }
                }

                if (!foundIt)
                {
                    if (!paused)
                    {
                        if (keyState.IsKeyDown(Keys.I))
                        {
                            paused = true;
                        }

                    }
                    else
                    {
                        if (keyState.IsKeyDown(Keys.I))
                        {
                            paused = false;
                        }
                    }
                }
            }
            //note the previous keypress
            oldKeys = pressedKeys;
            if (!paused)
            {

                player.Update();
                //score.Update(gameTime);
                dragon.Update();
                //foreach(Soldier soldier in soldiers)
                //{
                //    soldier.Update();
                //}

                //fire.Update();
 
            }
            if (Background.CurrentBackground != previousBackground)
            {
                //soldiers.Clear();
                LoadSoldier();
            }

            previousBackground = Background.CurrentBackground;
            base.Update(gameTime);
        }
        public void LoadSoldier()
        {
            soldiers.Clear();
           // Soldier.IsDead.Clear();
            //Soldier.SoldierRectangle.Clear();
            
            for (int i = 0; i < 7; i++)
            {
                soldiers.Add(new Soldier(g, spriteBatch, soldierTexture, soldiers, defaultFont));
            }
            foreach (Soldier soldier in soldiers)
            {
                this.Components.Add(soldier);
            }
        }
    
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

    }
}
