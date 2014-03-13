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
    class GameMouse
    {
       

        private MouseState _mouse;
        private Sprite _sprite;
        private Animation _animation;

        public MouseState getMouse { get { return _mouse; } set { _mouse = value; } }

        public GameMouse(GameInterface gi, string file)
        {
            _sprite = new Sprite(gi, file);
            _animation = new Animation(new Vector2(1, 1), 100, _sprite);   
           
        }

        public void Update(GameTime time)
        {
            _mouse = Mouse.GetState();
            _sprite.position = new Vector2(_mouse.X , _mouse.Y );
        }

        public Vector2 CurrentPosition()
        {
            return _sprite.position;
        }

        public void Draw()
        {
            _sprite.Draw();
        }


    }
}
