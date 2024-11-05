namespace Linq
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Person> people = new List<Person>()
			{
				new Person(1, "Tsotne", 21, "IT"),
				new Person(2, "Giorgi", 25, "Scientist"),
				new Person(3, "Andria", 18, "Artist"),
				new Person(4, "Mariami", 28, "Lawyer"),
				new Person(5, "Salome", 33, "Journalist"),
				new Person(6, "Natia", 23, "IT")
			};

			bool hasIT = people.Any(p => p.Department == "IT");
			bool hasDoctor = people.Any(p => p.Department == "Doctor");
			Console.WriteLine(hasIT);
			Console.WriteLine(hasDoctor);

			bool allAdult = people.All(p => p.Age >= 18);
			Console.WriteLine(allAdult);

			var peopleByProfession = people.GroupBy(p => p.Department).ToList();

			Console.WriteLine("\nPeople by Department\n");
			foreach(var group in peopleByProfession)
			{
				Console.WriteLine("Department: " + group.Key);
				foreach(var person in group)
				{
					Console.WriteLine("Name: " + person.Name);
				}
			}
		}
		class Person
		{
			private int Id { get; set; }
			public string Name { get; set; }
			public int Age { get; set; }
			public string Department { get; set; }
			public Person(int id, string name, int age, string department)
			{
				Id = id;
				Name = name;
				Age = age;
				Department = department;
			}
		}
	}
}