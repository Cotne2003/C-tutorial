internal class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine(FindMaximum(30, 20));
		Console.WriteLine(FindMaximum("a", "b"));

		static T FindMaximum<T>(T value1, T value2) where T : IComparable<T>
		{
			if (value1.CompareTo(value2) > 0)
			{
				return value1;
			}
			else
			{
				return value2;
			}
		}
	}
}