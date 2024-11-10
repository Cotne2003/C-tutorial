using System.Linq;

namespace Linq
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Sorter sorter = new Sorter();
			ComparisonDelegate comparison = sorter.Assending;

			List<int> integers = new List<int>() { 1, 2, 3, 4, 5 };
			

		}

		delegate int ComparisonDelegate(int a, int b);

		class Sorter
		{
			public int Assending(int a, int b)
			{
				if (a > b)
					return 1;
				if (a < b)
					return -1;
				return 0;
			}
			
			public int Desending(int a, int b)
			{
				if (a > b)
					return -1;
				if (a < b)
					return 1;
				return 0;
			}
		}
	}
}