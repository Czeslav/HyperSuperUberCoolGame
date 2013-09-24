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
    enum ParticleType { fire, none };

    class ParticleEngine
    {
        private List<ParticleSpot> SpotList;
        public int howManySpots;
        public int howManyParticles;


        public ParticleEngine()
        {
            SpotList = new List<ParticleSpot>();
        }

        public void AddSpot(Vector2 location, ParticleType type)
        {
            SpotList.Add(new ParticleSpot(location, type));
        }


        public void Update()
        {
            howManySpots = SpotList.Count;
            howManyParticles = 0;

            foreach (var spot in SpotList)
            {
                spot.Update();

                spot.AddParticle();

                howManyParticles += spot.partclesUsed;

                if (spot.dead)
                {
                    SpotList.Remove(spot);
                    return;
                }

                
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var spot in SpotList)
            {
                spot.Draw(spriteBatch);
            }
        }

    }
}
