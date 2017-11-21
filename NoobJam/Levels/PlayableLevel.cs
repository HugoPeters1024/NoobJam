using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NoobJam {
    class PlayableLevel : Level {

        Player player;

        public PlayableLevel() {
            player = new Player(Vector2.Zero);
            objects.Add(this.player);

        }



    }
}
