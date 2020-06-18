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
            Console.WriteLine(" Welcome to 2048");
            Console.WriteLine("      MENU     ");
            Console.WriteLine("1.--START GAME--\n2.---OPTIONS---\n3.----EXIT----");
            Console.WriteLine("(Choose using numbers)");

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
