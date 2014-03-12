using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace XNAGameEngine
{
    public class Debug
    {
        private SpriteBatch _batch;
        private List<Vector2> _POSITION;
        private List<string> _RENAME;
        private SpriteFont _font;

        public List<Vector2> position { get { return _POSITION; } }

        public Debug(ContentManager content, SpriteBatch t_batch)
        {
            _batch = t_batch;
            _POSITION = new List<Vector2>();
            _font = content.Load<SpriteFont>("Debug");
            _RENAME = new List<string>();
        }

        public void PushBack(string text, float x, float y)
        {
            _RENAME.Add(text);
            _POSITION.Add(new Vector2(x, y));
        }

        public void Draw()
        {
            for (int i = 0; i < _RENAME.Count; i++)
            {
                _batch.DrawString(_font, (i + 1) + ": " + _RENAME[i], _POSITION[i], Color.LimeGreen);
                _batch.DrawString(_font, (i + 1) + ": " + _RENAME[i], _POSITION[i], Color.Black, 0f, Vector2.Zero, 1, SpriteEffects.None, .99f);
            }

            _RENAME.Clear();
            _POSITION.Clear();
        }
    }
}
