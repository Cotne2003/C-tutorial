namespace DelegateBasicExample
{

	internal class Program
	{
		delegate void LogDel(string text, DateTime dateTime);
		static void Main(string[] args)
		{
			LogDel logDel = new LogDel(LogTextScreen);

			logDel("text", DateTime.Now);
		}
		static void LogTextScreen(string text, DateTime dateTime)
		{
			Console.WriteLine($"{dateTime}: {text}");
		}
	}
}