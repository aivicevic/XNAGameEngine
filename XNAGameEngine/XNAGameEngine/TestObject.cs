using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace XNAGameEngine
{
    class TestObject
    {
        private Sprite _sprite;
        private Animation _animation;
        private GameObject _go;

        private Vector2 _position;
        
        public TestObject(GameObject gameObject)
        {
            _go = gameObject;
            _sprite = new Sprite(_go, "Assets/asteroid");
            _animation = new Animation(_go, new Vector2(8, 0));
            _position = new Vector2(100, 100);
        }

        public void Update()
        {
            _animation.AnimateFrame(30, _sprite);
        }

        public void Draw()
        {
            _sprite.Draw(_position);
        }

    }
}
