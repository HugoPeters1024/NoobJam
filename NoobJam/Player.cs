using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace NoobJam {
    class Player : SpriteObject {

        float walkingSpeed = 180f;

        public Player(Vector2 startPosition) : base(startPosition) {
            this.sprite = AssetManager.LoadSprite("player");
        }

        public override void Draw(SpriteBatch batch, Camera cam) {
            base.Draw(batch, cam);

        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
            if(Input.KeyDown(Keys.A))
            {
                position -= new Vector2(walkingSpeed * (float)gameTime.ElapsedGameTime.Milliseconds / 1000f, 0);
            }
            if (Input.KeyDown(Keys.D)) {
                position += new Vector2(walkingSpeed * (float)gameTime.ElapsedGameTime.Milliseconds / 1000f, 0);
            }
            if (Input.KeyDown(Keys.W)) {
                position -= new Vector2(0, walkingSpeed * (float)gameTime.ElapsedGameTime.Milliseconds / 1000f);
            }
            if (Input.KeyDown(Keys.S)) {
                position += new Vector2(0, walkingSpeed * (float)gameTime.ElapsedGameTime.Milliseconds / 1000f);
            }
        }
    }
}
