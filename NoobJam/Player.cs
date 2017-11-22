using System;
using System.Collections.Generic;
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

        public override void Draw(SpriteBatch batch, Camera cam) {
            base.Draw(batch, cam);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            //decrease the speed
            friction = new Vector2(1.1f) + new Vector2(speed.Length() / 10f);
            speed /= friction;
            if (Vector2.Dot(speed, speed) < 0.1f)
                speed = new Vector2(0);

            Vector2 newPos = position + speed;
            Point from = (position.toPoint()) / new Point(map.gridSize);
            Point to = (newPos.toPoint()) / new Point(map.gridSize);

            if (!MapCollision(new Point(to.X, from.Y)))
                position.X = newPos.X;
            else
                speed.X = 0;

            if (!MapCollision(new Point(from.X, to.Y)))
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

        bool MapCollision(Point p)
        {
            return map.Get(p.X, p.Y) || map.Get(p.X + 1, p.Y) || map.Get(p.X + 1, p.Y + 1) || map.Get(p.X, p.Y+1);
        }
    }
}
