internal class Program
{
	static void Main(string[] args)
	{
		int[] intArr = new int[] { 1, 2, 3 };
		ChangeArray<int> Test = new ChangeArray<int>(intArr);
		Console.WriteLine("Current Array");
		Test.DisplayArray();

		Console.WriteLine();

		Console.WriteLine("Added first element");
		Test.AddFirst(0);
		Test.DisplayArray();

		Console.WriteLine();

		Console.WriteLine("Added last element");
		Test.AddLast(4);
		Test.DisplayArray();

		Console.WriteLine();

		Console.WriteLine("Removed first element");
		Test.RemoveFirst();
		Test.DisplayArray();

		Console.WriteLine();

		Console.WriteLine("Removed last element");
		Test.RemoveLast();
		Test.DisplayArray();

		Console.WriteLine();

		Console.WriteLine("Added element on our index");
		Test.ChangeIndexOf(2, 4);
		Test.DisplayArray();

		Console.WriteLine();

		Console.WriteLine("Removed element on our index");
		Test.RemoveIndexOf(1);
		Test.DisplayArray();
	}
	class ChangeArray<T>
	{
		private T[] Array;
        public ChangeArray(T[] array)
        {
            Array = array;
        }
		public void AddFirst(T element)
		{
			T[] newArray = new T[Array.Length + 1];

			for (int i = 0; i <= Array.Length; i++)
			{
				if (i == 0)
					newArray[i] = element;
				else
					newArray[i] = Array[i - 1];
			}

			Array = newArray;

		}
		public void RemoveFirst()
		{
			T[] newArray = new T[Array.Length - 1];

			for (int i = 1;  i < Array.Length; i++)
			{
				newArray[i - 1] = Array[i];
			}

			Array = newArray;

		}

		public void AddLast(T element)
		{
			T[] newArray = new T[Array.Length + 1];

			for (int i = 0; i < Array.Length; i++)
				newArray[i] = Array[i];

			newArray[Array.Length] = element;
			Array = newArray;

		}
		public void RemoveLast()
		{
			T[] newArray = new T[Array.Length - 1];

			for (int i = 0; i < Array.Length - 1; i++)
			{
				newArray[i] = Array[i];
			}

			Array = newArray;

		}
		public void ChangeIndexOf(int index, T element)
		{
			if (index >= Array.Length)
				throw new IndexOutOfRangeException();

			Array[index] = element;

		}
		public void RemoveIndexOf(int index)
		{
			if(index >= Array.Length)
				throw new IndexOutOfRangeException();

			T[] newArray = new T[Array.Length - 1];
			for (int i = 0; i < Array.Length; i++)
			{
				if (i < index)
					newArray[i] = Array[i];
				else if (i > index)
					newArray[i - 1] = Array[i];
			}

			Array = newArray;

		}
		public void DisplayArray()
		{
			foreach(T element in Array)
			{
				Console.WriteLine(element);
			}
		}
    }
}