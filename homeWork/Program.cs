namespace homeWork
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// N1
			Console.WriteLine("Enter numbers to adding, subtracting, multiplying and dividing.\n");
			Console.Write("First Number: ");
			string? numberOneString = Console.ReadLine();
			bool succeed = double.TryParse(numberOneString, out double numberOne);

			while (!succeed) {
				Console.Write("First Number: ");
				numberOneString = Console.ReadLine();
				succeed = double.TryParse(numberOneString, out numberOne);
			}

			Console.Write("Choose your expression (\"+\", \"-\", \"*\", \"/\"): ");
			string? expression = Console.ReadLine();
			while (expression != "+" && expression != "-" && expression != "*" && expression != "/")
			{
				Console.Write("Choose your expression (\"+\", \"-\", \"*\", \"/\"): ");
				expression = Console.ReadLine();
			}

			Console.Write("Second Number: ");
			string? numberTwoString = Console.ReadLine();
			succeed = double.TryParse(numberTwoString, out double numberTwo);
			while (!succeed)
			{
				Console.Write("Second Number: ");
				numberTwoString = Console.ReadLine();
				succeed = double.TryParse(numberTwoString, out numberTwo);
			}

			switch (expression)
			{
				case "+":
					Console.WriteLine($"{numberOne} + {numberTwo} = {numberOne + numberTwo}");
					break;
				case "-":
					Console.WriteLine($"{numberOne} - {numberTwo} = {numberOne - numberTwo}");
					break;
				case "*":
					Console.WriteLine($"{numberOne} * {numberTwo} = {numberOne * numberTwo}");
					break;
				case "/":
					Console.WriteLine($"{numberOne} / {numberTwo} = {numberOne / numberTwo}");
					break;
			}

			Console.Write("\nType \"next\" to see next homework: ");
			string? toNextHomeWork = Console.ReadLine();
			while (toNextHomeWork != "next")
			{
				Console.Write("Type \"next\" to see next homework: ");
				toNextHomeWork = Console.ReadLine();
			}

			Console.WriteLine("");

			// N2
			for (int i = 0; i < 8; i++)
			{
				string leftSide = "*";
				string result = "";
				if (i == 0)
					result = leftSide;
				else if (i == 7)
					result = "* *  * *";
				else
					result = leftSide + result.PadLeft(i - 1) + "*";
				Console.WriteLine(result);
			}

			Console.WriteLine("");

			for (int i = 0; i < 8; i++)
			{
				string rightSide = "*";
				string result = "";
				if (i == 0)
					result = "* *  * *";
				else if (i == 7)
					result = "*".PadLeft(8);
				else
					result = "*".PadLeft(i + 1) + rightSide.PadLeft(7 - i);
				Console.WriteLine(result);
			}

			Console.WriteLine("");

			for (int i = 0; i < 8; i++)
			{
				string leftSide = "*";
				string result = "*";
				if (i == 0)
					result = "* *  * *";
				else if (i == 7)
				{
					result = leftSide;
				}
				else
					result = leftSide + "*".PadLeft(7 - i);
				Console.WriteLine(result);
			}

			Console.WriteLine("");

            for (int i = 0; i < 8; i++)
            {
				string rightSide = "*";
				string result = "*";
				if (i == 0)
					result = rightSide.PadLeft(8);
				else if (i == 7)
					result = "* *  * *";
				else
					result = "*".PadLeft(8 - i) + rightSide.PadLeft(i);
				Console.WriteLine(result);
            }
        }
	}
}
