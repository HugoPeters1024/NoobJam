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
            Add(map = new Map(50, 27));
            camera = new Camera();
            Add(camera.follow = new Player(new Vector2(100), map));
        }
    }
}
