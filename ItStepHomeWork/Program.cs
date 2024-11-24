namespace HangMan
{
	internal class HangMan
	{
		static void Main(string[] Args)
		{

			string[] words = new string[] { "tiger", "house", "tree", "earth", "building", "castle", "doughter", "horse", "animal", "human" };

			string? restart = "yes";

			while (restart == "yes")
			{
				Random random = new Random();
				int randomWordIndex = random.Next(words.Length);
				string word = words[randomWordIndex];
				string health = "*****";

				string sketch = new string('-', word.Length);

				Console.WriteLine(word);


				char[] wordToCharArray = word.ToCharArray();
				char[] sketchToCharArray = sketch.ToCharArray();

				while (sketch != word)
				{
					Console.Clear();
					Console.WriteLine("Welcome to \"Hang Man\"! The rules are simple: guess the word within 5 attemtps.\n");
					Console.WriteLine(sketch);
					Console.WriteLine($"Health: {health}");
					if (health.Length == 0)
					{
						Console.WriteLine($"Game over! The correct word was: {word}");
						break;
					}

					char userInput = GetChar("Please enter a letter: ");
					if (word.Contains(userInput))
					{
						for (int i = 0; i < wordToCharArray.Length; i++)
						{
							if (wordToCharArray[i] == userInput && sketchToCharArray[i] == '-')
								sketchToCharArray[i] = userInput;
						}
					}
					else
					{
						health = health.Remove(health.Length - 1, 1);
					}
					Console.Clear();
					sketch = new string(sketchToCharArray);
					Console.WriteLine(sketch);
					Console.WriteLine($"Health: {health}");
					Console.WriteLine($"Congratulations! You guessed the word: {word}");
				}
				Console.WriteLine("\nDo you want restart? (write \"yes\" to restart. Press any key to leave.)");
				restart = Console.ReadLine();
			}

			char GetChar(string prompt)
			{
				while (true)
				{
					Console.Write(prompt);
					if (char.TryParse(Console.ReadLine(), out char test))
						return test;
					Console.WriteLine("invalid character");
				}
			}
		}
	}
}