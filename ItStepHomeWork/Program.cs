namespace ATM
{
	internal class ATM
	{
		static void Main(string[] Args)
		{
			static double SumArray(double[] array)
			{
				//double sum = 0;

				//foreach (double num in array)
				//{
				//	sum += num;
				//}

				return array.Sum();

				//return sum;
			}

			Console.WriteLine(SumArray([1, 3, 4]));

		}
	}
}