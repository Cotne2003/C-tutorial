using System.Linq;

namespace Linq
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<double> nums = new List<double>() { 1, 2, 3};
			List<double> nums2 = new List<double>() { 1, 2, 3, 4, 6, 5, 8, 7};
			nums2.Sort();
			Console.WriteLine(nums);
			Console.WriteLine(nums.Median());
			Console.WriteLine(nums2.Median());
		}
	}
	static class ListExtension
	{
		public static double Median(this List<double> list)
		{
			if (list.Count % 2 == 0)
				return (list[list.Count / 2] + list[list.Count / 2 - 1]) / 2;

			return list[list.Count / 2];
		}
	}
}