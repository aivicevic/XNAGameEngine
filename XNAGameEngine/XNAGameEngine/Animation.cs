using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace XNAGameEngine
{
    class Animation
    {
        #region Private Properties
        private Vector2 _currentFrame;
        private Vector2 _numFrames;
        private int _frameCounter;
        private int _switchFrame;
        private Sprite _sprite;
        private Rectangle _dr;
        #endregion

        #region Public Accessors
        public Vector2 currentFrame { get { return _currentFrame; } set { _currentFrame = value; } }
        public Vector2 numFrames { get { return _numFrames; } set { _numFrames = value; } }
        public int switchFrame { get { return _switchFrame; } set { _switchFrame = value; } }
        public int frameWidth { get { return _sprite.texture.Width / (int)numFrames.X; } }
        public int frameHeight { get { return _sprite.texture.Height / (int)numFrames.Y; } }
        #endregion

        #region Public Constructor
        public Animation(Vector2 numFrames, Sprite sprite)
        {
            _sprite = sprite;
            _currentFrame = new Vector2(0, 0);
            _numFrames = numFrames;
            _frameCounter = 0;
        }
        #endregion

        public Rectangle AnimateFrame(int rate, GameTime time, Sprite img)
        {
            _switchFrame = rate;
            _frameCounter += time.ElapsedGameTime.Milliseconds;
            if (_frameCounter > _switchFrame)
            {
                _frameCounter = 0;
                _NextFrame();
            }

            return _GetFrame();
        }


        #region Private Helper Functions
        private void _NextFrame()
        {
            _currentFrame.X++;
            if (_currentFrame.X > _numFrames.X)
            {
                _currentFrame.X = 0;
                if (_currentFrame.Y > _numFrames.Y)
                    _currentFrame.Y = 0;
            }
        }

        private Rectangle _GetFrame()
        {
            Rectangle t = new Rectangle();
            t.X = (frameWidth * (int)_currentFrame.X);
            t.Y = (frameHeight * (int)_currentFrame.Y);
            t.Width = t.X + frameWidth;
            t.Height = t.Y + frameHeight;
            return t;
        }

        #endregion


    }
}
