namespace FileStreams
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//List<int> numbers = new List<int> { 1, 3, 5, 7, 9 };

			//bool result = numbers.Any(x => x % 2 == 0);
			//Console.WriteLine(result);

			//List<string> words = new List<string> { "apple", "banana", "cherry", "date" };

			//bool result = words.Any(s => s.Length > 5);
			//Console.WriteLine(result);

			//List<Student> Students = new List<Student>
			//{
			//	new Student { Name = "Alice", Age = 22 },
			//	new Student { Name = "Bob", Age = 17 },
			//	new Student { Name = "Charlie", Age = 19 }
			//};

			//bool result = Students.Any(s => s.Age < 18);
			//Console.WriteLine(result);

			//List<List<int>> listOfLists = new List<List<int>>
			//{
			//	new List<int> {1, 2, 3},
			//	new List<int> { },
			//	new List<int> { 4, 5 }
			//};

			//bool result = listOfLists.Any(list => list.Count == 0);
			//Console.WriteLine(result);

			//List<User> users = new List<User>
			//{
			//	new User { Name = "John", Persmissions = new List<string> { "Read", "Write" } },
			//	new User { Name = "Jane", Persmissions = new List<string> { "Read", "Admin" } },
			//	new User { Name = "Jane", Persmissions = new List<string> { "Read" } }
			//};
			//bool result = users.Any(user => user.Persmissions.Contains("Admin"));
			//Console.WriteLine(result);

			//List<string> strings = new List<string> { "hello", "", null, "world" };

			//bool result = strings.Any(s => s == null || s.Length == 0);
			//Console.WriteLine(result);

			//List<DateTime> dates = new List<DateTime>
			//{
			//	DateTime.Now.AddDays(1),
			//	DateTime.Now.AddDays(-5),
			//	DateTime.Now.AddDays(10),
			//};

			//bool result = dates.Any(d => d < DateTime.Now);
			//Console.WriteLine(result);

			List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 1 };

		}

		//class Student
		//{
		//	public string Name { get; set; }
		//	public int Age { get; set; }
		//}

		//class User
		//{
		//	public string Name { get; set; }
		//	public List<string> Persmissions { get; set; }
		//}
	}
}