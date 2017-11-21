using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace NoobJam {
    public class AssetManager {
        public ContentManager Manager;

        public AssetManager(ContentManager manager) {
            Manager = manager;
        }


        public Texture2D LoadSprite(string path) {
            return Manager.Load<Texture2D>("Sprites/" + path);
        }

        
    }
}
