using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace XNAGameEngine
{
    class FpsManager
    {
        /*If _totalFrames++ is placed in:
         * Draw - measures sync between back buffer with refresh rate of monitor 
         * Update - measures the frequency of calls to Update
         */
        private int _totalFrames;
        private float _elapsedTime;
        private int _fps;
        private DebugLine _line;
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;


        public FpsManager(ContentManager content, SpriteBatch t_batch)
        {
            _spriteBatch = t_batch;
            _font = content.Load<SpriteFont>("Debug");
        }

         public void Update(GameTime gameTime)
        {
            // Update
            _elapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
 
            // 1 Second has passed 
            if (_elapsedTime >= 1000.0f)
            {
                _fps = _totalFrames;
                _totalFrames = 0;
                _elapsedTime = 0;
            }

            _line = new DebugLine("FPS: " + _fps, 5, 5);
        }

         public void Draw()
         {
             _totalFrames++;
             _spriteBatch.DrawString(_font, _line.text, _line.position, Color.LimeGreen);
         }


    }
}
