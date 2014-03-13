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
     class InputManager
    {
        private List<Event> _EVENT;
        private GameMouse _mouse;
        
        public Event this[string eventName]
        { 
            get
            { 
                    return _EVENT.Find((Event a)=>{return a._name == eventName;});
            }
        }
        public InputManager(GameInterface gi)
        {
            _mouse = new GameMouse(gi, "Assets/Ship");
            _EVENT = new List<Event>();
        }
        
        public void AddEvent (string eventName)
        {
            _EVENT.Add(new Event(this, eventName));
        }

        public void Draw()
        {
            _mouse.Draw();
        }
        public void Update(GameTime gameTime)
        {
            KeyboardState kbState = Keyboard.GetState();
            Mouse.GetState();

            foreach (Event a in _EVENT)
                a.Update(kbState);

            _mouse.Update(gameTime);
        }

        
    }
}
