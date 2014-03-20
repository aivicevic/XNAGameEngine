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
        private List<InputEvent> _EVENT;
        public  GameMouse _mouse;

        public InputEvent this[string eventName]
        { 
            get
            { 
                    return _EVENT.Find((InputEvent a)=>{return a._Name == eventName;});
            }
        }
      
        public InputManager(GameInterface gi)
        {
            _mouse = new GameMouse(gi, "Assets/harpoon mouse");
            _EVENT = new List<InputEvent>();
        }
       
        public void AddEvent (string eventName)
        {
            _EVENT.Add(new InputEvent(this, eventName));
        }      

        public void Draw()
        {
            _mouse.Draw();
        }
        public void Update(GameTime gameTime)
        {
            KeyboardState kbState = Keyboard.GetState();
            MouseState mState = Mouse.GetState();

            foreach (InputEvent a in _EVENT)
                a.Update(kbState);

            _mouse.Update(gameTime);
        }
       
    }
}
