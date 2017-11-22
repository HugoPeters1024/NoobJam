using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NoobJam {
    class PlayableLevel : Level {

        Player player;
        Map map;

        public PlayableLevel(LevelManager m) : base(m) {
            map = new Map(50, 27);
            player = new Player(Vector2.Zero, map);
            objects.Add(this.player);
        }
    }
}
