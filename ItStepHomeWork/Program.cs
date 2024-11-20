namespace FileStreams
{
	internal class Program
	{
		static void Main(string[] args)
		{
			const string mainPath = "C:\\Users\\Tsotne\\OneDrive\\Desktop\\";
			DirectoryInfo desktopInfo = new DirectoryInfo(mainPath);

			DirectoryInfo loginData = new DirectoryInfo(mainPath + "Login Data");
			if (!loginData.Exists)
			{
				loginData = desktopInfo.CreateSubdirectory("Login Data");
			}

			string dateTime = DateTime.Now.ToString("MM-dd-yyyy");

			DirectoryInfo loginInfo = new DirectoryInfo(loginData.FullName + $"\\Login at {dateTime}");
			if (!loginInfo.Exists)
			{
				loginInfo = loginData.CreateSubdirectory($"Login at {dateTime}");
			}

		}
	}
}