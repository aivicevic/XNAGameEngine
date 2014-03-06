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
        private Rectangle _dr;

        private Vector2 _position;
        
        public TestObject(GameObject gameObject)
        {
            _go = gameObject;
            _sprite = new Sprite(_go, "Assets/asteroid");
            _animation = new Animation(new Vector2(8, 4), _sprite);
            _position = new Vector2(200, 200);
        }

        public void Update(GameTime time)
        {
            _dr = _animation.AnimateFrame(300, time, _sprite);
            _sprite.SetRect(_dr);
        }

        public void Draw()
        {
            _sprite.Draw(_position);
        }

    }
}
