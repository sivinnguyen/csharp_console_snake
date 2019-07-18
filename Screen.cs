using System;
using static System.Console;

namespace SnakeGame
{
    public class Screen
    {
        private static int _screenWidth = Console.WindowWidth;
        private static int _screenHeight = Console.WindowHeight;
        
        public static int PlayFieldWidth
        {
            get;
            private set;
        } = (_screenWidth * 3) / 5;

        public static int PlayFieldHeight
        {
            get;
            private set;
        } = _screenHeight;
   
   
        public static void Welcome()
        {
            Clear();
            
            string[] screenTitle = new string[6]
            {
                "  _________              __                       ",
                " /   _____/ ____ _____  |  | __ ____              ",
                " \\_____  \\ /    \\\\__  \\ |  |/ // __ \\             ",
                " /        \\   |  \\/ __ \\|    <\\  ___/             ",
                "/_______  /___|  (____  /__|_ \\\\___  > /\\  /\\  /\\ ",
                "        \\/     \\/     \\/     \\/    \\/  \\/  \\/  \\/ "
            };

            int titleY = (_screenHeight / 3) - screenTitle.Length;

            centerText(screenTitle, titleY, false);
            WriteLine();
            centerText("-- Press ENTER to start, ESCAPE to exit --");
            
            ReadKey();
        }


        public static void PlayScreen()
        {
            Clear();
            PlayField();
            ScoreField();
            ReadKey();
        }


        private static void PlayField()
        {
            SetCursorPosition(0, 0);
            Write("\u250C");

            SetCursorPosition(PlayFieldWidth - 1, 0);
            Write("\u2510");

            SetCursorPosition(0, PlayFieldHeight - 1);
            Write("\u2514");

            SetCursorPosition(PlayFieldWidth - 1, PlayFieldHeight - 1);
            Write("\u2518");

            for (int i = 1; i < PlayFieldWidth - 1; i++)
            {
                SetCursorPosition(i, 0);
                Write("\u2500");

                SetCursorPosition(i, PlayFieldHeight - 1);
                Console.Write("\u2500");
            }

            for (int i = 1; i < PlayFieldHeight - 1; i++)
            {
                SetCursorPosition (0, i);
                Write ("\u2502");

                SetCursorPosition (PlayFieldWidth - 1, i);
                Write ("\u2502");
            }
        }


        private static void ScoreField()
        {
            int scoreField_X = PlayFieldWidth + 5;

            string[] fieldTitle = new string[5]
            {
                " __             _              ",
                "/ _\\_ __   __ _| | _____       ",
                "\\ \\| '_ \\ / _` | |/ / _ \\      ",
                "_\\ \\ | | | (_| |   <  __/_ _ _ ",
                "\\__/_| |_|\\__,_|_|\\_\\___(_|_|_)"                               
            };

            for (int i = 0; i < fieldTitle.Length; i++)
            {
                writeTextAt(fieldTitle[i], scoreField_X, i, false);
            }

            WriteLine();
            writeTextAt("SCORE: 0", scoreField_X);
        }


        private static void centerText(string[] text, int y = 0, bool useCurrentY = true)
        {
            if (useCurrentY)
                y = CursorTop;

            int textWidth = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Length > textWidth)
                    textWidth = text[i].Length;
            }

            int x = (_screenWidth - textWidth) / 2;

            for (int j = 0; j < text.Length; j++, y++)
            {
                SetCursorPosition(x, y);
                WriteLine(text[j]);
            }
        }


        private static void centerText(string text, int y = 0, bool useCurrentY = true)
        {
            if (useCurrentY)
                y = CursorTop;
            
            
            int x = (_screenWidth - text.Length) / 2;

            SetCursorPosition(x, y);
            WriteLine(text);
        }


        private static void writeTextAt(string text, int x, int y = 0, bool useCurrentY = true)
        {
            if (useCurrentY)
                y = CursorTop;
            
            SetCursorPosition(x, y);
            WriteLine(text);
        }
    }
}
