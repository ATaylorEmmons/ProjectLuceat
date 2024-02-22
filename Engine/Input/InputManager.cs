using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Input
{
    public static class InputManager
    {
        /*
        TODO:
            - Implement an input config file (using commands)
        */
        
        private static MouseState _lastMouseState;

        public static bool HasClicked { get; private set; }

        public static Vector2 MousePos { get; private set; }

        private static KeyboardState _lastKeyboardState;

        public static bool W { get; private set; }
        public static bool Q { get; private set; }
        public static bool R { get; private set; }

        public static bool Space { get; private set; }

        private static void update_mouse()
        {
            MouseState curMouseState = Mouse.GetState();

            HasClicked = curMouseState.LeftButton == ButtonState.Pressed && _lastMouseState.LeftButton == ButtonState.Released;
            MousePos = curMouseState.Position.ToVector2();

            _lastMouseState = curMouseState;
        }

        private static void update_keyboard()
        {

            KeyboardState curKeyboardState = Keyboard.GetState(); 

            if (curKeyboardState.IsKeyDown(Keys.W)) {
                W = true;
            }
            else
            {
                W = false;
            }

            if (curKeyboardState.IsKeyDown(Keys.Q))
            {
                Q = true;
            }
            else
            {
                Q = false;
            }

            if (curKeyboardState.IsKeyDown(Keys.R))
            {
                R = true;
            }
            else
            {
                R = false;
            }


            if (curKeyboardState.IsKeyDown(Keys.Space))
            {
                Space = true;
            }
            else
            {
                Space = false;
            }

            _lastKeyboardState = curKeyboardState;
        }

        public static void Update()
        {
            update_mouse();
            update_keyboard();

        }

    }
}
