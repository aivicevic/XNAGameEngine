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
        private bool _online;

        public CollisionManager(bool value)
        {
            _online = true;
        }

        public bool CheckDistanceCollision(GameObject o1, GameObject o2)
        {
            Vector2 d1 = o1.position - o2.position;
            if (d1.Length() <= o1.hitBox)
                return true;
            else
                return false;

        }
    }
}
