using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NoobJam
{
    class LevelEditor : Level
    {
        Map map;

        public LevelEditor(LevelManager m) : base(m)
        {
            Add(map = new Map(50, 32) { drawGrid = true });
            camera = new Camera(this);
            Add(new Player(new Vector2(32), map));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Input.MouseLeft)
            {
                Point index = Input.MousePos / new Point(map.gridSize);
                map.Unlock(index.X, index.Y);
            }

            if (Input.MouseRight)
            {
                Point index = Input.MousePos / new Point(map.gridSize);
                map.Lock(index.X, index.Y);
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }
    }
}
