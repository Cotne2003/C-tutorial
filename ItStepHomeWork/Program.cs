using System;
using System.Collections.Generic;

internal class Program
{
	public delegate bool MyDelegate(int a, int b);

	static void Main(string[] args)
	{
		// Declare the list of numbers
		List<int> numbers = new List<int> { 3, 1, 5, 2, 4 };

		// Create a delegate instance using the IsMuch method
		MyDelegate myDelegate1 = IsMuch;

		// Get the sorted numbers based on the delegate
		List<int> sortedNums = SortedNumbers(numbers, myDelegate1);

		// Print sorted numbers
		foreach (int num in sortedNums)
		{
			Console.WriteLine(num);
		}
	}

	// Method to sort numbers based on a condition
	static List<int> SortedNumbers(List<int> numbers, MyDelegate condition)
	{
		List<int> result = new List<int>();

		// Simple bubble sort-like approach to sorting
		List<int> temp = new List<int>(numbers);
		for (int i = 0; i < temp.Count - 1; i++)
		{
			for (int j = i + 1; j < temp.Count; j++)
			{
				if (!condition(temp[i], temp[j]))
				{
					// Swap the elements if the condition is not met
					int swap = temp[i];
					temp[i] = temp[j];
					temp[j] = swap;
				}
			}
		}

		result = temp;
		return result;
	}

	// Delegate condition for sorting in descending order
	static bool IsMuch(int a, int b)
	{
		return a > b;
	}

	// Delegate condition for sorting in ascending order (alternative)
	static bool IsLess(int a, int b)
	{
		return a < b;
	}
}
