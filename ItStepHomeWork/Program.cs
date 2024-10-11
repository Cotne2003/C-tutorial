using System.Diagnostics.Metrics;

internal class Program
{
	static void Main(string[] args)
	{
		try
		{
			int format = int.Parse(Console.ReadLine());
		}
		catch (Exception)
		{
			Console.WriteLine("Format exception here.");
		}

		try
		{
			int zero = int.Parse(Console.ReadLine());
			int dividedZero = 10 / zero;
		}
		catch (Exception)
		{
			Console.WriteLine("Divided by zero exception here.");
		}

		string nullString = null;
		try
		{
			Console.WriteLine(nullString.Length);
		}
		catch (Exception)
		{
			Console.WriteLine("Null exception is here");
		}

		try
		{
			int[] arr = new int[3];
			arr[5] = 3;
		}
		catch (Exception)
		{
			Console.WriteLine("Index out of range exception here");
		}
	}
}