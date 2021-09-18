using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;


namespace ConsoleUITest
{
    class WereAllLettersGuessedTest
    {
        public class AllLettersGuessedTest
        {
            private Game game;

            [SetUp]
            public void Setup()
            {
                game = new Game("Explore");
            }

            [Test]

            public void CorrectLettersGuessedHasAllLettersInThePhraseTest()
            {
                game.CorrectLettersGuessed = new HashSet<char> { 'e', 'x', 'p', 'l', 'o', 'r', 'e' };
         
                Assert.IsTrue(game.WereAllLettersGuessed());

            }
            [Test]
            public void CorrectLettersGuessedDoesNotHaveAllLettersInThePhraseTest()
            {
                HashSet<char> CorrectLettersGuessed = new HashSet<char> { 'e', 'x', 'p', 'l', 'o' };
       
                Assert.IsFalse(game.WereAllLettersGuessed());
            }


        }
    }
}
