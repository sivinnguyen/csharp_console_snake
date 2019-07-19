using System;
using static System.Console;

namespace SnakeGame
{
    public class Snake
    {
        public int PlayField_W
        {
            get;
            private set;
        }
        public int PlayField_H
        {
            get;
            private set;
        }

        public int[] X
        {
            get { return snake_X; } 
            private set {}
        }
        public int[] Y
        {
            get { return snake_Y; }
            private set {}
        }

        private int[] snake_X;
        private int[] snake_Y;

        private int snakeLength = 2;


        public Snake(int playableField_W, int playableField_H)
        {
            PlayField_W = playableField_W;
            PlayField_H = playableField_H;

            snake_X = new int[snakeLength];
            snake_Y = new int[snakeLength];

            // Randomly appeared in safety zone
            Random random = new Random();                        
            snake_X[0] = random.Next(1, PlayField_W - 2);
            snake_Y[0] = random.Next(1, PlayField_H - 2);

            snakeHead();
        }


        public void Render()
        {
            snakeHead();
            snakeBody();
            clearTail();
        }


        private void snakeHead()
        {
            SetCursorPosition(X[0], Y[0]);
            ForegroundColor = ConsoleColor.Yellow;
            Write("\u25A0");
            ResetColor();
        }


        private void snakeBody()
        {
            ForegroundColor = ConsoleColor.Yellow;
            BackgroundColor = ConsoleColor.DarkRed;
            for (int i = 1; i < snakeLength; i++)
            {
                SetCursorPosition(X[i], Y[i]);
                Write("o");
            }
            ResetColor();
        }


        private void clearTail()
        {
            SetCursorPosition(X[snakeLength - 1], Y[snakeLength - 1]);
            Write(" ");
        }


        public void MoveLeft()
        {
            bodyMove();
            snake_X[0]--;
        }


        public void MoveRight()
        {
            bodyMove();
            snake_X[0]++;
        }


        public void MoveUp()
        {
            bodyMove();
            snake_Y[0]--;
        }


        public void MoveDown()
        {
            bodyMove();
            snake_Y[0]++;
        }


        private void bodyMove()
        {
            for ( int i = snakeLength - 1; i > 0; i--)
            {
                snake_X[i] = snake_X[i - 1];
                snake_Y[i] = snake_Y[i - 1];
            }
        }


        public bool HitTheWall()
        {
            
            if (X[0] == 0 || X[0] == PlayField_W - 1 || Y[0] == 0 || Y[0] == PlayField_H - 1)
            {
                return true;
            }

            return false;
        }

        public bool AteFruit(Fruit fruit)
        {
            if (X[0] == fruit.X && Y[0] == fruit.Y)
            {
                return true;
            }

            return false;
        }

        public void IncreaseLength()
        {
            snakeLength++;

            Array.Resize(ref snake_X, snakeLength);
            Array.Resize(ref snake_Y, snakeLength);
        }
    }

}
