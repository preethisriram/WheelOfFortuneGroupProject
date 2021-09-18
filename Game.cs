using System;
using System.Collections.Generic;
using System.Text;

public class Game
{
	public String Phrase { get; set; }
	public HashSet<Char> CorrectLettersGuessed { get; set; }
	public HashSet<char> AllLetters { get; set; }
	public Game(string phrase)
	{
		Phrase = phrase.ToLower();
		CorrectLettersGuessed = new HashSet<char>();
		AllLetters = new HashSet<char>();
		AddUniqueLetters();
	}

	public void AddUniqueLetters()
    {
		foreach (var letter in Phrase)
		{
			AllLetters.Add(letter);
		}
	}

	/// <summary>
	/// Checks if letter exist in a phrase.
	/// </summary>
	/// <param name="letter">Letter to be checked.</param>
	/// <returns>True if letter exists, otherwise false.</returns>
	public bool GuessLetter(Char letter) 
	{
		char lowercase = char.ToLower(letter);
		if (AllLetters.Contains(lowercase))
        {
			if (CorrectLettersGuessed.Contains(lowercase))
				throw new Exception("Cannot add duplicate letter");
			CorrectLettersGuessed.Add(lowercase);
			return true;
		}
			
		else
			return false;
	}

	///<summary> 
	///Will check if the Phrase off the user guessed is right or wrong. Will compare user input to the phrase that needs to be guessed 
	///</summary>
	/// <param name="phrase"> String Input from user </param>
	/// <returns>Function will return true or false if the phrase was guess correcntly or incorrectly </returns>
	public bool GuessPhrase(String phrase) 
	{
		return phrase.ToLower() == Phrase.ToLower();
	}

	/// <summary>
	/// The method checks if all the unique correct letters guessed by the user 
	/// matches with all the unique letters in the phrase
	/// </summary>
	/// <returns>
	/// Returns a boolean 
	/// </returns>
	public bool WereAllLettersGuessed() 
	{ 
		return CorrectLettersGuessed.Count == AllLetters.Count;	
	}

	public String DisplayPhrase()
	{
		HashSet<char> ponctuation = new HashSet<char> { ' ', ',', '.', '!', ';', ':' };
		char wildcard = '-';
		StringBuilder sb = new StringBuilder(this.Phrase);
		foreach (var letter in this.Phrase)
		{
			Boolean hasLetter = this.CorrectLettersGuessed.Contains(letter);
			if (!hasLetter && letter != wildcard && !ponctuation.Contains(letter))
			{
				sb.Replace(letter, wildcard);
			}
		}

		return sb.ToString();
	}
	public void Play()
    {
		Console.WriteLine("Welcome to Wheel Of Fortune!");
		bool userWon = false;
		while (!userWon)
        {
			string message = "";
			Console.WriteLine($"Phrase: {DisplayPhrase()}");

            Console.WriteLine("Choose an option");
            Console.WriteLine("1 - Guess Letter \n2 - Guess Phrase \n3 - Exit");
            char option = Console.ReadKey().KeyChar;
            Console.WriteLine("");
            switch (option)
            {
                case '1':
                    Console.WriteLine("Type a letter");
					char letter = Console.ReadKey().KeyChar;
                    try
                    {
                        bool WasLetterCorrect = GuessLetter(letter);
						if (WasLetterCorrect)
						{
							message = $"\nYou correctly guessed the letter \"{letter}\"";
							userWon = WereAllLettersGuessed();
						}
						else
						{
							message = "Your guess was incorrect.Try again!";
						}
					}
                    catch (Exception e)
                    {
						message = e.Message;
                    }
					
					break;
                case '2':
                    Console.WriteLine("Type the phrase.");
					string phrase = Console.ReadLine();
					userWon = GuessPhrase(phrase);
					if (userWon)
                        message = "You corrrectly guessed the phrase!";
					else
                        message = "Your guess was incorrect. Try again!";
                    break;
                case '3':
					Environment.Exit(0);
                    break;
                default:
                    message = "Invalid option.The available option are: 1, 2, 3";
                    break;
            }
            
			Console.Clear();
            Console.WriteLine(message);
		}
		Console.WriteLine("You won! Congratulations");
	}
}
