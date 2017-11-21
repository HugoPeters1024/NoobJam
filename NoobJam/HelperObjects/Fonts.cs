using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace NoobJam
{
    public static class Fonts
    {
        public static SpriteFont ButtonFont;
        
        public static void Init(ContentManager content)
        {
            ButtonFont = content.Load<SpriteFont>("ButtonFont");
        }
    }
}
