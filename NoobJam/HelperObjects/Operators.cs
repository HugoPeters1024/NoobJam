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
        public static Texture2D t;

        public static Random rand;

        public static void Init(GraphicsDevice device)
        {
            t = new Texture2D(device, 1, 1);
            t.SetData<Color>(
                new Color[] { Color.White });// fill the texture with white
            rand = new Random();
        }

        public static Vector2 toVector(this Point p)
        {
            return new Vector2(p.X, p.Y);
        }

        public static Point toPoint(this Vector2 v)
        {
            return new Point((int)v.X, (int)v.Y);
        }

        public static bool LineIntersectsRect(Point p1, Point p2, Rectangle r) { return LineIntersectsLine(p1, p2, new Point(r.X, r.Y), new Point(r.X + r.Width, r.Y)) || LineIntersectsLine(p1, p2, new Point(r.X + r.Width, r.Y), new Point(r.X + r.Width, r.Y + r.Height)) || LineIntersectsLine(p1, p2, new Point(r.X + r.Width, r.Y + r.Height), new Point(r.X, r.Y + r.Height)) || LineIntersectsLine(p1, p2, new Point(r.X, r.Y + r.Height), new Point(r.X, r.Y)) || (r.Contains(p1) && r.Contains(p2)); }
        private static bool LineIntersectsLine(Point l1p1, Point l1p2, Point l2p1, Point l2p2) { float q = (l1p1.Y - l2p1.Y) * (l2p2.X - l2p1.X) - (l1p1.X - l2p1.X) * (l2p2.Y - l2p1.Y); float d = (l1p2.X - l1p1.X) * (l2p2.Y - l2p1.Y) - (l1p2.Y - l1p1.Y) * (l2p2.X - l2p1.X); if (d == 0) { return false; } float r = q / d; q = (l1p1.Y - l2p1.Y) * (l1p2.X - l1p1.X) - (l1p1.X - l2p1.X) * (l1p2.Y - l1p1.Y); float s = q / d; if (r < 0 || r > 1 || s < 0 || s > 1) { return false; } return true; }





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
