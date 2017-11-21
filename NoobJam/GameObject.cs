using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NoobJam
{
    class GameObject : IGameObject
    {
        public bool isUI;
        public Vector2 position;

        public GameObject() { }

        public GameObject(Vector2 position) {
            this.position = position;
        }

        public virtual void Draw(SpriteBatch batch, Camera cam)
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }
    }
}
