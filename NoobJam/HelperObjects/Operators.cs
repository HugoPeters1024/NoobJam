using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NoobJam
{
    public static class Operators
    {
        public static Vector2 toVector(this Point p)
        {
            return new Vector2(p.X, p.Y);
        }

        public static Point toPoint(this Vector2 v)
        {
            return new Point((int)v.X, (int)v.Y);
        }
    }
}
