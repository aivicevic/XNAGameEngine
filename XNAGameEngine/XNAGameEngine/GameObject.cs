using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace XNAGameEngine
{
    class GameObject
    {
        public Game1 _game;

        public GraphicsDeviceManager graphicsDeviceManager;
        public SpriteBatch spriteBatch;
        public GameTime gameTime;
        public ContentManager Content{ get { return _game.Content; } }

        public GameObject(Game1 game)
        {
            _game = game;
            _game.Content.RootDirectory = "Content";
        }

        public void InitGraphicsDeviceManager()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(_game);
        }

        public void InitSpriteBatch()
        {
            spriteBatch = new SpriteBatch(_game.GraphicsDevice);
        }
    }

}
