using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NoobJam
{
    class LevelExit : Level
    {
        Button menu;

        public LevelExit(LevelManager m) : base(m)
        {
            menu = new Button(new Vector2(400, 700), "Main Menu");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (menu.Clicked)
            {
                Manager.ChangeLevel("menu");
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            batch.DrawString(AssetManager.LoadFont("ButtonFont2"), "You scored " + Manager.scoreholder.ToString() + " point!", new Microsoft.Xna.Framework.Vector2(300, 300), Color.White);
        }
    }
}
