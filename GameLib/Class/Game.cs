using System;
using GameLib;

namespace LogicGame
{
    class ClGame
    {
        public static void Game()
        {
            library.Score = 0;
            library.Matrix = new ulong[4, 4];
            library.Rows = library.Matrix.GetLength(0);
            library.Cols = library.Matrix.GetLength(1);
        }
        public static void Play()
        {
            do
            {
               
                Console.WriteLine("Use arrow keys to play. CTRL+C to exit");
                ConsoleKeyInfo input = Console.ReadKey(true); 
                Console.WriteLine(input.Key.ToString());

            }
            while (true); // use CTRL-C to break out of loop
            Console.WriteLine("Press any key to quit...");
            Console.Read();
        }

    }
}
