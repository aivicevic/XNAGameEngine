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
    public class GameStateManager
    {
         #region Variables

        // creating custom contentmanager
        ContentManager content;

        Screen currentScreen;
        Screen newScreen;

        SplashScreen first, second;
        MenuScreen menu, pause;
        GameScreen Level1, Level2;
        

        // Screenmanager instance
        private static GameStateManager instance;

        // Screen stack
        Stack<Screen> screenStack = new Stack<Screen>();

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

        public void AddScreen(Screen screen)
        {
            newScreen = screen;
            screenStack.Push(screen);
            currentScreen.UnloadContent();
            currentScreen = newScreen;
           // currentScreen.LoadContent(content);
        }

        public void Initialize()
        {
            currentScreen = first;
            currentScreen = new SplashScreen();
        }
        public void LoadContent(GameInterface gi)
        {
            content = new ContentManager(gi.Content.ServiceProvider, "Content");
           currentScreen.LoadContent(gi, "BackGround/Bg1", false);
        }
        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }
        public void Draw()
        {
            currentScreen.Draw();
        }
        #endregion

      

        private void DeleteSplash()
        {

        }
    }
}
