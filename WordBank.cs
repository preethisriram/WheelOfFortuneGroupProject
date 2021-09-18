using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    class WordBank
    {
        private static List<String> wordBank = new List<string> { "Roses are red", "Violets are blue", "Work hard and dream big", "Enjoy the small moments", "All is well", "Be a voice, not an echo" };
     
        public static String GetRandomWord()
        {
            Random rndm = new Random();
            int randomWord = rndm.Next(0, wordBank.Count);
            return wordBank[randomWord];
        }
    }
}
