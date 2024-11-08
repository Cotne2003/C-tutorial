namespace Linq
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<int> list1 = new List<int>() { 1, 2, 3, 5, 4, 4, 3, 2, 23 };
			List<int> list2 = new List<int>() { 5, 6, 7, 3, 1, 5, 8 };

			Console.WriteLine("Union");

			List<int> unionList = list1.Union(list2).ToList();
			unionList.ForEach(x => Console.Write(x + " "));

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Intersection");

			List<int> interectionList = list1.Intersect(list2).ToList();
			interectionList.ForEach(x => Console.Write(x + " "));

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Distinct");

			List<int> distinctList = list1.Distinct().ToList();
			distinctList.ForEach(x => Console.Write(x + " "));

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Except");

			List<int> exceptList = list1.Except(list2).ToList();
			exceptList.ForEach(x => Console.Write(x + " "));

			Console.WriteLine();
			Console.WriteLine();
		}
	}
}