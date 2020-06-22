using System;

namespace LogicGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(30, 15);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Menu.MainMenu();
            Console.Clear();
            ClGame.Game game = new Game();
            ClGame.Play();

        }
    }
    // Filip szewczyk 
    // 12486
    // konwZ/Lab11
}
