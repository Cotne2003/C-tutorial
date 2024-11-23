namespace HangMan
{
	internal class HangMan
	{
		static void Main(string[] Args)
		{
			Console.WriteLine("Hello, this is \"Hang Man\".");


			Random random = new Random();
			int rightAnswer = random.Next(1, 101);
			Console.WriteLine(rightAnswer);

			int inputNumber = GetNumber("Choose Your Number: ");

			int attempt = 0;

			while (inputNumber != rightAnswer)
			{
				if (rightAnswer == inputNumber)
					Console.WriteLine("its matched, bravooo!!!!");
				else if (inputNumber > rightAnswer)
					Console.WriteLine("To up");
				else if (inputNumber > rightAnswer)
					Console.WriteLine("To down");
			}



			int GetNumber(string prompt)
			{
				while (true)
				{
					Console.Write(prompt);
					if (int.TryParse(Console.ReadLine(), out int number))
						return number;
					Console.WriteLine("Invalid Number.");
				}
			}
		}
	}
}