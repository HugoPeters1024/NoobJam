using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NoobJam
{
    class Map : GameObject
    {
        bool[,] map;
        Texture2D gridSprite;
        Texture2D wall, wallcorner;
        Texture2D back;
        public bool drawGrid;
        public List<ItemHolder> holders;

        public Map(int width, int height)
        {
            gridSprite = AssetManager.LoadSprite("grid");
            wall = AssetManager.LoadSprite("wall");
            wallcorner = AssetManager.LoadSprite("wallcorner");
            back = AssetManager.LoadSprite("floor");
            holders = new List<ItemHolder>();
            map = new bool[width, height];
            for (int y = 0; y < map.GetLength(1); ++y)
                for (int x = 0; x < map.GetLength(0); ++x)
                    map[x, y] = true;
        }

        public override void Draw(SpriteBatch batch)
        {
            for (int y = 0; y < Height; y+=2)
                for (int x = 0; x < Width; x+=2)
                    batch.Draw(back, new Vector2(x, y)/2f * back.Bounds.Size.toVector(), Color.White);

            for (int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    if (map[x,y])
                        batch.Draw(gridSprite, new Vector2(gridSize) * new Vector2(x, y), Color.Gray);

                    if (Get(x, y) && !Get(x+1, y))
                        batch.Draw(wall, new Vector2(x + 0.75f, y) * new Vector2(gridSize), Color.White);

                    if (Get(x, y) && !Get(x - 1, y))
                        batch.Draw(wall, new Vector2(x - 0f, y) * new Vector2(gridSize), Color.White);

                    if (Get(x, y) && !Get(x, y + 1))
                        batch.Draw(wall, new Vector2(x + 1, y + 0.75f) * new Vector2(gridSize), null, null, null, (float)Math.PI/2f, Vector2.One, Color.White, SpriteEffects.None, 0);

                    if (Get(x, y) && !Get(x, y - 1))
                        batch.Draw(wall, new Vector2(x + 1, y) * new Vector2(gridSize), null, null, null, (float)Math.PI / 2f, Vector2.One, Color.White, SpriteEffects.None, 0);


                    if (Get(x, y))
                    {
                        for (int yy = -1; yy < 2; ++yy)
                            for (int xx = -1; xx < 2; ++xx)
                            {
                                if (!(xx == 0 && yy == 0))
                                {
                                    if (!(Get(x + xx, y + yy)))
                                        batch.Draw(wallcorner, (new Vector2(x, y) + new Vector2(0.75f * (xx+1)/2f, 0.75f * (yy+1)/2f)) * new Vector2(gridSize), Color.White);
                                }                           
                            }
                    }
                }
            }


            if (drawGrid)
            {
                for (int y = 0; y < map.GetLength(1) + 1; ++y)
                    Operators.DrawLine(batch, new Vector2(0, gridSize * y), new Vector2(gridSize * map.GetLength(0), gridSize * y), Color.LightBlue * 0.25f);

                for (int x = 0; x < map.GetLength(0) + 1; ++x)
                    Operators.DrawLine(batch, new Vector2(gridSize * x, 0), new Vector2(gridSize * x, map.GetLength(1) * gridSize), Color.LightBlue * 0.25f);
            }
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

        public void Load(Level level, Player player)
        {
            //holders.Clear();
            foreach (GameObject l in level.objects)
            {
                if (l is Laser)
                    l.Kill = true;
            }
            StreamReader file = new StreamReader("level.txt");
            for (int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                    if (file.Read() - 48 == 0) { Unlock(x, y); } else { Lock(x, y); };
                file.ReadLine();
            }
            while(!file.EndOfStream)
            {
                string[] line = file.ReadLine().Split(' ');
                Vector2 pos = new Vector2(float.Parse(line[1]), float.Parse(line[2]));
                switch(line[0])
                {
                    case "laser": level.Add(new Laser(player) { position = pos }); break;
                }
            }
            file.Close();
        }

        public void Save()
        {
            StreamWriter file = new StreamWriter("level.txt");
            for(int y=0; y<Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                    file.Write(Get(x, y) ? '1' : '0');
                file.WriteLine();
            }
            foreach (ItemHolder h in holders)
                file.WriteLine("{0} {1} {2}", h.id, h.position.X, h.position.Y);
            file.Close();
        }

        public int gridSize { get { return 32; } }
        public int Width { get { return map.GetLength(0); } }
        public int Height { get { return map.GetLength(1); } }
    }
}
