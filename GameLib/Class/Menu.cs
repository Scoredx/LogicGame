using System;
using GameLib;

namespace LogicGame
{
    class Menu
    {   
        //vars
        public static bool diff = true; // setting diff
        static void menuText()
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
        }

        static void optionsText()
        {
            Console.SetCursorPosition((Console.WindowWidth - "Set difficulty level: ".Length) / 2, Console.CursorTop);
            Console.WriteLine(" Set difficulty level:");
            Console.SetCursorPosition((Console.WindowWidth - "1.     NORMAL  ".Length) / 2, Console.CursorTop);
            Console.WriteLine("1.   NORMAL  ");
            Console.SetCursorPosition((Console.WindowWidth - "2.      HIGH   ".Length) / 2, Console.CursorTop);
            Console.WriteLine("2.    HIGH    ");
            Console.SetCursorPosition((Console.WindowWidth - "3.      BACK   ".Length) / 2, Console.CursorTop);
            Console.WriteLine("3.    BACK   ");
        }

        public static void MainMenu()
        {
            bool menu = true;
            while (menu)
            {
                //main menu
                menuText();
                string menuChoice =  Console.ReadLine();
                Console.Clear();
                switch (menuChoice)
                {
                    case "1":
                        return;
                    case "2":
                        //options
                        bool options = true;
                        while (options)
                        {
                            optionsText();
                            Console.SetCursorPosition((Console.WindowWidth - "x".Length) / 2, Console.CursorTop);
                            string optionsChoice = Console.ReadLine();
                            Console.Clear();
                            switch (optionsChoice)
                            {
                                case "1":
                                    diff = true;
                                    options = false;
                                    break;
                                case "2":
                                    diff = false;
                                    options = false;
                                    break;
                                case "3":
                                    options = false;
                                    break;
                                default:
                                    Console.SetCursorPosition((Console.WindowWidth - "Enter valid option".Length) / 2, Console.CursorTop);
                                    Console.WriteLine("Enter valid option");
                                    break;
                            }
                        }
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.SetCursorPosition((Console.WindowWidth - "Enter valid option".Length) / 2, Console.CursorTop);
                        Console.WriteLine("Enter valid option");
                        break;
                }
            }
        }
    }
}
