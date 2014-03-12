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

        public List<CollisionEvent> Check(LinkedList<GameObject> LIST)
        {
            List<CollisionEvent> IDX = new List<CollisionEvent>();

            foreach (GameObject obj1 in LIST)
                foreach (GameObject obj2 in LIST)
                    if (!obj1.Equals(obj2))
                        if (obj1.hitbox.Intersects(obj2.hitbox))
                        {
                            obj1.physics.pos -= obj1.physics.vel;
                            obj2.physics.pos -= obj2.physics.vel;
                            IDX.Add(new CollisionEvent(obj1, obj2));
                        }

            return IDX;
        }
    }

    class CollisionEvent
    {
        public GameObject object1;
        public GameObject object2;

        public CollisionEvent(GameObject obj1, GameObject obj2)
        {
            object1 = obj1;
            object2 = obj2;
        }
    }


}
