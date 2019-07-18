using System;

namespace  SnakeGame
{
    public class Game
    {
        public static void Initialize()
        {
            Console.Title = "Snake...";
            Console.SetWindowSize(120, 30);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

            Console.Clear();
            Console.CursorVisible = false;
        }


        public static void Start()
        {
            Screen.Welcome();
            Screen.PlayScreen();

            Console.Clear();
        }
    }
}
