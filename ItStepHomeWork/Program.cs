namespace Linq
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Person person1 = new Person(1, "Tsotne", 21, "Programmer");
			Person person2 = new Person(2, "Giorgi", 25, "Philologist");
			Person person3 = new Person(3, "Nikoloz", 19, "Scientist");

			List<Person> persons = new List<Person>();
			persons.Add(person1);
			persons.Add(person2);
			persons.Add(person3);

			List<Person> byAge = persons.OrderBy(a => a.Age).ToList();

			foreach (Person person in byAge)
			{
				Console.WriteLine(person.Name + ": " + person.Age);
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