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
        Button startButton;

        public LevelMenu(LevelManager m) : base(m)
        {
            Add(startButton = new Button(new Vector2(100), "Start"));
        }

        public override void Update(GameTime gameTime)
        {
            if (startButton.Clicked)
                Manager.ChangeLevel("play");
                
            base.Update(gameTime);

        }
    }
}
