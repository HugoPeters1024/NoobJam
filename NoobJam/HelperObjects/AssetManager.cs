using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace NoobJam {
    public static class AssetManager {
        public static ContentManager Manager;

        public static void Init(ContentManager manager) {
            Manager = manager;
        }
        
        public static Texture2D LoadSprite(string path) {
            return Manager.Load<Texture2D>("Sprites/" + path);
        }

        public static SpriteFont LoadFont(string path)
        {
            return Manager.Load<SpriteFont>("Fonts/" + path);
        }

        
    }
}
