using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;

namespace XNAGameEngine
{
    class SplashScreen : Screen
    {
        Background background;
        float time = 0;

   

        public override void LoadContent(GameInterface gi, String fileName, bool pauseScreen)
        {
            PopUp = pauseScreen;
            _gameInterface = gi;
            background = new Background(gi, fileName);
            background.sprite.position = new Vector2(600, 450);
            background.sprite.scale = 1.0f;
        }

        public override void UnloadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (time >= 10)
                GameStateManager.Instance.AddScreen(this);

        }

        public override void Draw()
        {
            background.BGDraw(_gameInterface.spriteBatch);
        }
    }
}
