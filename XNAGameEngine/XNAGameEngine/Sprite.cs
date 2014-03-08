using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace XNAGameEngine
{
    class Sprite
    {
        #region Private Properties
        private Texture2D _texture;
        private Rectangle _sourceRect;
        private Vector2 _position;
        private Color _tint;
        private float _rotation;
        private Vector2 _pivot;
        private Single _scale;
        private Single _layer;
        private GameInterface _gameInterface;
        #endregion 

        #region Public Accessors
        public Vector2 position { get { return _position; } set { _position = value; } }
        public float rotation { get { return _rotation; } set { _rotation = value; } }
        public Vector2 pivot { get { return _pivot; } set { _pivot = value; } }
        public Single scale { get { return _scale; } set { _scale = value; } }
        public Rectangle sourceRect { get { return _sourceRect; } set { _sourceRect = value; } }
        public Texture2D texture { get { return _texture; } }
        public Color tint { get { return _tint; } set { _tint = value; } }
        public Single layer { get { return _layer; } set { _layer = value; } }
        public int frameWidth { get { return _sourceRect.Width; } }
        public int frameHeight { get { return _sourceRect.Height; } }
        #endregion

        #region Public Constructor
        public Sprite(GameInterface gameInterface, string file)
        {
            _gameInterface = gameInterface;
            _texture = _gameInterface.Content.Load<Texture2D>(file);
            _position = new Vector2(0,0);
            _tint = Color.White;
            _rotation = 0;
            _scale = 1;
            _layer = 1;
            _pivot = new Vector2(_texture.Width / 2, _texture.Height / 2);
            _SetRect();
        }
        #endregion

        #region Private Helper Function
        private void _SetRect()
        {
            _sourceRect.X = 0;
            _sourceRect.Y = 0;
            _sourceRect.Width = _texture.Width;
            _sourceRect.Height = _texture.Height;
        }

        public void SetRect(Rectangle rect)
        {
            _sourceRect = rect;
        }
        #endregion

        public void Draw()
        {
            _gameInterface.spriteBatch.Draw(_texture, _position, _sourceRect, _tint, _rotation, _pivot, _scale, SpriteEffects.None, _layer);
        }
    }
}
