internal class Program
{
	static void Main(string[] args)
	{
		int a = 1;
		int b = 2;
		int c = 3;

		NewCont(a, b, c);

		static void NewCont<T>(T a,T b,T c)
		{
			MyContainer<T> Cont = new MyContainer<T>(a, b, c);

			Console.WriteLine($"{Cont.Item[0]} {Cont.Item[1]} {Cont.Item[2]}");
		}
	}
	class MyContainer<T>
	{
		public T[] Item = new T[3];
        public MyContainer(T a, T b, T c)
        {
			Item[0] = a;
			Item[1] = b;
			Item[2] = c;
        }
    }
}