using System.Text.Json;

namespace ATM
{
	internal class ATM
	{
		static void Main(string[] Args)
		{
			Console.WriteLine("Welcome to ATM\n");

			string DBPath = "C:\\Users\\Tsotne\\OneDrive\\Desktop\\ItStepAcademyProjects\\ATMApp\\DB\\";
			string ATMPath = Path.Combine(DBPath, "atm.json");

			DirectoryInfo DBFolder = new DirectoryInfo(DBPath);

			string test = "{\"Name\":\"Tsotne\"}";

			User hehe = JsonSerializer.Deserialize<User>(test);
			Console.WriteLine(hehe.Name);
		}

		public class User
		{
			public string Name { get; set; }
		}
	}
}