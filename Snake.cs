using System;
using static System.Console;

namespace SnakeGame
{
    public class Snake
    {
        public int Head_X
        {
            get;
            private set;
        }
        public int Head_Y
        {
            get;
            private set;
        }

        private int playFieldWidth = Screen.PlayFieldWidth;
        private int playFieldHeight = Screen.PlayFieldHeight;

        public Snake()
        {
            Random random = new Random();
            
            // Snake appeared in the center of play field   
            // Head_X = playFieldWidth / 2;
            // Head_Y = playFieldHeight / 2;
            
            // Randomly appeared in safety zone
            Head_X = random.Next(1, playFieldWidth - 2);
            Head_Y = random.Next(1, playFieldHeight - 2);

            Head();
        }


        public void Head()
        {
            SetCursorPosition(Head_X, Head_Y);
            ForegroundColor = ConsoleColor.Yellow;
            Write("\u25A0");
            ResetColor();
        }


        public void MoveLeft()
        {
            clearHead();
            Head_X--;
        }


        public void MoveRight()
        {
            clearHead();
            Head_X++;
        }


        public void MoveUp()
        {
            clearHead();
            Head_Y--;
        }


        public void MoveDown()
        {
            clearHead();
            Head_Y++;
        }


        public bool HitTheWall()
        {
            
            if (Head_X == 0 || Head_X == playFieldWidth - 1 || Head_Y == 0 || Head_Y == playFieldHeight -1)
            {
                return true;
            }

            return false;
        }


        private void clearHead()
        {
            SetCursorPosition(Head_X, Head_Y);
            Write(" ");
        }
    }

}
