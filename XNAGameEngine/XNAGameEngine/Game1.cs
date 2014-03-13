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


// Test commit
// Test 2 commit

namespace XNAGameEngine
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GameInterface gameInterface;
        LinkedList<GameObject> TESTERS;

        public Game1()
        {
            gameInterface = new GameInterface(this);
            gameInterface.InitGraphicsDeviceManager();
            //Definition in FPS Notes
            IsFixedTimeStep = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            gameInterface.InitCollision();
            
            TESTERS = new LinkedList<GameObject>();

        }

        protected override void LoadContent()
        {
            gameInterface.LoadSpriteBatch();
            gameInterface.LoadGameInterface();

            //Definition of SynchronizeWithVerticalRetrace in FPS Notes
            gameInterface.graphicsDeviceManager.SynchronizeWithVerticalRetrace = true;
            //Must use this to apply changes to SynchronizeWithVerticalRetrace
            gameInterface.graphicsDeviceManager.ApplyChanges();
            
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
            for (int i = TESTERS.Count(); i < 2; i++)
                TESTERS.AddLast(new TestObject(gameInterface));

            CollisionManager.Check(TESTERS);

            foreach (GameObject tester in TESTERS)
                tester.Update(gameTime);

            //Input Logic
            if(gameInterface.inputManager["Esc"].IsDown)
                this.Exit();
            
            gameInterface.Update(gameTime);

            //Debugger
            Debug.PushBack(Mouse.GetState().X.ToString() + ", " +
                           Mouse.GetState().Y.ToString());

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            gameInterface.spriteBatch.Begin();
            // TODO: Add your drawing code here
            foreach (GameObject obj in TESTERS)
                obj.Draw();

            gameInterface.Draw();

            gameInterface.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
