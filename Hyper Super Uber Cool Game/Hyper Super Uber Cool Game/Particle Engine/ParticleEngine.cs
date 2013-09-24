using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Hyper_Super_Uber_Cool_Game
{
    enum ParticleType { fire, ice };

    class ParticleEngine
    {
        //private List<ParticleSpot> SpotList;
        private ParticleSpot[] SpotList;
        private int spotListIndex = 0;

        public int howManySpots;
        public int howManyParticles;

        //private StreamWriter writer;


        public ParticleEngine()
        {
            //SpotList = new List<ParticleSpot>();
            SpotList = new ParticleSpot[255];
        }

        public void AddSpot(Vector2 location, ParticleType type)
        {
            SpotList[spotListIndex] = new ParticleSpot(location, type);
            spotListIndex++;
            if (spotListIndex>=255)
            {
                spotListIndex = 0;
            }
        }


        public void Update()
        {
            howManySpots = spotListIndex;
            howManyParticles = 0;

            //foreach (var spot in SpotList)
            for (int i = 0; i < SpotList.Length; i++)
            {
                if (SpotList[i]==null)
                {
                    break;
                }

                SpotList[i].Update();

                SpotList[i].AddParticle();

                howManyParticles += SpotList[i].partclesUsed;

                /*if (SpotList[i].dead)
                {
                    //SpotList.Remove(spot);

                    return;
                }*/
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var spot in SpotList)
            {
                if (spot == null)
                {
                    return;
                }
                spot.Draw(spriteBatch);
            }
        }

    }
}
