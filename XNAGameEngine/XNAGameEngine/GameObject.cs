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
        private CollisionManager _collision;
        private Vector2 _position;
        private bool _ViewportWallsLocked = true;

        public PhysicsManager physics { get { return _physics; } set { _physics = value; } }
        public Vector2 position { get { return _position; } set { _position = value; } }
        public float rotation { get { return _sprite.rotation; } set { _sprite.rotation = value; } }
        public GameInterface gi { get { return _gi; } }

        public GameObject(ref GameInterface gi)
        {
            _gi = gi;
        }

        #region Initalize Objects
        public void InitSprite(string file)
        {
            _sprite = new Sprite(_gi, file);
        }

        public void InitAnimation(Vector2 size, int rate)
        {
            _animation = new Animation(size, rate, _sprite);
        }

        public void InitPhysics()
        {
            _physics = new PhysicsManager(_position);
        }

        public void InitCollision()
        {
            Rectangle r;
            if (_animation != null)
                r = new Rectangle((int)_position.X, (int)_position.Y,
                    _animation.frameWidth, _animation.frameHeight);
            else
                r = new Rectangle((int)_position.X, (int)_position.Y,
                    _sprite.frameWidth, _sprite.frameHeight);

            _collision = new CollisionManager(r);
        }
        #endregion

        public virtual void Update(GameTime time)
        {
            if (_animation != null)
            {
                _animation.Update(time, _sprite);
                _sprite.SetRect(_animation.frameRect);
                _sprite.pivot = _animation.getPivot;
            }
            if (_collision != null)
            {
                if (_collision.Update())
                {
                    _physics.mosionVector = _physics.mosionVector * -1;
                }

            }

            if (_physics != null)
            {
                _physics.Update();
                _position = _physics.position;
            }
            if (_sprite != null)
            {
                _sprite.position = _position;
            }
            if (_ViewportWallsLocked)
                _NoEscape();
        }

        private void _NoEscape()
        {
            if (_position.X >= _gi.viewport.Width || _position.X <= 0)
                _physics.mosionVector = new Vector2(_physics.mosionVector.X * -1, _physics.mosionVector.Y);
            else if (_position.Y >= _gi.viewport.Height || _position.Y <= 0)
                _physics.mosionVector = new Vector2(_physics.mosionVector.X, _physics.mosionVector.Y * -1);
        }

        public void LockViewportWalls()
        {
            _ViewportWallsLocked = true;
        }

        public void UnlockViewportWalls()
        {
            _ViewportWallsLocked = false;
        }

        public void Draw()
        {
            _sprite.Draw();
        }


    }

}
