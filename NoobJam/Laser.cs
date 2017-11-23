using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NoobJam
{
    class Laser : GameObject
    {
        Vector2 direction;
        Player player;
        int reach = 100;
        float speed;
        bool turn;

        public Laser(Player player)
        {
            direction = Vector2.Normalize(new Vector2(20, 10));
            this.player = player;
            speed = (float)Operators.rand.NextDouble()/20f + 0.02f;
            reach = Operators.rand.Next(40) + 50;
        }

        public void TurnRight()
        {
            Vector2 perp = new Vector2(-direction.Y, direction.X) * speed;
            direction = Vector2.Normalize(direction + perp);
        }

        public void TurnLeft()
        {
            Vector2 perp = new Vector2(direction.Y, -direction.X) * speed;
            direction = Vector2.Normalize(direction + perp);
        }

        public override void Update(GameTime gameTime)
        {
            if (Operators.rand.Next(500) == 0)
                turn = !turn;

            if (turn)
                TurnLeft();
            else
                TurnRight();
            Vector2 toPlayer = (player.position + new Vector2(16)) - position;
            Vector2 toPlayerNorm = Vector2.Normalize(toPlayer);
            if (Operators.LineIntersectsRect(position.toPoint(), (position + reach * direction).toPoint(), player.BoundingBox) && !player.Invincable)
            {
                player.AddForce(direction * 20);
                player.health -= 30;
                player.godtimer = 120;
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            Operators.DrawLine(batch, position, position + direction * reach, Color.Red);
            base.Draw(batch);
        }
    }
}
