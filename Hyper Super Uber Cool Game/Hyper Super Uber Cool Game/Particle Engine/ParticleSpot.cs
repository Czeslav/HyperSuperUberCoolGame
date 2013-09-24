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
    class ParticleSpot
    {
        private Vector2 location;
        private ParticleType type;
        private int radius =5;
        private int maxNumberOfParticles = 10;
        public int partclesUsed = 0;
        private List<Particle> particles;

        public bool dead = false; 

        public ParticleSpot(Vector2 location, ParticleType type)
        {
            this.location = location;
            this.type = type;
            particles = new List<Particle>();
        }        

        public void AddParticle()
        {
            if (particles.Count == 0 && partclesUsed == maxNumberOfParticles)
            {
                dead = true;
            }

            if (partclesUsed < maxNumberOfParticles)
            {
                
                Vector2 partLoc = new Vector2();
                partLoc.X = location.X + Globs.rand.Next(-radius, radius);
                partLoc.Y = location.Y + Globs.rand.Next(-radius, radius);

                particles.Add(new Particle(type, partLoc));
                partclesUsed++;
            }
            else
            {
                return;
            }
        }

        public void Update()
        {
            foreach (var particle in particles)
            {
                particle.Update();
                if (particle.remove)
                {
                    particles.Remove(particle);
                    return;
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            foreach (var item in particles)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
