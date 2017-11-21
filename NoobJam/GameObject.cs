using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace NoobJam
{
    class GameObject : IGameObject
    {
        public bool isUI;
        public int x, y;

        public virtual void Draw(SpriteBatch batch, Camera cam)
        {
            
        }

        public virtual void Update()
        {
            
        }
    }
}
