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
        public static bool win = false;

        public gameClass() //creating game obj
        {
            this.Matrix = new ulong[4, 4];
            this.Columns = this.Matrix.GetLength(1);
            this.Rows = this.Matrix.GetLength(0);
            this.points = 0;
        }
        public void Play() //starting game 
        {
            bool Updated = true;
            do
            {
                if(win) 
                {
                    using (new library.Color(ConsoleColor.Yellow))
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\n\n");
                        Console.SetCursorPosition((Console.WindowWidth - "YOU WIN".Length) / 2, Console.CursorTop);
                        Console.WriteLine("YOU WIN");
                        Console.SetCursorPosition((Console.WindowWidth - "!!!".Length) / 2, Console.CursorTop);
                        Console.WriteLine("!!!");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    return;
                }
                if (Updated)
                {
                    insertValue(); // puting new cell inside matrix
                }
                Display(); // displaying the matrix and text 

                if (Lost()) // happens when there is no  movement 
                {
                    using (new library.Color(ConsoleColor.Red))
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\n\n");
                        Console.SetCursorPosition((Console.WindowWidth - "YOU LOST".Length) / 2, Console.CursorTop);
                        Console.WriteLine("YOU LOST");
                        Console.SetCursorPosition((Console.WindowWidth - "!!!".Length) / 2, Console.CursorTop);
                        Console.WriteLine("!!!");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    return;
                }
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition((Console.WindowWidth - "Use arrow keys to Play".Length) / 2, Console.CursorTop);
                Console.WriteLine("Use arrow keys to Play");
                Console.SetCursorPosition((Console.WindowWidth - "Press Ctrl-C to exit".Length) / 2, Console.CursorTop);
                Console.WriteLine("Press Ctrl-C to Exit");
                ConsoleKeyInfo input = Console.ReadKey(true);
                Console.SetCursorPosition((Console.WindowWidth - "xxxxxx".Length), Console.CursorTop);
                Console.WriteLine(input.Key.ToString());
                switch (input.Key) //user movement input
                {
                    case ConsoleKey.UpArrow:
                        Updated = bUpdate(library.movDirection.Up);
                        break;

                    case ConsoleKey.DownArrow:
                        Updated = bUpdate(library.movDirection.Down);
                        break;

                    case ConsoleKey.LeftArrow:
                        Updated = bUpdate(library.movDirection.Left);
                        break;

                    case ConsoleKey.RightArrow:
                        Updated = bUpdate(library.movDirection.Right);
                        break;
                    default:
                        Updated = false;
                        break;
                }
            }
            while (true);
        }
        private bool bUpdate(library.movDirection dir) //updates the matrix after user movement
        {
            ulong points;
            bool isUpdated = library.action(this.Matrix, dir, out points);
            this.points += points;
            return isUpdated;
        }
        private bool Lost() // happens when there is no possible movement 
        {
            ulong points;
            foreach (library.movDirection dir in new library.movDirection[] { library.movDirection.Down, library.movDirection.Up, library.movDirection.Left, library.movDirection.Right })
            {
                ulong[,] clone = (ulong[,])Matrix.Clone();
                if (library.action(clone, dir, out points))
                {
                    return false;
                }
            }
            return true;
        }
        private void Display() // displaying the matrix and text 
        {
            Console.Clear();
            Console.WriteLine();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    library.win(Matrix[i, j]);
                    using (new library.Color(library.GetColor(Matrix[i, j]))) // set color of cell
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
            Console.WriteLine("Points: {0}\n", this.points);
        }
        private void insertValue() // inserts value into empty slot in matrix 
        {
            List<Tuple<int, int>> availableSlots = new List<Tuple<int, int>>(); // list of availableSlots
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

            if (!Menu.diff) //diff settings 

            {
                ulong cellValue = rnd.Next(0, 100) < 50 ? (ulong)2 : (ulong)4;
                Matrix[availableSlots[Slot].Item1, availableSlots[Slot].Item2] = cellValue;
            }
            else
            {
                Matrix[availableSlots[Slot].Item1, availableSlots[Slot].Item2] = 2;
            }
            Console.WriteLine();
        }
    }
}
