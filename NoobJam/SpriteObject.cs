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
        protected Texture2D sprite;

        public SpriteObject(Vector2 startPosition) : base(startPosition) {}

        public SpriteObject(Vector2 startPosition, Texture2D sprite) : base(startPosition) {
            this.sprite = sprite;
        }

        public override void Draw(SpriteBatch batch, Camera cam)
        {
            batch.Draw(sprite, position, Color.White);
        }
    }
}
