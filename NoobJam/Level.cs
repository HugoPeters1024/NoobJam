using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace NoobJam
{
    class Level
    {
        public List<GameObject> objects;
        public Camera camera;

        public void Update()
        {
            foreach (GameObject obj in objects)
                obj.Update();
        }

        public void Draw(SpriteBatch batch)
        {
            foreach (GameObject obj in objects)
                obj.Draw(batch, camera);
        }
    }
}
