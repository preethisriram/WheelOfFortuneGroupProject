using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            String phrase = WordBank.GetRandomWord();
            Game game = new Game(phrase);
            game.Play();
        }
    }
}
