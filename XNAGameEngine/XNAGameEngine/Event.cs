using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;
namespace XNAGameEngine
{
    class Event
    {
        public string _name;
        List<Keys> _KEYBOARD = new List<Keys>();
       
        InputManager _im = null;
        bool heldPressed = false;
        bool tapPressed = false;

        public bool IsDown { get { return heldPressed; } }
        public bool IsTapped { get { return (heldPressed) && (!tapPressed); } }

        public Event(InputManager im, string name)
        {
            _im = im;
            _name = name;
        }

        public void Add(Keys key)
        {
            if (!_KEYBOARD.Contains(key))
                _KEYBOARD.Add(key);
        }

        internal void Update(KeyboardState kbState)
        {
            tapPressed = heldPressed;
            heldPressed = false;
            foreach (Keys k in _KEYBOARD)
                if (kbState.IsKeyDown(k))
                    heldPressed = true;
        }
    }
}
