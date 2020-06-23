using System;

namespace LogicGame
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.SetWindowSize(30, 8); //setting cmd size
                Console.BackgroundColor = ConsoleColor.DarkGray; //changing background color
                Console.Clear();
                Menu.MainMenu();
                Console.Clear();
                Console.SetWindowSize(30, 16);
                gameClass game = new gameClass(); //creating game object
                game.Play(); // starting game 
            }
           
        }
    }
    // Filip szewczyk 
    // 12486
    // konwZ/Lab11
}
