using System;
using OpenTK.Input;

namespace CatRPG {
    public static class Input {
        private static KeyboardState state;

        public static void UpdateInput () {
            Input.state = Keyboard.GetState ();
        }

        public static bool IsKeyDown (KeyCode keycode) {
            int keyID = (int) keycode;
            Key key = (Key) keyID;

            /*
            for (int i = 0; i < 200; i++) {
                
                Console.WriteLine (i + " -> " + key);
            }
            */

            return Input.state.IsKeyDown (key);
        }
    }
}