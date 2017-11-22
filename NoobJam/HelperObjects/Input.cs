using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace NoobJam
{
    static class Input
    {
        static KeyboardState keystate, prevkeystate;
        static MouseState mousestate, prevmousestate;

        public static void Init()
        {
            keystate = Keyboard.GetState();
            prevkeystate = Keyboard.GetState();
            mousestate = Mouse.GetState();
            prevmousestate = Mouse.GetState();
        }

        public static void Update()
        {
            prevkeystate = keystate;
            keystate = Keyboard.GetState();
            prevmousestate = mousestate;
            mousestate = Mouse.GetState();

        }

        public static bool KeyDown(Keys key)
        {
            return keystate.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return keystate.IsKeyDown(key) && !prevkeystate.IsKeyDown(key);
        }

        

        public static bool MouseLeft { get { return mousestate.LeftButton == ButtonState.Pressed; } }
        public static bool MouseLeftPressed { get { return MouseLeft && prevmousestate.LeftButton != ButtonState.Pressed; } }
        public static bool MouseRight { get { return mousestate.RightButton == ButtonState.Pressed; } }
        public static bool MouseRightPressed { get { return MouseRight && prevmousestate.RightButton != ButtonState.Pressed; } }
        public static Point MousePos { get { return mousestate.Position; } }
    }
}
