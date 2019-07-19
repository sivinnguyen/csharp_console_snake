using System;
using System.Threading;
using static System.Console;

namespace  SnakeGame
{
    static class Game
    {   
        private enum Direction
        {
            Stand,
            Up,
            Down,
            Left,
            Right
        }
        private static bool isGameOn =  false;
        private static int gameSpeed = 0;
        private static int snakeLength;
        private static Direction direction;
        public static void Initialize()
        {
            Title = "Snake...";
            SetWindowSize(120, 30);
            SetBufferSize(120, 30);

            Clear();
            CursorVisible = false;

            isGameOn = true;
            gameSpeed = 150;
            snakeLength = 1;
            direction = Direction.Stand;
        }


        public static void Start()
        {
            Screen.Welcome();
            Screen.PlayScreen();

            Snake snake = new Snake(Screen.PlayFieldWidth, Screen.PlayFieldHeight);
            Fruit apple = new Fruit(snake);

            ConsoleKey command = ReadKey().Key;

            do
            {
                switch (command)
                {
                    case ConsoleKey.LeftArrow:
                        if(direction != Direction.Right)
                        {
                            direction = Direction.Left;   
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if(direction != Direction.Left)
                        {
                            direction = Direction.Right;
                        }
                        break;
                        
                    case ConsoleKey.UpArrow:
                        if(direction != Direction.Down)
                        {
                            direction = Direction.Up;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if(direction != Direction.Up)
                        {
                            direction = Direction.Down;
                        }
                        break;

                    default:
                        break;
                }

                if(direction == Direction.Up)
                {
                    snake.MoveUp();
                }

                if(direction == Direction.Down)
                {
                    snake.MoveDown();
                }

                if(direction == Direction.Left)
                {
                    snake.MoveLeft();
                }

                if(direction == Direction.Right)
                {
                    snake.MoveRight();
                }

                snake.Render();
                

                if (snake.HitTheWall())
                {
                    isGameOn = false;
                }

                if (snake.AteFruit(apple))
                {
                    apple.IsEatenBy(snake);
                    snakeLength++;
                    snake.IncreaseLength();
                    Screen.UpdateScoreField(snakeLength - 1);
                }

                if (KeyAvailable)
                {
                    command = ReadKey().Key;
                } 

                Thread.Sleep(gameSpeed);

            } while (isGameOn);


            ReadKey();
        }
    }
}
