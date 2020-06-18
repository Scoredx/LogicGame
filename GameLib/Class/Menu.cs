using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGame
{
    class Menu
    {
        public static void MainMenu()
        {   
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition((Console.WindowWidth - " WELCOME TO 2048".Length) / 2, Console.CursorTop);
            Console.WriteLine(" WELCOME TO 2048");
            Console.SetCursorPosition((Console.WindowWidth - "      MENU     ".Length) / 2, Console.CursorTop);
            Console.WriteLine("      MENU     ");
            Console.SetCursorPosition((Console.WindowWidth - "1.--START GAME--".Length) / 2, Console.CursorTop);
            Console.WriteLine("1. START GAME    ");
            Console.SetCursorPosition((Console.WindowWidth - "2.---OPTIONS---".Length) / 2, Console.CursorTop);
            Console.WriteLine("2.   OPTIONS   ");
            Console.SetCursorPosition((Console.WindowWidth - "3.----EXIT-----".Length) / 2, Console.CursorTop);
            Console.WriteLine("3.    EXIT    ");
            Console.SetCursorPosition((Console.WindowWidth - "(Choose using numbers)".Length) / 2, Console.CursorTop);
            Console.WriteLine("(Choose using numbers)");
            Console.SetCursorPosition((Console.WindowWidth - "x".Length) / 2, Console.CursorTop);

                
            bool menu = true;
            while (menu)
            {
                string menuInput = Console.ReadLine();

                switch (menuInput)
                {
                    case "1":
                        return;
                        break;
                    case "2":
                        Options();
                        menu = false;
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter valid option");
                        break;
                }
            }
        }

        static void Options()
        {
            Console.WriteLine("Set difficulty level: \n1.NORMAL\n2.HIGH\n3.BACK");
            bool menu = true;
            while (menu)
            {
                string menuInput = Console.ReadLine();
                switch (menuInput)
                {
                    case "1":
                        //set dif to normal
                        menu = false;
                        break;
                    case "2":
                        //set dif to high
                        menu = false;
                        break;
                    case "3":
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Enter valid option");
                        break;
                }
            }
        }
    }
}
