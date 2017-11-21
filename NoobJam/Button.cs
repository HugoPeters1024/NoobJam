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

        private Button(Vector2 startPos) : base(startPos)
        {
            sprite = AssetManager.LoadSprite("button");
            font = AssetManager.LoadFont("ButtonFont");
        }

        public Button(Vector2 startPosition, string text = "") : this(startPosition)
        {
            this.text = text;
        }

        public override void Update()
        {
            Console.WriteLine(Clicked);
            base.Update();
        }

        public override void Draw(SpriteBatch batch, Camera cam)
        {
            base.Draw(batch, cam);
            batch.DrawString(font, text, position + sprite.Bounds.Center.ToVector2(), Color.White);
        }

        public bool Clicked {  get { return Input.MouseLeftPressed && Hover; } }
        public bool Hover { get { return sprite.Bounds.Contains(Input.MousePos - position.toPoint()); } }
    }
}
