using NUnit.Framework;
using System;

namespace ConsoleUITest
{
    public class GuessLetterTest
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game("Secret");
        }
      
        [Test]
        public void GuessLetter_Returns_True_If_Correct_Letter_IsGuessed()
        {
            Assert.IsTrue(game.GuessLetter('s'));
        }
        [Test]
        public void GuessLetter_Ignores_Letter_Case()
        {
            Assert.IsTrue(game.GuessLetter('T'));
        }
        [Test]
        public void GuessLetter_Returns_False_OnEmpty()
        {
            Assert.IsFalse(game.GuessLetter(' '));
        }
        [Test]
        public void GuessLetter_Returns_False_ForWrong_Letter()
        {
            Assert.IsFalse(game.GuessLetter('w'));
        }
        [Test]
        public void GuessLetter_Throws_Exception_If_Duplicate_Letter_IsGuessed()
        {
            game.GuessLetter('s');
            Assert.Throws<Exception>(()=> game.GuessLetter('s'));
        }
    }
}