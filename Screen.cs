using System;

namespace SnakeGame
{
    public class Screen
    {
        private static int _screenHeight = Console.WindowHeight;
        private static int _screenWidth = Console.WindowWidth;
   
   
        public static void Welcome()
        {
            Console.Clear();
            
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
            Console.WriteLine();
            centerText("-- Press ENTER to start, ESCAPE to exit --");
            
            Console.ReadKey();
        }


        private static void centerText(string[] text, int y = 0, bool useCurrentY = true)
        {
            if (useCurrentY)
                y = Console.CursorTop;

            int textWidth = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Length > textWidth)
                    textWidth = text[i].Length;
            }

            int x = (_screenWidth - textWidth) / 2;
            if (textWidth < _screenWidth)
            {
                for (int j = 0; j < text.Length; j++, y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(text[j]);
                }
            }
        }


        private static void centerText(string text, int y = 0, bool useCurrentY = true)
        {
            if (useCurrentY)
                y = Console.CursorTop;
            
            
            int x = (_screenWidth - text.Length) / 2;
            if (text.Length < _screenWidth)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(text);
            }
        }
    }
}
