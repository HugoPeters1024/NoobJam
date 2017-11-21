using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace NoobJam
{
    class Button : SpriteObject
    {
        public Button(Vector2 startPos) : base(startPos) {
            
        }
        public bool Pressed {  get { return Input.MouseLeftPressed && Hover; } }
        public bool Hover { get { return sprite.Bounds.Contains(Input.MousePos); } }
    }
}
