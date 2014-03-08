using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace XNAGameEngine
{
    class CollisionManager
    {
        private static List<Rectangle> QUADTREE = new List<Rectangle>();

        private Rectangle _hitBox;
        public Rectangle hitBox { get { return _hitBox; } }
        private void _RegisterHitBox(Rectangle r) { _hitBox = r; }

        public CollisionManager(Rectangle collisionRect)
        {
            _RegisterHitBox(collisionRect);
            QUADTREE.Add(_hitBox);
        }
        public bool BoxCollision(Rectangle obj)
        {
            if (_hitBox.Intersects(obj))
                return true;
            else
                return false;
        }

        public bool DistanceCollision(Rectangle obj)
        {
            Vector2 d1 = _ToV2(_hitBox.Center) - _ToV2(obj.Center);
            if (d1.Length() <= _hitBox.Width + obj.Width)
                return true;
            else
                return false;
        }
        public bool Update()
        {
            for (int i = 0; i <= QUADTREE.Count(); i++)
                return (BoxCollision(QUADTREE[i]));
            return false;
        }
        private Vector2 _ToV2(Point p) { return new Vector2(p.X, p.Y); }
    }
}
