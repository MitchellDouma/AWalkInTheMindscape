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
    class VilliageDoors : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        static List<Rectangle> rigidBodyList = new List<Rectangle>();

        public static List<Rectangle> RigidBodyList { get => rigidBodyList; }
        public VilliageDoors(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            //wireframe:
           // foreach (var rigidBody in rigidBodyList)
              //  spriteBatch.DrawRectangle(rigidBody, Color.Orange);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            rigidBodyList.Clear();
            if (Background.CurrentBackground == 91)
            {
                rigidBodyList.Add(new Rectangle(845, 324, 5, 65));
            }
            else if(Background.CurrentBackground == 2)
            {
                rigidBodyList.Add(new Rectangle(442, 625, 5, 65));            
            }

            base.Update(gameTime);
        }
    }
}
