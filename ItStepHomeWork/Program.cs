using System.Text.Json;
using System.Linq;
namespace ATM
{
	internal class ATM
	{


		static void Main(string[] Args)
		{
			Console.WriteLine(NoSpace("asdasd  asd asd"));
			string NoSpace(string input)
			{
				return input.Replace(" ", "");
			}
		}
	}
}