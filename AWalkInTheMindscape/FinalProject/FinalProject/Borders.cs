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
    class Borders : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        static List<Rectangle> rigidBodyList = new List<Rectangle>();

        public static List<Rectangle> RigidBodyList { get => rigidBodyList; }

        public Borders(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            rigidBodyList.Add(new Rectangle(0, 0, 1383, 1));
            rigidBodyList.Add(new Rectangle(0, 719, 1500, 1));
            rigidBodyList.Add(new Rectangle(0, 0, 305, 1020));
            rigidBodyList.Add(new Rectangle(1073, 0, 305, 1020));
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            //wireframe:
            //foreach (var rigidBody in rigidBodyList)
            //    spriteBatch.DrawRectangle(rigidBody, Color.Blue);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
