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
        public int health = 100;
        public int score = 0;
        public int godtimer;

        public Player(Vector2 startPosition, Map map) : base(startPosition) {
            this.sprite = AssetManager.LoadSprite("player");
            this.map = map;
            speed = new Vector2(0);
            moveSpeed = new Vector2(1.7f);
            godtimer = 0;
        }

        public override void Draw(SpriteBatch batch) {
            batch.Draw(sprite, position, Color.White * (godtimer % 20 > 10 ? 0.2f : 1f));
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            if (godtimer > 0)
            {
                godtimer--;
            }

            //decrease the speed
            friction = new Vector2(1.2f) + new Vector2(speed.Length() / 50f);
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
        }

        public void AddForce(Vector2 f)
        {
            speed += f;
        }

        public Rectangle BoundingBox { get { return new Rectangle((int)position.X, (int)position.Y, 32, 32); } }

        bool MapCollision(Vector2 v)
        {
            //slight offset
            Point p = (v + new Vector2(2f)).toPoint() / new Point(map.gridSize);
            Point pt = (v + new Vector2(30f)).toPoint() / new Point(map.gridSize);
            return map.Get(p.X, p.Y) || map.Get(pt.X, p.Y) || map.Get(pt.X, pt.Y) || map.Get(p.X, pt.Y);
        }

        public bool Alive { get { return health > 0; } }
        public bool Invincable { get { return godtimer > 0; } }
    }
}
