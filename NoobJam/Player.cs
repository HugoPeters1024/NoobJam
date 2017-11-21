using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace NoobJam {
    class Player : SpriteObject {
        public Player(Vector2 startPosition) : base(startPosition) {
            this.sprite = AssetManager.LoadSprite("player");
        }

        public override void Draw(SpriteBatch batch, Camera cam) {
            base.Draw(batch, cam);

        }

        public override void Update() {
            base.Update();
        }
    }
}
