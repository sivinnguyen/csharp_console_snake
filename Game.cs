using System;

namespace  SnakeGame
{
    public class Game
    {
        public static void Initialize()
        {
            Console.WindowWidth = 120;
            Console.WindowHeight = 30;

            Console.CursorVisible = false;
        }


        public static void Start()
        {
            Screen.Welcome();
        }
    }
}
