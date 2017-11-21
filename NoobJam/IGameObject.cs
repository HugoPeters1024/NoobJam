using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace NoobJam
{
    interface IGameObject
    {
        void Update();
        void Draw(SpriteBatch batch, Camera cam);
    }
}
