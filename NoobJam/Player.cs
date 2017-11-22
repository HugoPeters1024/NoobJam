using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace NoobJam {
    class Player : SpriteObject {
        Map map;
        Vector2 speed, moveSpeed;
        Vector2 friction;

        public Player(Vector2 startPosition, Map map) : base(startPosition) {
            this.sprite = AssetManager.LoadSprite("player");
            this.map = map;
            speed = new Vector2(0);
            moveSpeed = new Vector2(1.7f);
        }

        public override void Draw(SpriteBatch batch) {
            base.Draw(batch);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            //decrease the speed
            friction = new Vector2(1.1f) + new Vector2(speed.Length() / 10f);
            speed /= friction;
            if (Vector2.Dot(speed, speed) < 0.1f)
                speed = new Vector2(0);

            Vector2 newPos = position + speed;
            /*
            Point from = (position.toPoint()) / new Point(map.gridSize);
            Point to = (newPos.toPoint()) / new Point(map.gridSize); */

            if (!MapCollision(new Vector2(newPos.X, position.Y)))
                position.X = newPos.X;
            else { speed.X = 0; }

            if (!MapCollision(new Vector2(position.X, newPos.Y)))
                position.Y = newPos.Y;
            else
                speed.Y = 0;

            if(Input.KeyDown(Keys.A))
            {
                speed += new Vector2(-1, 0) * moveSpeed;
            }
            if (Input.KeyDown(Keys.D)) {
                speed += new Vector2(1, 0) * moveSpeed;
            }
            if (Input.KeyDown(Keys.W)) {
                speed += new Vector2(0, -1) * moveSpeed;
            }
            if (Input.KeyDown(Keys.S)) {
                speed += new Vector2(0, 1) * moveSpeed;
            }

            if (Input.KeyDown(Keys.X))
                Safe();

            if (Input.KeyDown(Keys.Z))
                Load();
        }

        bool MapCollision(Vector2 v)
        {
            //slight offset
            Point p = (v + new Vector2(2f)).toPoint() / new Point(map.gridSize);
            Point pt = (v + new Vector2(30f)).toPoint() / new Point(map.gridSize);
            return map.Get(p.X, p.Y) || map.Get(pt.X, p.Y) || map.Get(pt.X, pt.Y) || map.Get(p.X, pt.Y);
        }

        void Safe()
        {
            StreamWriter file = new StreamWriter("level.txt");
            for (int y = 0; y < map.Height; ++y)
            {
                for (int x = 0; x < map.Width; ++x)
                    file.Write(map.Get(x, y) ? '1' : '0');
                file.WriteLine();
            }
            file.Close();
        }

        void Load()
        {
            StreamReader file = new StreamReader("level.txt");
            for (int y = 0; y < map.Height; ++y)
            {
                for (int x = 0; x < map.Width; ++x)
                    if (file.Read() - 48 == 0) { map.Unlock(x, y); } else { map.Lock(x, y); };
                file.ReadLine();
            }
            file.Close();
        }
    }
}
