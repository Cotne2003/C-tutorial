using System.Text.RegularExpressions;

namespace Linq
{
	internal class Program
	{
		delegate int MyDelegate(int num1, int num2);
		static void Main(string[] args)
		{
			#region
			//Person person1 = new Person(1, "Tsotne", 21, "Programmer");
			//Person person2 = new Person(2, "Giorgi", 25, "Philologist");
			//Person person3 = new Person(3, "Nikoloz", 19, "Scientist");

			//List<Person> persons = new List<Person>();
			//persons.Add(person1);
			//persons.Add(person2);
			//persons.Add(person3);

			//List<Person> byAge = persons.OrderBy(a => a.Age).ToList();

			//foreach (Person person in byAge)
			//{
			//	Console.WriteLine(person.Name + ": " + person.Age);
			//}
			#endregion

			MyDelegate lambda = (int num1, int num2) => num1 + num2;
			lambda += delegate (int num1, int num2)
			{
				return num1 + num2;
			};
			Console.WriteLine(lambda(1,2));

			string url = "https://www.example.com/page";
			string url2 = "http://www.example.com/page";
			string urlPattern = @"^https:\/\/www\.[a-zA-Z0-9-]+\.[a-zA-Z]{2,}(\/[a-zA-Z0-9-_.~%]*)*\/?$";
			Console.WriteLine(Regex.IsMatch(url, urlPattern));
			Console.WriteLine(Regex.IsMatch(url2, urlPattern));
		}
		#region
		//class Person
		//{
		//	private int Id { get; set; }
		//	public string Name { get; set; }
		//	public int Age { get; set; }
		//	public string Department { get; set; }
		//	public Person(int id, string name, int age, string department)
		//	{
		//		Id = id;
		//		Name = name;
		//		Age = age;
		//		Department = department;
		//	}
		//}
		#endregion
	}
}