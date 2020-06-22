using LogicGame;
using System;
using System.Collections.Generic;

namespace GameLib
{
    class library
    {
        public enum movDirection
        {
            Up,
            Right,
            Down,
            Left,
        }
        public class ColorOutput : IDisposable
        {
            public ColorOutput(ConsoleColor fColor, ConsoleColor bColor = ConsoleColor.DarkGray)
            {
                Console.ForegroundColor = fColor;
                Console.BackgroundColor = bColor;
            }
            public void Dispose()
            {
                Console.ResetColor();
            }
        }
        public static ConsoleColor GetColor(ulong num)
        {
            switch (num)
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
                default:
                    return ConsoleColor.Red;
            }
        }
    }
}

