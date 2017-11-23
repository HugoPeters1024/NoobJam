using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NoobJam
{
    class Exit : SpriteObject
    {
        Player player;
        Level level;

        public Exit(Player player, Level level) : base(Vector2.Zero)
        {
            sprite = AssetManager.LoadSprite("exit");
            this.player = player;
            this.level = level;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if ((player.position - position).Length() < 32)
            {
                level.Manager.ChangeLevel("exit");
                level.Manager.scoreholder = player.score;
                level.Manager.ResetLevel("play");
            }
        }
    }
}
