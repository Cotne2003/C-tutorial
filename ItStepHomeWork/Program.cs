internal class Program
{
	static void Main(string[] args)
	{
		Armstrong test = new Armstrong(153);
		Console.WriteLine(test.IsArmstrong());
	}
}

class Armstrong : IArmstrong
{
    public int Num { get; set; }
    public Armstrong(int num)
    {
        Num = num;
    }
	public bool IsArmstrong()
	{
		string numToString = Num.ToString();
		int count = 0;
		for (int i = 0; i < numToString.Length; i++)
		{
			int.TryParse(numToString[i].ToString(), out int stringToNum);
			count += (int)Math.Pow(stringToNum, 3);
		}
		if (Num == count)
			return true;
		return false;
	}
}

interface IArmstrong
{
	public bool IsArmstrong();
}


