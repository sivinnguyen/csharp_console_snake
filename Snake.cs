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

        public Snake(int playableField_W, int playableField_H)
        {
            PlayField_W = playableField_W;
            PlayField_H = playableField_H; 

            // Randomly appeared in safety zone
            Random random = new Random();                        
            Head_X = random.Next(1, PlayField_W - 2);
            Head_Y = random.Next(1, PlayField_H - 2);

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
            
            if (Head_X == 0 || Head_X == PlayField_W - 1 || Head_Y == 0 || Head_Y == PlayField_H - 1)
            {
                return true;
            }

            return false;
        }

        public bool AteFruit(Fruit fruit)
        {
            if (Head_X == fruit.X && Head_Y == fruit.Y)
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
