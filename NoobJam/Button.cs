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

        public Button(Vector2 startPosition, string text = "") : base(startPosition)
        {
            this.text = text;
        }

        public override void Draw(SpriteBatch batch, Camera cam)
        {
            base.Draw(batch, cam);
            batch.DrawString(Fonts.ButtonFont, text, position + sprite.Bounds.Center.ToVector2(), Color.White);
        }

        public Button(Vector2 startPos) : base(startPos) { }

        public bool Pressed {  get { return Input.MouseLeftPressed && Hover; } }
        public bool Hover { get { return sprite.Bounds.Contains(Input.MousePos); } }
    }
}
