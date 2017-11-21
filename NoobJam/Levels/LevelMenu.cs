using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NoobJam
{
    class LevelMenu : Level
    {
        public LevelMenu()
        {
            Add(new Button(new Vector2(100), "Start"));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
