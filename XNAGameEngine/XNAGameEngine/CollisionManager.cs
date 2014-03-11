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
        private LinkedList<GameObject> _KILLBOX;

        public CollisionManager()
        {
            _KILLBOX = new LinkedList<GameObject>();
        }

        public void Push(GameObject obj) { _KILLBOX.AddLast(obj); }
        public void Remove(GameObject obj) { _KILLBOX.Remove(obj); }

        public LinkedList<GameObject> RunCollision(LinkedList<GameObject> LIST)
        {
            List<GameObject> IDX = new List<GameObject>();

            foreach (GameObject obj1 in LIST)
                foreach (GameObject obj2 in LIST)
                    if (!obj1.Equals(obj2))
                        if (obj1.hitbox.Intersects(obj2.hitbox))
                        {
                            IDX.Add(obj1);
                            break;
                        }
                            

            foreach (GameObject obj in IDX)
                LIST.Remove(obj);

            return LIST;
        }

    }
}
