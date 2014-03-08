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
        GameInterface gameInterface;
        TestObject tester;
        List<TestObject> TESTERS;

        public Game1()
        {
            gameInterface = new GameInterface(this);
            gameInterface.InitGraphicsDeviceManager();
        }

        protected override void Initialize()
        {
            base.Initialize();
            TESTERS = new List<TestObject>();
        }

        protected override void LoadContent()
        {
            gameInterface.InitSpriteBatch();
            tester = new TestObject(gameInterface);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            for (int i = TESTERS.Count(); i < 5; i++)
                TESTERS.Add(new TestObject(gameInterface));

            tester.Update(gameTime);
            for (int i = 0; i < TESTERS.Count(); i++)
                TESTERS[i].Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            gameInterface.spriteBatch.Begin();
            // TODO: Add your drawing code here
            tester.Draw();
            for (int i = 0; i < TESTERS.Count(); i++)
                TESTERS[i].Draw();

            gameInterface.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
