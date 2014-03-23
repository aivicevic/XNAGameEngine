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
    public class GameMouse
    {
        public string _Name;
        private MouseState _mouse;
        private Sprite _sprite;
        private Animation _animation;
        public enum MouseButtons { Left, Right, Middle };
        private readonly IDictionary<MouseButtons, Func<MouseState, ButtonState>> _mouseButtonMaps;

        public GameMouse( GameInterface gi, string file)
        {
            _sprite = new Sprite(gi, file);
            _animation = new Animation(new Vector2(1, 1), 100, _sprite);
            _mouseButtonMaps = new Dictionary<MouseButtons, Func<MouseState, ButtonState>>
			{
				{ MouseButtons.Left, s => s.LeftButton },
				{ MouseButtons.Right, s => s.RightButton },
				{ MouseButtons.Middle, s => s.MiddleButton },
			};
        }

        public void Update(GameTime time)
        {
            _mouse = Mouse.GetState();
            _sprite.position = new Vector2(_mouse.X , _mouse.Y );
        }

        public void Draw()
        {
            _sprite.Draw();
        }


    }
}
