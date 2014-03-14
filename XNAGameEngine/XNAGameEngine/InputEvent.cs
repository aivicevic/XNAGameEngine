using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;
namespace XNAGameEngine
{
    class InputEvent
    {
        public string _Name;
        
        List<Keys> _KEYBOARD = new List<Keys>();
        InputManager _Im = null;
        bool _HeldPressed = false;
        bool _TapPressed = false;

        public bool IsDown { get { return _HeldPressed; } }
        public bool IsTapped { get { return (_HeldPressed) && (!_TapPressed); } }

        public InputEvent(InputManager im, string name)
        {
            _Im = im;
            _Name = name;
            
        }

        public void Add(Keys key)
        {
            if (!_KEYBOARD.Contains(key))
                _KEYBOARD.Add(key);
        }

        internal void Update(KeyboardState kbState)
        {
            _TapPressed = _HeldPressed;
            _HeldPressed = false;
          
            foreach (Keys k in _KEYBOARD)
                if (kbState.IsKeyDown(k))
                    _HeldPressed = true;
        }
    }
}
