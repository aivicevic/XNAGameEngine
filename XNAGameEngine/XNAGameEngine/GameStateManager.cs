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

namespace XNAGameEngine
{
    class GameStateManager
    {
         #region Variables

        // creating custom contentmanager
        ContentManager content;

        GameScreen currentScreen;

        GameScreen newScreen;

        // Screenmanager instance
        private static GameStateManager instance;

        // Screen stack
        Stack<GameScreen> screenStack = new Stack<GameScreen>();

        // screens width and height
        Vector2 dimensions;

        #endregion

        #region Properties

        public static GameStateManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameStateManager();
                return instance;
            }
        }

        public Vector2 Dimensions
        {
            get { return dimensions; }
            set { dimensions = value; }
        }

        #endregion

        #region Main Methods

        public void AddScreen(GameScreen screen)
        {
            newScreen = screen;
            screenStack.Push(screen);
            currentScreen.UnloadContent();
            currentScreen = newScreen;
           // currentScreen.LoadContent(content);
        }

        public void Initialize()
        {
           // currentScreen = new SplashScreen();
        }
        public void LoadContent(ContentManager Content)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            //currentScreen.LoadContent(Content);
        }
        public void Update(GameTime gameTime)
        {
            //currentScreen.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //currentScreen.Draw(spriteBatch);
        }

        #endregion
    }
}
