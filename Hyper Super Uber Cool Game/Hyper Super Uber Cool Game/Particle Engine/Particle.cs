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
    class Particle
    {
        public bool remove = false;

        private Texture2D texture;
        private Vector2 location;
        private Vector2 velocity;
        private float rotation = 0;
        private int alfa = 0;
        private bool alfaUp = true;


        public Particle(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            this.location = location;

            velocity = new Vector2(Globs.rand.Next(-5, 5) / 15.0f, Globs.rand.Next(-5, 5) / 15.0f);
        }
 

        public void Update()
        {
            rotation += 0.05f;

            location += velocity;

            #region alfa
            if (alfaUp)
            {
                alfa += 7;
            }
            else
            {
                alfa -= 7;
            }

            if (alfa>230)
            {
                alfaUp = false;
            }
            else if (!alfaUp && alfa < 10)
            {
                remove = true;
            }
            #endregion
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle rec = new Rectangle((int)location.X - texture.Width / 2, (int)location.Y - texture.Height / 2, 30, 30);

            spriteBatch.Draw(texture, rec, null, Color.FromNonPremultiplied(255, 255, 255, alfa), rotation, new Vector2(texture.Width / 2.0f, texture.Height / 2.0f), SpriteEffects.None, 1);
        }
    }
}
