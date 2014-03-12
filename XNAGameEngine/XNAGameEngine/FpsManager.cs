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
        private Debug _debug;

        public FpsManager(Debug debug)
        {
            _debug = debug;
        }

         public void Update(GameTime gameTime)
        {
            // Update
            _elapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
 
            // 1 Second has passed (_totalFrames per second
            if (_elapsedTime >= 1000.0f)
            {
                _fps = _totalFrames;
                _totalFrames = 0;
                _elapsedTime = 0;
            }
        }

         public void Draw(GameTime gameTime)
         {
             
             _totalFrames++;
             _debug.PushBack(_fps.ToString(), 500, 15);          
         }


    }
}
