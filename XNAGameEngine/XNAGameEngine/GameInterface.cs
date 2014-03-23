using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace XNAGameEngine
{
    public class GameInterface
    {
        private Game1 _game;

        public GraphicsDeviceManager graphicsDeviceManager;
        public SpriteBatch spriteBatch;
        public ContentManager Content { get { return _game.Content; } }
        public Viewport viewport;
        public Random random;
        public CollisionManager collisionManager;
        
        public Debug debug;
        public FpsManager fps;
        public InputManager inputManager;

        public GameInterface(Game1 game)
        {
            random = new Random();
            _game = game;
            _game.Content.RootDirectory = "Content";
        }

        public void InitGraphicsDeviceManager() 
        { 
            graphicsDeviceManager = new GraphicsDeviceManager(_game);
            graphicsDeviceManager.PreferredBackBufferHeight = 900;
            graphicsDeviceManager.PreferredBackBufferWidth = 1200;
        }
        public void InitCollision() { collisionManager = new CollisionManager(); }

        public void LoadGameInterface()
        {
            
            inputManager = new InputManager(this);
            AddInput();
            debug = new Debug(Content, spriteBatch);
            fps = new FpsManager(Content, spriteBatch);
        }

        public void LoadSpriteBatch()
        {
            spriteBatch = new SpriteBatch(_game.GraphicsDevice);
            viewport = graphicsDeviceManager.GraphicsDevice.Viewport;
        }

        public void Update(GameTime gameTime)
        {
            
            inputManager.Update(gameTime);
            fps.Update(gameTime);
        }

        public void Draw()
        {
            inputManager.Draw();
            debug.Draw();
            fps.Draw();
        }

        private void AddInput()
        {   //Event Name                    //Corresponding Key
            inputManager.AddEvent("Quit");  inputManager["Quit"].Add(Keys.Escape);
            inputManager.AddEvent("Menu");  inputManager["Menu"].Add(Keys.M);
            inputManager.AddEvent("Pause"); inputManager["Pause"].Add(Keys.P);
            inputManager.AddEvent("Left");  inputManager["Left"].Add(Keys.A);
            inputManager.AddEvent("Right"); inputManager["Right"].Add(Keys.D);
            inputManager.AddEvent("Up");    inputManager["Up"].Add(Keys.W);
            inputManager.AddEvent("Down");  inputManager["Down"].Add(Keys.S);
        }

    }
}
