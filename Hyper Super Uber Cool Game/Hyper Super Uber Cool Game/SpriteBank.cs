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
    static class SpriteBank
    {
        public static Texture2D particle_flame;


        public static void Load(ContentManager Content)
        {
            particle_flame = Content.Load<Texture2D>("particle_fire");
        }
    }
}
