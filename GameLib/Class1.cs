using System;
using LogicGame;

namespace GameLib
{
    class library
    {
        public static bool action(ulong[,] board, movDirection dir, out ulong points)
        {
            int Rows = board.GetLength(0);
            int Columns = board.GetLength(1);
            bool Updated = false;
            points = 0;

            //movement 
            bool inRow = dir == movDirection.Left || dir == movDirection.Right;
            bool isIncreasing = dir == movDirection.Left || dir == movDirection.Up;

            int oCount = inRow ? Rows : Columns;
            int iCount = inRow ? Columns : Rows;
            int iStart = isIncreasing ? 0 : iCount - 1;
            int iEnd = isIncreasing ? iCount - 1 : 0;

            Func<int, int> drop = isIncreasing? new Func<int, int>(iIndex => iIndex - 1) : new Func<int, int>(iIndex => iIndex + 1);
            Func<int, int> reverseDrop = isIncreasing ? new Func<int, int>(iIndex => iIndex + 1) : new Func<int, int>(iIndex => iIndex - 1);
            Func<ulong[,], int, int, ulong> Value = inRow ? new Func<ulong[,], int, int, ulong>((x, i, j) => x[i, j]) : new Func<ulong[,], int, int, ulong>((x, i, j) => x[j, i]);
            Func<int, bool> iCondition = index => Math.Min(iStart, iEnd) <= index && index <= Math.Max(iStart, iEnd);
            Action<ulong[,], int, int, ulong> setValue = inRow ? new Action<ulong[,], int, int, ulong>((x, i, j, v) => x[i, j] = v) : new Action<ulong[,], int, int, ulong>((x, i, j, v) => x[j, i] = v);

            for (int i = 0; i<oCount; i++)
            {
                for (int j = iStart; iCondition(j); j = reverseDrop(j))
                {
                    int newJ = j;
                    if (Value(board, i, j) == 0)
                    {
                        continue;
                    }
                    do
                    {
                        newJ = drop(newJ);
                    }
                    while (iCondition(newJ) && Value(board, i, newJ) == 0);
                        //merge matching pair 
                    if (iCondition(newJ) && Value(board, i, newJ) == Value(board, i, j))
                    {
                        ulong newValue = Value(board, i, newJ) * 2;
                        setValue(board, i, newJ, newValue);
                        setValue(board, i, j, 0);
                        Updated = true;
                        points += newValue;
                    }
                    else //stack along if not suitable to merge
                    {
                        newJ = reverseDrop(newJ); 
                        if (newJ != j)
                        {
                            Updated = true;
                        }
                        ulong value = Value(board, i, j);
                        setValue(board, i, j, 0);
                        setValue(board, i, newJ, value);
                    }
                }
            }
            return Updated;
        }
        public enum movDirection //movement 
        {
            Up,
            Right,
            Down,
            Left,
        }
        public class Color : IDisposable
        {
            public Color(ConsoleColor fColor, ConsoleColor bColor = ConsoleColor.DarkGray)
            {
                Console.ForegroundColor = fColor;
                Console.BackgroundColor = bColor;
            }
            public void Dispose()
            {
                Console.ResetColor();
            }
        }
        public static ConsoleColor GetColor(ulong cell) //color dictionary
        {
            switch (cell)
            {
                case 0:
                    return ConsoleColor.Black;
                case 2:
                    return ConsoleColor.DarkCyan;
                case 4:
                    return ConsoleColor.Cyan;
                case 8:
                    return ConsoleColor.DarkBlue;
                case 16:
                    return ConsoleColor.Blue;
                case 32:
                    return ConsoleColor.DarkGreen;
                case 64:
                    return ConsoleColor.Green;
                case 128:
                    return ConsoleColor.DarkYellow;
                case 256:
                    return ConsoleColor.Yellow;
                case 512:
                    return ConsoleColor.DarkMagenta;
                case 1024:
                    return ConsoleColor.Magenta;
                case 2048:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.White;
            }
        }
        public static void win(ulong cell) // win condition
        {
            if (cell > 1024)
            {   
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.DarkGray;
                gameClass.win = true;
            }
        }
    }
}

