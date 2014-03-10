using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace XNAGameEngine
{
    class GameInterface
    {
        private Game1 _game;

        public GraphicsDeviceManager graphicsDeviceManager;
        public SpriteBatch spriteBatch;
        public ContentManager Content{ get { return _game.Content; } }
        public Viewport viewport;
        public Random random;
        public CollisionManager collisionManager;

        public GameInterface(Game1 game)
        {
            random = new Random();
            _game = game;
            _game.Content.RootDirectory = "Content";
        }

        public void InitGraphicsDeviceManager()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(_game);
        }

        public void InitCollision()
        {
            collisionManager = new CollisionManager(true);
        }

        public void InitSpriteBatch()
        {
            spriteBatch = new SpriteBatch(_game.GraphicsDevice);
            viewport = graphicsDeviceManager.GraphicsDevice.Viewport;
        }

    }
}
