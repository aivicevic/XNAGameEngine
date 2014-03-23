using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNAGameEngine
{
    class Background 
    {
        // Private members
        private Vector2 size;
        private Sprite _sprite;
        // System objects

        public Sprite sprite { get { return _sprite; }
                                 set { _sprite = value; } }
        // Accesser's
        public Vector2 Size { get { return size; } set { size = value; } }

        public Background(GameInterface gi,  string file)
           
        {
            _sprite = new Sprite(gi, file);
            _sprite.layer = 0.0f;
            size = new Vector2(_sprite.texture.Width * 20,_sprite.texture.Height * 20);
        }

        public void BGDraw(SpriteBatch t_batch)
        {
            // for (int i = -Texture.Width * 20; i < Texture.Width * 20; )
            // {
            //     for (int j = -Texture.Height * 15; j < Texture.Height * 15; )
            //     {
            t_batch.Draw(_sprite.texture, _sprite.position,
                _sprite.sourceRect, _sprite.tint, _sprite.rotation, _sprite.pivot,
                _sprite.scale, SpriteEffects.None, 0);
            //         j += Texture.Height;
            //     }
            //     i += Texture.Width;
            // }
        }

    }
}
