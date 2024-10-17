namespace DelegateBasicExample
{

	internal class Program
	{
		delegate void LogDel(string text);
		static void Main(string[] args)
		{
			LogDel logDel = new LogDel(LogTextScreen);

			logDel("text");
		}
		static void LogTextScreen(string text)
		{
			Console.WriteLine($"{DateTime.Now}: {text}");
		}
	}
}