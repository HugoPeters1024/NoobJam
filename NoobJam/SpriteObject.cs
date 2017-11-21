using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace NoobJam
{
    class SpriteObject : GameObject
    {
        public Texture2D sprite;

        public override void Draw(SpriteBatch batch, Camera cam)
        {
            batch.Draw(sprite, new Vector2(x, y), Color.White);
        }
    }
}
