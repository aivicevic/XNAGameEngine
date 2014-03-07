using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace XNAGameEngine
{
    class PhysicsManager
    {
        private Vector2 _position;
        private Vector2 _motionVector;

        public Vector2 position { get { return _position; } }
        public Vector2 mostionVector { get { return _motionVector; } set { _motionVector = value; } }

        public PhysicsManager(Vector2 position, Vector2 initMotion) 
        {
            _motionVector = initMotion;
            _position = position;
        }
        public void Update()
        {
            _position = _position + _motionVector;
        }




    }
}
