namespace ATM
{
	internal class ATM
	{
		static void Main(string[] Args)
		{
			static int binaryArrayToNumber(int[] BinaryArray)
			{
				string result = "";
				foreach (int i in BinaryArray)
				{
					result += i;
				}
				return int.Parse(result);
			}
			binaryArrayToNumber([1, 2, 3]);
		}
	}
}