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
        private SpriteFont _font;
        private static List<DebugLine> _WATCHLIST;

        private static int _lineNum = 1;

        public Debug(ContentManager content, SpriteBatch t_batch)
        {
            _batch = t_batch;
            _font = content.Load<SpriteFont>("Debug");
            _WATCHLIST = new List<DebugLine>();
        }

        public static void PushBack(string text, float x, float y)
        {
            string line = _lineNum + ": " + text;
            _WATCHLIST.Add(new DebugLine(line, x, y));
            _lineNum++;
        }

        public void Draw()
        {
            foreach (DebugLine line in _WATCHLIST)
                _batch.DrawString(_font, line.text, line.position, Color.LimeGreen);

            _WATCHLIST.Clear();
            _lineNum = 1;
        }
    }

    public class DebugLine
    {
        public string text;
        public Vector2 position;

        public DebugLine(string Text, float posx, float posy)
        {
            text = Text;
            position = new Vector2(posx, posy);
        }

        public DebugLine()
        {

        }
    }
}
