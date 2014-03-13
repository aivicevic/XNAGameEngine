using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace XNAGameEngine
{
    class GameMouse : GameObject
    {

        /*
         * Several things to note:
         * 1. Mouse requires to freely update its position without dependency.
         * The base.Update resets the position if Physics is activated. 
         * 2. wallIsLocked must be false otherwise it will pull Physics info
         * which is is null (because of note 1)
         * 3. Collision is dependent on Physics info, so collision is not
         * implemented with this object.
         */

        private MouseState mouse;
        public MouseState getMouse { get { return mouse; } set { mouse = value; } }

        public GameMouse(GameInterface gi, string file)
            : base(ref gi)
        {
            mouse = new MouseState();
            wallIsLocked = false;                   
            InitSprite(file);
            InitAnimation(new Vector2(1, 1), 100);        
            InitCollision();
        }

        public override void Update(GameTime time)
        {
            mouse = Mouse.GetState();
            position = new Vector2(mouse.X , mouse.Y );
            base.Update(time);
        }


    }
}
