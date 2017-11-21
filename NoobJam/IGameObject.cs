using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NoobJam
{
    interface IGameObject
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch batch, Camera cam);
    }
}
