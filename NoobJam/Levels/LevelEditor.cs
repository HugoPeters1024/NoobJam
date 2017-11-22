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
        Texture2D back;

        public LevelEditor(LevelManager m) : base(m)
        {
            Add(map = new Map(50, 32));
            back = AssetManager.LoadSprite("floor");
            camera = new Camera();
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
            for (int y = 0; y < 20; ++y)
                for (int x = 0; x < 20; ++x)
                    batch.Draw(back, new Vector2(x, y) * back.Bounds.Size.toVector(), Color.White);
            base.Draw(batch);
        }
    }
}
