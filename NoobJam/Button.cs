using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace NoobJam
{
    class Button : SpriteObject
    {
        string text;

        public Button(string text = "")
        {
            this.text = text;
        }

        public override void Draw(SpriteBatch batch, Camera cam)
        {
            base.Draw(batch, cam);
            //batch.DrawString(Fonts.ButtonFont, text)
        }

        public bool Pressed {  get { return Input.MouseLeftPressed && Hover; } }
        public bool Hover { get { return sprite.Bounds.Contains(Input.MousePos); } }
    }
}
