using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NoobJam
{
    class Camera : GameObject
    {
        protected float _zoom; // Camera Zoom
        public Matrix _transform; // Matrix Transform
        protected float _rotation; // Camera Rotation
        public GameObject follow;

        public Camera()
        {
            _zoom = 1.0f;
            _rotation = 0.0f;
            position = Vector2.Zero;
        }

        // Sets and gets zoom
        public float Zoom
        {
            get { return _zoom; }
            set { _zoom = value; if (_zoom < 0.1f) _zoom = 0.1f; } // Negative zoom will flip image
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        // Auxiliary function to move the camera
        public void Move(Vector2 amount)
        {
            position += amount;
        }
        // Get set position
        public Vector2 Pos
        {
            get { return position; }
            set { position = value; }
        }

        public override void Draw(SpriteBatch batch)
        { 
        }

        public override void Update(GameTime gameTime)
        {
            if (follow == null)
                return;

            position = -new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width, Game1.graphics.GraphicsDevice.Viewport.Height) / 2;
            if (position.X + follow.position.X < 0)
                position.X = -follow.position.X;
            if (position.Y + follow.position.Y < 0)
                position.Y = -follow.position.Y;
            Console.WriteLine(position);
            //if (base.position.X < 0) base.position.X = 0;
            //if (base.position.Y < 0) base.position.Y = 0;

            Input.SetMouseOffset(-position - follow.position);
        }

        public Matrix get_transformation(GraphicsDevice graphicsDevice)
        {
            _transform =       // Thanks to o KB o for this solution
              Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) *
              Matrix.CreateRotationZ(Rotation) *
              Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));

            if (follow != null)
                  _transform *= Matrix.CreateTranslation(new Vector3(-follow.position, 0));
            return _transform;
        }

    }
}
