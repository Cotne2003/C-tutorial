namespace GuessNumber
{
	internal class GuessNumber
	{
		static void Main(string[] Args)
		{
			Console.WriteLine("Welcome to \"Guess the Number\"! The rules are simple: guess the number between 1 and 100.\n");
			string? restart = "yes";

			while (restart == "yes")
			{
				Random random = new Random();

				int targetNumber = random.Next(1, 101);
				int attempts = 0;

				while (true)
				{
					int guess = GetNumber("Enter your guess: ");
					attempts++;

					if (guess > targetNumber)
					{
						Console.WriteLine($"Attempt {attempts}: Too high!");
					}
					else if (guess < targetNumber)
					{
						Console.WriteLine($"Attempt {attempts}: Too low!");
					}
					else
					{
						Console.WriteLine($"Attempt {attempts}: Congratulations! You guessed the number!");
						break;
					}
				}
				Console.WriteLine("\nDo you want restart? (write \"yes\" to restart. Press any key to leave.)");
				restart = Console.ReadLine();
				Console.Clear();
			}

			int GetNumber(string prompt)
			{
				while (true)
				{
					Console.Write(prompt);
					if (int.TryParse(Console.ReadLine(), out int number))
						return number;
					Console.WriteLine("Invalid Number. Please enter a valid number.");
				}
			}
		}
	}
}