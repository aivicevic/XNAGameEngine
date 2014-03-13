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

        public static void Check(LinkedList<GameObject> LIST)
        {
            foreach(TestObject tester1 in LIST)
                foreach (TestObject tester2 in LIST)
                    if (tester1 != tester2)
                    {
                        float hitbox1 = tester1.hitbox.Width / 2;
                        float hitbox2 = tester2.hitbox.Width / 2;
                        float distance = Math.Abs(Vector2.Distance(tester1.position, tester2.position));

                        Debug.PopBack();
                        Debug.PushBack(distance.ToString("F"));


                        if (distance < hitbox1 + hitbox2)
                        {
                            float scaler = distance - (hitbox1 + hitbox2);
                            Vector2 vel1 = Vector2.Normalize(tester1.physics.vel);
                            Vector2 vel2 = Vector2.Normalize(tester2.physics.vel);

                            tester1.position += (vel1 * scaler);
                            tester2.position += (vel2 * scaler);

                            PhysicsManager.Collision(tester1, tester2);
                        }
                    }
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
