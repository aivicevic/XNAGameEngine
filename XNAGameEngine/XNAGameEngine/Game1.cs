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

namespace XNAGameEngine
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GameInterface gameManager;
        GameObject tester;
        List<GameObject> TESTERS;

        public Game1()
        {
            gameManager = new GameInterface(this);
            gameManager.InitGraphicsDeviceManager();
        }

        protected override void Initialize()
        {
            base.Initialize();
            TESTERS = new List<GameObject>();
        }

        protected override void LoadContent()
        {
            gameManager.InitSpriteBatch();
            tester = new GameObject(gameManager);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            for (int i = TESTERS.Count; i < 50; i++)
            {
                TESTERS.Add(new GameObject(gameManager));
            }


            // TODO: Add your update logic here
            tester.Update(gameTime);
            for (int i = 0; i < TESTERS.Count(); i++)
                TESTERS[i].Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            gameManager.spriteBatch.Begin();
            // TODO: Add your drawing code here
            tester.Draw();
            for (int i = 0; i < TESTERS.Count(); i++)
                TESTERS[i].Draw();
            gameManager.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
