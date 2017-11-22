using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NoobJam
{
    public static class Operators
    {
        static Texture2D t;

        public static void Init(GraphicsDevice device)
        {
            t = new Texture2D(device, 1, 1);
            t.SetData<Color>(
                new Color[] { Color.White });// fill the texture with white
        }

        public static Vector2 toVector(this Point p)
        {
            return new Vector2(p.X, p.Y);
        }

        public static Point toPoint(this Vector2 v)
        {
            return new Point((int)v.X, (int)v.Y);
        }

        public static void DrawLine(SpriteBatch sb, Vector2 start, Vector2 end, Color c)
        {
            Vector2 edge = end - start;
            // calculate angle to rotate line
            float angle =
                (float)Math.Atan2(edge.Y, edge.X);


            sb.Draw(t,
                new Rectangle(// rectangle defines shape of line and position of start of line
                    (int)start.X,
                    (int)start.Y,
                    (int)edge.Length(), //sb will strech the texture to fill this rectangle
                    1), //width of line, change this to make thicker line
                null,
                c, //colour of line
                angle,     //angle of line (calulated above)
                new Vector2(0, 0), // point in line about which to rotate
                SpriteEffects.None,
                0);

        }
    }
}
