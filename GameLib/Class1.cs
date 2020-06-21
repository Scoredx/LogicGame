using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    class library
    {
        private static ConsoleColor GetNumberColor(ulong num)
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

        class ColorOutput : IDisposable
        {
            public ColorOutput(ConsoleColor color)
            {
                Console.ForegroundColor = color;
            }
            public void Dispose()
            {
                Console.ResetColor();
            }
        }

        enum movDirection
        {
            Right,
            Down,
            Up,
            Left,
        }
    }
}
