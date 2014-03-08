using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace XNAGameEngine
{
    class TestObject : GameObject
    {
        public TestObject(GameInterface gi)
            : base(ref gi)
        {
            position = new Vector2(200, 200);
            InitSprite("Assets/asteroid");
            InitAnimation(new Vector2(8, 4), 30);
            InitPhysics();
            physics.position = new Vector2(
                (float)gi.random.Next(200), (float)gi.random.Next(200));
            physics.SetMotion(rand(), rand());
            InitCollision();
        }

        public override void Update(GameTime time)
        {
            base.Update(time);
        }

        private float rand()
        {
            return ((float)gi.random.Next(200) - 100) / 100;
        }
    }
}
