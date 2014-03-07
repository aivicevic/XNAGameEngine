using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace XNAGameEngine
{
    class GameObject
    {
        private Sprite _sprite;
        private Animation _animation;
        private PhysicsManager _physics;
        private GameInterface _gi;
        private Vector2 _position;

        public GameObject(GameInterface gi)
        {
            _gi = gi;
            _sprite = new Sprite(gi, "Assets/asteroid");
            _animation = new Animation(new Vector2(8, 4), 30, _sprite);
            _animation.currentFrame = new Vector2(_gi.random.Next(0, 7), _gi.random.Next(0, 3));
            _position = new Vector2(_gi.random.Next(800), _gi.random.Next(600));
            _physics = new PhysicsManager(_position, 
                new Vector2(_Rand(), _Rand()));
        }

        public void Update(GameTime time)
        {
            _physics.Update();
            _position = _physics.position;
            _animation.AnimateFrame(time, _sprite);
            _sprite.SetRect(_animation.frameRect);
            _sprite.position = _position;
            _sprite.pivot = _animation.getPivot;
            _sprite.rotation = _sprite.rotation += .01f;

            if (_position.X >= _gi.viewport.Width || _position.X <= 0)
                _physics.mostionVector = new Vector2(_physics.mostionVector.X * -1, _physics.mostionVector.Y);
            else if (_position.Y >= _gi.viewport.Height || _position.Y <= 0)
                _physics.mostionVector = new Vector2(_physics.mostionVector.X, _physics.mostionVector.Y * -1);
        }

        private float _Rand()
        {
            float r = ((float)_gi.random.Next(0,200) - 100) / 100;
            return r;
        }

        public void Draw()
        {
            _sprite.Draw();
        }


    }

}
