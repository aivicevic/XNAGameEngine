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
    class GameInterface
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

        public void InitGraphicsDeviceManager() { graphicsDeviceManager = new GraphicsDeviceManager(_game); }
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

        void AddInput()
        {
            inputManager.AddEvent("Esc");           //Add name of event
            inputManager["Esc"].Add(Keys.Escape);   //Add corresponding key
            // Add game logic in Game1 (will be changing this obviously)
            
        }

    }
}
