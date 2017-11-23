using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NoobJam
{
    class Collectable : SpriteObject
    {
        int tick = 0;
        Player player;

        public Collectable(Player player) : base(Vector2.Zero)
        {
            sprite = AssetManager.LoadSprite("bonuscoin");
            this.player = player;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            position.Y += (float)Math.Sin(tick++ / 10f) * 0.15f;
            if ((player.position - position).Length() < 32)
            {
                Kill = true;
                player.score += 100;
            }
        }
    }
}
