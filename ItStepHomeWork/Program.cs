using System.Text.Json;
using System.Linq;
namespace ATM
{
	internal class ATM
	{
		static void Main(string[] Args)
		{

			IEnumerable<string> GooseFilter(IEnumerable<string> birds)
			{
				// return IEnumerable of string containing all of the strings in the input collection, except those that match strings in geese
				string[] geese = new string[] { "African", "Roman Tufted", "Toulouse", "Pilgrim", "Steinbacher" };
				return (IEnumerable<string>)birds.ToList().Where(b => !geese.Contains(b));
			}
		}
	}
}