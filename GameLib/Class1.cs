using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    class library
    {
        public static int Rows;
        public static int Cols;
        public static Random rnd = new Random();
        public static ulong Score;
        public static ulong[,] Matrix; //matrix 4x4
        public static bool diff;

        public static void Display()
        {
            Console.Clear();
            Console.WriteLine();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    using (new Color(GetNumberColor(Matrix[i, j])))
                    {
                        Console.Write(string.Format("{0,6}", Matrix[i, j]));
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("Score: " + Score);
            Console.WriteLine();
        }
        class Color : IDisposable
        {
            public Color(ConsoleColor fColor, ConsoleColor bColor = ConsoleColor.White)
            {
                Console.ForegroundColor = fColor;
                Console.BackgroundColor = bColor;
            }

            public void Dispose()
            {
                Console.ResetColor();
            }
        }
        public enum movDirection
        {
            Right,
            Down,
            Up,
            Left,
        }

        public static ConsoleColor GetNumberColor(ulong num) //color of numbers
        {
            switch (num)
            {
                case 0:
                    return ConsoleColor.DarkGray;
                case 2:
                    return ConsoleColor.Gray;
                case 4:
                    return ConsoleColor.DarkMagenta;
                case 8:
                    return ConsoleColor.Magenta;
                case 16:
                    return ConsoleColor.DarkGreen;
                case 32:
                    return ConsoleColor.Green;
                case 64:
                    return ConsoleColor.DarkYellow;
                case 128:
                    return ConsoleColor.Yellow;
                case 256:
                    return ConsoleColor.DarkCyan;
                case 512:
                    return ConsoleColor.Cyan;
                case 1024:
                    return ConsoleColor.DarkRed;
                case 2048:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Red;
            }
        }
    }
}
