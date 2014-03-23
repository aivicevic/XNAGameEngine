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
        private int _frameWidth, _frameHeight;
        private Rectangle _frameRect;
        private Vector2 _startFrame;
        private Vector2 _endFrame;
        private bool _continuouse;
        #endregion

        #region Public Accessors
        public Vector2 currentFrame { get { return _currentFrame; } set { _currentFrame = value; } }
        public Vector2 numFrames { get { return _numFrames; } set { _numFrames = value; } }
        public int switchFrame { get { return _switchFrame; } set { _switchFrame = value; } }
        public Rectangle frameRect { get { return _frameRect; } }
        public Vector2 getPivot { get { return new Vector2(_frameWidth/2, _frameHeight / 2); } }
        public int frameWidth { get { return _frameWidth; } }
        public int frameHeight { get { return _frameHeight; } }
        public Vector2 startFrame { get { return _startFrame; } set { _startFrame = value; } }
        public Vector2 endFrame { get { return _endFrame; } set { _endFrame = value; } }
        public bool continuouse { get { return _continuouse} set { _continuouse = value;} }
        #endregion

        #region Public Constructor
        public Animation(Vector2 numFrames, Vector2 startFrame, Vector2 endFrame, int rate, Sprite sprite, bool continuouse)
        {
            _frameWidth = sprite.sourceRect.Width / (int)numFrames.X;
            _frameHeight = sprite.sourceRect.Height / (int)numFrames.Y;
            _startFrame = new Vector2(1, 1);
            _currentFrame = _startFrame;
            _numFrames = numFrames;
            _switchFrame = rate;
            _frameCounter = 0;
            _SetRect();
            _continuouse = false;
        }
        #endregion

        public void Update(GameTime time, Sprite img)
        {
            _frameCounter += time.ElapsedGameTime.Milliseconds;
            if (_frameCounter > _switchFrame)
            {
                _frameCounter = 0;
                _NextFrame();
            }
            _SetRect();

        }

        #region Private Helper Functions
        private void _NextFrame()
        {
            if (_continuouse)
            {
                if (_currentFrame != _endFrame)
                {
                    _currentFrame.X++;
                    if (_currentFrame.X >= _numFrames.X)
                    {
                        _currentFrame.X = 0;
                        _currentFrame.Y++;
                        if (_currentFrame.Y >= _numFrames.Y)
                            _currentFrame.Y = 0;
                    }
                }
                else
                    _currentFrame = _startFrame;
            }
            else
            {
                if (_currentFrame != _endFrame)
                {
                    _currentFrame.X++;
                    if (_currentFrame.X >= _numFrames.X)
                    {
                        _currentFrame.X = 0;
                        _currentFrame.Y++;
                        if (_currentFrame.Y >= _numFrames.Y)
                            _currentFrame.Y = 0;
                    }
                }
            }
        }

        private void _SetRect()
        {
            _frameRect = new Rectangle();
            _frameRect.X = (int)_currentFrame.X * _frameWidth;
            _frameRect.Y = (int)_currentFrame.Y * _frameHeight;
            _frameRect.Width = _frameWidth;
            _frameRect.Height = _frameHeight;
        }
        #endregion


    }
}
