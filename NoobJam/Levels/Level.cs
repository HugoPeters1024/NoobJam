using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NoobJam
{
    class Level
    {
        public List<GameObject> objects;
        public Camera camera;

        public Level() {
            objects = new List<GameObject>();
        }


        public virtual void Update(GameTime gameTime)
        {
            foreach (GameObject obj in objects)
                obj.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch batch)
        {
            foreach (GameObject obj in objects)
                obj.Draw(batch, camera);
        }

        public void Add(GameObject obj)
        {
            objects.Add(obj);
        }
    }
}
