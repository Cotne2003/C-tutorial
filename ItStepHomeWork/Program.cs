string? userInput = Console.ReadLine();

bool isNum = byte.TryParse(userInput, out byte userNum);

if (isNum)
{
	if (Enum.IsDefined(typeof(Months), userNum))
	{
		Console.WriteLine(Enum.GetName(typeof(Months), userNum));
	}
	else
	{
		Console.WriteLine("Not in the list");
	}
}
else
{
	if (Enum.IsDefined(typeof(Months), userInput))
	{
        foreach (Months item in Enum.GetValues(typeof(Months)))
        {
			if (userInput == item.ToString())
			{
				Console.WriteLine((int)item);
			}
        }
	}
	else
	{
		Console.WriteLine("Not in the list");
	}
}

enum Months : byte
{
	Jan = 1,
	Feb,
	Mar,
	Apr,
	May,
	Jun,
	Jul,
	Aug,
	Sep,
	Oct,
	Nov,
	Dec
}