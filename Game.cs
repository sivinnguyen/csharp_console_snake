using System;
using System.Threading;
using static System.Console;

namespace  SnakeGame
{
    static class Game
    {
        private static bool isGameOn;
        private static int gameSpeed = 150;
        public static void Initialize()
        {
            Title = "Snake...";
            SetWindowSize(120, 30);
            SetBufferSize(120, 30);

            Clear();
            CursorVisible = false;

            isGameOn = true;
        }


        public static void Start()
        {
            Screen.Welcome();
            Screen.PlayScreen();

            Snake snake = new Snake();

            ConsoleKey command = ReadKey().Key;

            do
            {
                switch (command)
                {
                    case ConsoleKey.LeftArrow:
                        snake.MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        snake.MoveRight();
                        break;
                    case ConsoleKey.UpArrow:
                        snake.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        snake.MoveDown();
                        break;
                }

                snake.Head();

                if (snake.HitTheWall())
                {
                    isGameOn = false;
                }

                if (KeyAvailable)
                {
                    command = ReadKey().Key;
                } 

                Thread.Sleep(gameSpeed);

            } while (isGameOn);

            ReadKey();
            Clear();
        }
    }
}
