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
        private Texture2D _sprite;
        private GameObject _gameObject;
        #endregion

        #region Public Accessors
        public Vector2 currentFrame { get { return _currentFrame; } set { _currentFrame = value; } }
        public Vector2 numFrames { get { return _numFrames; } set { _numFrames = value; } }
        public int switchFrame { get { return _switchFrame; } set { _switchFrame = value; } }
        public int frameWidth { get { return _sprite.Width / (int)numFrames.X; } }
        public int frameHeight { get { return _sprite.Height / (int)numFrames.Y; } }
        #endregion

        #region Public Constructor
        public Animation(GameObject gameObject, Vector2 numFrames)
        {
            _gameObject = gameObject;
            _currentFrame = new Vector2(0, 0);
            _numFrames = numFrames;
            _frameCounter = 0;
        }
        #endregion

        public Rectangle AnimateFrame(int rate, Sprite img)
        {
            _switchFrame = rate;
            _frameCounter += _gameObject.gameTime.ElapsedGameTime.Milliseconds;
            if (_frameCounter > _switchFrame)
            {
                _frameCounter = 0;
                _NextFrame();
            }

            return new Rectangle((int)_currentFrame.X, (int)_currentFrame.Y,
                frameWidth, frameHeight);
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

        #endregion


    }
}
