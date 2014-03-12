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
        }

        protected override void Initialize()
        {
            base.Initialize();
            gameInterface.InitCollision();
            TESTERS = new LinkedList<GameObject>();

        }

        protected override void LoadContent()
        {
            gameInterface.InitSpriteBatch();
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
            for (int i = TESTERS.Count(); i < 10; i++)
                TESTERS.AddLast(new TestObject(gameInterface));

            foreach (CollisionEvent Event in gameInterface.collisionManager.Check(TESTERS))
                if (Event != null)
                    PhysicsManager.Collision(Event.object1, Event.object2);


            foreach (GameObject tester in TESTERS)
                tester.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            gameInterface.spriteBatch.Begin();
            // TODO: Add your drawing code here
            foreach (GameObject obj in TESTERS)
                obj.Draw();

            gameInterface.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
