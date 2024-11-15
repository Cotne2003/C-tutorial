using System.Linq;
using System.Net.Security;
using System.Text;

namespace FileStreams
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//List<Person> people = new List<Person>()
			//{
			//	new Person { Id = 1, Name = "Tsotne", },
			//	new Person { Id = 2, Name = "Giorgi", },
			//	new Person { Id = 3, Name = "Mariami", },
			//	new Person { Id = 4, Name = "Andria", },
			//	new Person { Id = 5, Name = "Andria" }
			//};

			//people.ForEach(person => Console.WriteLine(person.Id));

			//var byName = from person in people
			//			 where person.Name == "Andria"
			//			 select person;

			//var SelectedNames = from person in people
			//				   select person.Name;


			//byte[] initialData = { 0x01, 0x02, 0x03, 0x04, 0x05 }; // 0-9 A(10)B(11)C(12)D(13)E(14)F(15) 0*16^1 + 1*16^0 = 0 + 1 = 1

			//using (MemoryStream memoryStream = new MemoryStream())
			//{
			//	memoryStream.Write(initialData, 0, initialData.Length);
			//	memoryStream.Seek(0, SeekOrigin.Begin);

			//	byte[] buffer = new byte[memoryStream.Length];

			//	memoryStream.Read(buffer, 0, buffer.Length);
			//	var content = BitConverter.ToString(buffer);
			//	Console.WriteLine($"Data: {content}");

			//	byte[] newData = { 0x06, 0x07, 0x08 };
			//	memoryStream.Write(newData, 0, newData.Length);

			//	memoryStream.Seek(0, SeekOrigin.Begin);
			//	buffer = new byte[memoryStream.Length];
			//	memoryStream.Read(buffer, 0, buffer.Length);
			//	Console.WriteLine("Combined data: " + BitConverter.ToString(buffer));
			//}

			const string path = "C:\\Users\\Tsotne\\OneDrive\\Desktop\\HomeWork\\text.txt";
			using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
			{
				StreamWriter writer = new StreamWriter(fs);
				writer.WriteLine("-Hello FileStream!");
				writer.WriteLine("-Hello C#!");

				writer.Flush();

				fs.Seek(0, SeekOrigin.Begin);

				StreamReader reader = new StreamReader(fs);

				string result = reader.ReadToEnd();
				Console.WriteLine(result);

				writer.Close();
				reader.Close();
			}

			using (MemoryStream ms = new MemoryStream())
			{
				StreamWriter writer = new StreamWriter(ms);
				writer.WriteLine("-Hello MemoryStream!");
				writer.WriteLine("-Hello C#!");

				writer.Flush();

				ms.Seek(0, SeekOrigin.Begin);

				StreamReader reader = new StreamReader(ms);

				string result = reader.ReadToEnd();
				Console.WriteLine(result);

				writer.Close();
				reader.Close();
			}
		}

		//class Person
		//{
		//	public int Id { get;  set; }
		//	public string Name { get; set; }
  //      }
	}
}