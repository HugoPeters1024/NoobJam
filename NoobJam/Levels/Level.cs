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
        protected LevelManager Manager;
        public Camera camera;

        public Level(LevelManager manager) {
            objects = new List<GameObject>();
            Camera camera = new Camera();
            Manager = manager;
        }


        public virtual void Update(GameTime gameTime)
        {
            camera.Update(gameTime);
            foreach (GameObject obj in objects)
                obj.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch batch)
        {
            foreach (GameObject obj in objects)
                obj.Draw(batch);
        }

        public void Add(GameObject obj)
        {
            objects.Add(obj);
        }
    }
}
