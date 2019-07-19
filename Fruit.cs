using System;
using static System.Console;

namespace SnakeGame
{
    public class Fruit
    {
        private int playFieldWidth;
        private int playFieldHeight;
        public int X
        {
            get;
            private set;
        }
        public int Y
        {
            get;
            private set;
        }


        public Fruit(Snake snake)
        {
            playFieldWidth = snake.PlayField_W;
            playFieldHeight = snake.PlayField_H;

            randomPosition(snake.X[0], snake.Y[0]);
            Create();
        }


        public void IsEatenBy(Snake snake)
        {
            randomPosition(snake.X[0], snake.Y[0]);
            Create();
        }


        private void Create()
        {
            SetCursorPosition(X, Y);
            ForegroundColor = ConsoleColor.Magenta;
            Write("\u25A0");
            ResetColor();
        }


        private void randomPosition(int snake_X, int snake_Y)
        {   
            Random random = new Random();
            X = random.Next(1, playFieldWidth - 2);
            Y = random.Next(1, playFieldHeight - 2);

            if (X == snake_X && Y == snake_Y)
            {
                randomPosition(X, Y);
            }
        }
    }
}
