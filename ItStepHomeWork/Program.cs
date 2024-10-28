using System;
using System.Collections.Generic;

internal class Program
{
	static void Main(string[] args)
	{
		Func<string, string, bool> IsStringEqual;
		Action<string, int> DisplayPerson = (str, age) => Console.WriteLine($"{str} {age}");
	}
}
