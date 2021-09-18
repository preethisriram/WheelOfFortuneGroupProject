using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace ConsoleUITest
{
    class DisplayMessageTest
    {

        [Test]
        public void PhraseWithBlankSpace()
        {
            string phrase = "Hello world";
            string expected = "----- -----";
            Game game = new Game(phrase);
            string displayedPhrase = game.DisplayPhrase();
            Assert.AreEqual(displayedPhrase, expected);
        }

        [Test]
        public void PhraseWithoutGuessingAnyLetters()
        {
            string phrase = "Apple";
            string expected = "-----";
            Game game = new Game(phrase);
            string displayedPhrase = game.DisplayPhrase();
            Assert.AreEqual(displayedPhrase, expected);
        }

        [Test]
        public void PhraseAfterGuessingSomeLetters()
        {
            string phrase = "Apple";
            string expected = "-pp--";
            Game game = new Game(phrase);
            game.CorrectLettersGuessed = new HashSet<char> { 'p' };

            string displayedPhrase = game.DisplayPhrase();
            Assert.AreEqual(displayedPhrase, expected);
        }

        [Test]
        public void PhraseAfterGuessingAllLetters()
        {
            string phrase = "apple";
            string expected = "apple";
            Game game = new Game(phrase);
            game.CorrectLettersGuessed = new HashSet<char> { 'a', 'p', 'l', 'e' };

            string displayedPhrase = game.DisplayPhrase();
            Assert.AreEqual(displayedPhrase, expected);
        }

        [Test]
        public void PhraseWithPonctuation()
        {
            string phrase = "good day, good sir";
            string expected = "---- ---, ---- ---";
            Game game = new Game(phrase);

            string displayedPhrase = game.DisplayPhrase();
            Assert.AreEqual(displayedPhrase, expected);
        }
    }
}
