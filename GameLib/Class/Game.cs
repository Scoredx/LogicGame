using System;
using GameLib;
using System.Collections.Generic;

namespace LogicGame
{
    class gameClass
    {
        //vars
        public ulong points { get; private set; }
        public ulong[,] Matrix { get; private set; }
        private readonly int Rows;
        private readonly int Columns;
        private readonly Random rnd = new Random();

        public gameClass()
        {
            this.Matrix = new ulong[4, 4];
            this.Columns = this.Matrix.GetLength(1);
            this.Rows = this.Matrix.GetLength(0);
            this.points = 0;
        }

        public void Play() //starting game 
        {
            bool hasUpdated = true;
            do
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;

                if (hasUpdated)
                {
                    insertValue(); // puting new cell inside matrix
                }

                Display(); // displaying the matrix and text 

                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition((Console.WindowWidth - "Use arrow keys to Play".Length) / 2, Console.CursorTop);
                Console.WriteLine("Use arrow keys to Play");
                Console.SetCursorPosition((Console.WindowWidth - "Press Ctrl-C to exit".Length) / 2, Console.CursorTop);
                Console.WriteLine("Press Ctrl-C to Exit");
                ConsoleKeyInfo input = Console.ReadKey(true);
                Console.WriteLine(input.Key.ToString());
            }
            while (true);
        }
        private void Display() // displaying the matrix and text 
        {
            Console.Clear();
            Console.WriteLine();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    using (new library.ColorOutput(library.GetColor(Matrix[i, j])))
                    {
                        Console.Write(string.Format("{0,6}", Matrix[i, j])); 
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition((Console.WindowWidth - "points: {0}".Length) / 2, Console.CursorTop);
            Console.WriteLine("points: {0}\n", this.points);
        }
        private void insertValue() // inserts value into empty slot in matrix 
        {
            List<Tuple<int, int>> availableSlots = new List<Tuple<int, int>>();
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    if (Matrix[r, c] == 0)
                    {
                        availableSlots.Add(new Tuple<int, int>(r, c));
                    }
                }
            }
            int Slot = rnd.Next(0, availableSlots.Count);
            if (!Menu.diff)
            {
                ulong cellValue = rnd.Next(0, 100) < 60 ? (ulong)2 : (ulong)4;
                Matrix[availableSlots[Slot].Item1, availableSlots[Slot].Item2] = cellValue;
            }
            else
            {
                Matrix[availableSlots[Slot].Item1, availableSlots[Slot].Item2] = 2;
            }
        }
    }
}
