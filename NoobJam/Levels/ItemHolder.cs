using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NoobJam
{
    class ItemHolder
    {
        public Vector2 position;
        public string id;
        public ItemHolder(string id)
        {
            this.id = id;
        }
    }
}
