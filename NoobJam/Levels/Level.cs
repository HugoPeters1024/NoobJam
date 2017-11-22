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
        public Point Size;

        public Level(LevelManager manager) {
            objects = new List<GameObject>();
            Camera camera = new Camera(this);
            Manager = manager;
            Size = new Point(Game1.graphics.GraphicsDevice.Viewport.Width, Game1.graphics.GraphicsDevice.Viewport.Height);
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
