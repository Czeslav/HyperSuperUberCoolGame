using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using FarseerPhysics.Collision;
using FarseerPhysics.Common;
using FarseerPhysics.Controllers;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;


namespace Hyper_Super_Uber_Cool_Game
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont debugFont;
        ParticleEngine particleEngine;

        MouseState currentMouse;
        MouseState prevMouse;


        public Game1()
        {
            this.IsMouseVisible = true;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
        }

       



        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteBank.Load(Content);

            debugFont = Content.Load<SpriteFont>("debug");

            particleEngine = new ParticleEngine();
        }

        



        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            particleEngine.Update();

            currentMouse = Mouse.GetState();

            if (currentMouse.LeftButton == ButtonState.Pressed)
            {
                particleEngine.AddSpot(new Vector2(currentMouse.X, currentMouse.Y), ParticleType.fire);
            }



            prevMouse = currentMouse;

            base.Update(gameTime);
        }

        




        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            particleEngine.Draw(spriteBatch);

            spriteBatch.DrawString(debugFont, "Spots = " + particleEngine.howManySpots.ToString() + "\nParticles = " + particleEngine.howManyParticles.ToString(), new Vector2(20, 20), Color.White);

            spriteBatch.End();


            

            base.Draw(gameTime);
        }
    }
}
