using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NoobJam
{
    class LevelEditor : Level
    {
        Map map;
        Player player;

        public LevelEditor(LevelManager m) : base(m)
        {
            Add(map = new Map(50, 32) { drawGrid = true });
            camera = new Camera(this);
            Add(player = new Player(new Vector2(32), map));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Input.MouseLeft)
            {
                Point index = Input.MousePos / new Point(map.gridSize);
                map.Unlock(index.X, index.Y);
            }

            if (Input.MouseMiddlePressed)
            {
                Point index = Input.MousePos / new Point(map.gridSize);
                map.holders.Add(new ItemHolder("laser") { position = new Vector2(index.X, index.Y)*32 + new Vector2(16) });
            }

            if (Input.MouseRight)
            {
                Point index = Input.MousePos / new Point(map.gridSize);
                map.Lock(index.X, index.Y);
            }

            if (Input.KeyDown(Keys.X))
                map.Save();

            if (Input.KeyDown(Keys.Z))
                map.Load(this, player);

            if (Input.KeyDown(Microsoft.Xna.Framework.Input.Keys.P))
                camera.position.Y++;
            if (Input.KeyDown(Microsoft.Xna.Framework.Input.Keys.O))
                camera.position.Y--;
        }
       


        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            foreach (ItemHolder h in map.holders)
                batch.Draw(AssetManager.LoadSprite("normalcoin"), h.position, Color.White);
        }
    }
}
