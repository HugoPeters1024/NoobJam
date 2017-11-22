using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NoobJam
{
    class Map
    {
        bool[,] map;
        Texture2D gridSprite;

        public Map(int width, int height)
        {
            gridSprite = AssetManager.LoadSprite("grid");
            map = new bool[width, height];
            for (int y = 0; y < map.GetLength(1); ++y)
                for (int x = 0; x < map.GetLength(0); ++x)
                    map[x, y] = true;
        }

        public void Draw(SpriteBatch batch)
        {
            for (int y = 0; y < map.GetLength(1); ++y)
            {
                for (int x = 0; x < map.GetLength(0); ++x)
                {
                    if (map[x,y])
                        batch.Draw(gridSprite, new Vector2(gridSize) * new Vector2(x, y), Color.Gray);
                }
            }

            for (int y = 0; y < map.GetLength(1) + 1; ++y)
                Operators.DrawLine(batch, new Vector2(0, gridSize * y), new Vector2(gridSize * map.GetLength(0), gridSize * y), Color.LightBlue * 0.25f);

            for (int x = 0; x < map.GetLength(0) + 1; ++x)
                Operators.DrawLine(batch, new Vector2(gridSize * x, 0), new Vector2(gridSize * x, map.GetLength(1) * gridSize), Color.LightBlue * 0.25f);
        }

        public bool Get(int x, int y)
        {
            if (x < 0 || x >= map.GetLength(0) || y < 0 || y >= map.GetLength(1))
                return true;
            return map[x, y];
        }

        public void Lock(int x, int y)
        {
            if (x < 0 || x >= map.GetLength(0) || y < 0 || y >= map.GetLength(1))
                return;
            map[x, y] = true;
        }

        public void Unlock(int x, int y)
        {
            if (x < 0 || x >= map.GetLength(0) || y < 0 || y >= map.GetLength(1))
                return;
            map[x, y] = false;
        }

        public int gridSize { get { return 32; } }
        public int Width { get { return map.GetLength(1); } }
        public int Height { get { return map.GetLength(0); } }
    }
}
