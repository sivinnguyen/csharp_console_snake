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
            this.Head_X = playFieldWidth / 2;
            this.Head_Y = playFieldHeight / 2;

            Head();
        }


        public void Head()
        {
            SetCursorPosition(this.Head_X, this.Head_Y);
            ForegroundColor = ConsoleColor.Yellow;
            Write("\u25A0");
            ResetColor();
        }
    }

}
