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
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Music : DrawableGameComponent
    {
        Game game;
        Song backgroundMusic;
        bool playMusic = false;
        int previousBackground = 91;
        bool isDead;

        public Music(Game game) : base(game)
        {
            this.game = game;
            MediaPlayer.IsRepeating = true;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (!Player.IsDead)
            {

                if (Background.CurrentBackground == 91 || Background.CurrentBackground == 2
                        || Background.CurrentBackground == 9 || Background.CurrentBackground == 3
                         || Background.CurrentBackground == 20 || Background.CurrentBackground == 69)
                {
                    if (backgroundMusic != game.Content.Load<Song>("HappyTownMusic"))
                    {

                    if (!playMusic)
                    {
                        backgroundMusic = game.Content.Load<Song>("HappyTownMusic");
                        playMusic = true;
                    }


                    }
                    else
                    {
                    playMusic = false;
                    }

                }
            else if (Background.CurrentBackground == 1 || Background.CurrentBackground == 0
                  || Background.CurrentBackground == 4 || Background.CurrentBackground == 12
                   || Background.CurrentBackground == 27 || Background.CurrentBackground == 17
                    || Background.CurrentBackground == 7 || Background.CurrentBackground == 6
                     || Background.CurrentBackground == 37 || Background.CurrentBackground == 16
                      || Background.CurrentBackground == 26 || Background.CurrentBackground == 15
                       || Background.CurrentBackground == 5 || Background.CurrentBackground == 14
                        || Background.CurrentBackground == 24 || Background.CurrentBackground == 35
                         || Background.CurrentBackground == 44 || Background.CurrentBackground == 34
                          || Background.CurrentBackground == 13 || Background.CurrentBackground == 23
                           || Background.CurrentBackground == 25 || Background.CurrentBackground == 36
                           || Background.CurrentBackground == 45 || Background.CurrentBackground == 10
                           || Background.CurrentBackground == 11 || Background.CurrentBackground == 21)
            {
                if (backgroundMusic != game.Content.Load<Song>("AWalkintheScaryForest"))
                {

                    if (!playMusic)
                    {
                        backgroundMusic = game.Content.Load<Song>("AWalkintheScaryForest");
                        playMusic = true;
                    }


                }
                else
                {
                    playMusic = false;
                }

            }
            else if (Background.CurrentBackground == 30 || Background.CurrentBackground == 19
      || Background.CurrentBackground == 40 || Background.CurrentBackground == 29
       || Background.CurrentBackground == 48 || Background.CurrentBackground == 18
        || Background.CurrentBackground == 39 || Background.CurrentBackground == 28
         || Background.CurrentBackground == 37 || Background.CurrentBackground == 53
          || Background.CurrentBackground == 47 || Background.CurrentBackground == 38
           || Background.CurrentBackground == 33 || Background.CurrentBackground == 58
            || Background.CurrentBackground == 52 || Background.CurrentBackground == 46
             || Background.CurrentBackground == 42 || Background.CurrentBackground == 57
              || Background.CurrentBackground == 51 || Background.CurrentBackground == 50
               || Background.CurrentBackground == 62 || Background.CurrentBackground == 56
               || Background.CurrentBackground == 61)
            {
                if (backgroundMusic != game.Content.Load<Song>("WhatAreYouDoingInMySwamp"))
                {

                    if (!playMusic)
                    {
                        backgroundMusic = game.Content.Load<Song>("WhatAreYouDoingInMySwamp");
                        playMusic = true;
                    }


                }
                else
                {
                    playMusic = false;
                }

            }
            else if (Background.CurrentBackground == 22 || Background.CurrentBackground == 31
      || Background.CurrentBackground == 41 || Background.CurrentBackground == 49
       || Background.CurrentBackground == 55 || Background.CurrentBackground == 60
        || Background.CurrentBackground == 63 || Background.CurrentBackground == 64
         || Background.CurrentBackground == 65 || Background.CurrentBackground == 66
          || Background.CurrentBackground == 67)
            {
                if (backgroundMusic != game.Content.Load<Song>("MountainTrecking"))
                {

                    if (!playMusic)
                    {
                        backgroundMusic = game.Content.Load<Song>("MountainTrecking");
                        playMusic = true;
                    }


                }
                else
                {
                    playMusic = false;
                }

            }
            else if (Background.CurrentBackground == 68 || Background.CurrentBackground == 71
      || Background.CurrentBackground == 72 || Background.CurrentBackground == 73
       || Background.CurrentBackground == 74 || Background.CurrentBackground == 75
        || Background.CurrentBackground == 76 || Background.CurrentBackground == 77
         || Background.CurrentBackground == 78 || Background.CurrentBackground == 79
          || Background.CurrentBackground == 80 || Background.CurrentBackground == 81
           || Background.CurrentBackground == 82 || Background.CurrentBackground == 83
            || Background.CurrentBackground == 84 || Background.CurrentBackground == 85
             || Background.CurrentBackground == 86 || Background.CurrentBackground == 87
              || Background.CurrentBackground == 88)
            {
                if (backgroundMusic != game.Content.Load<Song>("TheLonelyTrumpeter"))
                {

                    if (!playMusic)
                    {
                        backgroundMusic = game.Content.Load<Song>("TheLonelyTrumpeter");
                        playMusic = true;
                    }


                }
                else
                {
                    playMusic = false;
                }

            }
            else if (Background.CurrentBackground == 54 || Background.CurrentBackground == 59
                || Background.CurrentBackground == 70 || Background.CurrentBackground == 43)
            {
                if (backgroundMusic != game.Content.Load<Song>("CaveJammin"))
                {

                    if (!playMusic)
                    {
                        backgroundMusic = game.Content.Load<Song>("CaveJammin");
                        playMusic = true;
                    }


                }
                else
                {
                    playMusic = false;
                }

            }
            else if (Background.CurrentBackground == 89)
            {
                if (backgroundMusic != game.Content.Load<Song>("KingBuomaugh"))
                {

                    if (!playMusic)
                    {
                        backgroundMusic = game.Content.Load<Song>("KingBuomaugh");
                        playMusic = true;
                    }


                }
                else
                {
                    playMusic = false;
                }

            }
            else if (Background.CurrentBackground == 90)
            {
                if (backgroundMusic != game.Content.Load<Song>("TheDragonintheSeaofGold"))
                {

                    if (!playMusic)
                    {
                        backgroundMusic = game.Content.Load<Song>("TheDragonintheSeaofGold");
                        playMusic = true;
                    }


                }
                else
                {
                    playMusic = false;
                }

            }
        }
           else
            {
                


                    if (backgroundMusic != game.Content.Load<Song>("deathTheme"))
                    {
                        if (!playMusic)
                        {
                            backgroundMusic = game.Content.Load<Song>("deathTheme");
                            playMusic = true;
                            isDead = true;
                        }

                    }
                    else
                    {
                        playMusic = false;
                    }
                
            }
            

            if (playMusic)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(backgroundMusic);
                if (!isDead)
                {
                    MediaPlayer.IsRepeating = true;
                }
            }

            previousBackground = Background.CurrentBackground;
            base.Update(gameTime);
        }
    }
}
