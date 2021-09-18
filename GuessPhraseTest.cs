using NUnit.Framework;
using System;

namespace ConsoleUITest
{
    class GuessPhraseTest
    {

        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game("Secret");
        }

        [Test]
        public void GuessPhrase_Returns_True_If_Correct_Phrase_IsGuessed()
        {
            Assert.IsTrue(game.GuessPhrase("Secret"));
        }

        [Test]
        public void GuessPhrase_Returns_False_If_Wrong_Phrase_IsGuessed()
        {
            Assert.IsFalse(game.GuessPhrase("No Secret"));
        }

        [Test]
        public void GuessPhrase_Returns_False_If_Number_String__IsGuessed()
        {
            Assert.IsFalse(game.GuessPhrase("1"));
        }


    }
}
