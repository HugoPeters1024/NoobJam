using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NoobJam
{
    class Button : SpriteObject
    {
        string text;
        SpriteFont font;
        Texture2D sprite_down;

        private Button(Vector2 startPos) : base(startPos)
        {
            sprite = AssetManager.LoadSprite("button off");
            sprite_down = AssetManager.LoadSprite("button on");
            font = AssetManager.LoadFont("ButtonFont2");
        }

        public Button(Vector2 startPosition, string text = "") : this(startPosition)
        {
            this.text = text;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(Hover ? sprite_down : sprite, position + new Vector2(-40, 20), null, null, Vector2.Zero, 0.0f, new Vector2(1), Color.White, SpriteEffects.None, 0);
            batch.DrawString(font, text, position + new Vector2(10, 10), Color.White);
        }

        public bool Clicked {  get { return Input.MouseLeftPressed && Hover; } }
        public bool Hover { get { return sprite.Bounds.Contains(Input.MousePos - position.toPoint()); } }
    }
}
