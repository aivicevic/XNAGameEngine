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

        private Vector2 _position;
        
        public TestObject(GameObject go)
        {
            _sprite = new Sprite(go, "Assets/asteroid");
            _animation = new Animation(new Vector2(8, 4), 30, _sprite);
            _position = new Vector2(200, 200);
        }

        public void Update(GameTime time)
        {
            _animation.AnimateFrame(time, _sprite);
            _sprite.SetRect(_animation.frameRect);
            _sprite.position = _position;
            _sprite.pivot = _animation.getPivot;
            _sprite.rotation = _sprite.rotation += .01f;
        }

        public void Draw()
        {
            _sprite.Draw();
        }

    }
}
