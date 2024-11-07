namespace Linq
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Customer> customers = new List<Customer>()
			{
				new Customer("Tsotne", 1),
				new Customer("Giorgi", 2),
				new Customer("Mariami", 3),
				new Customer("Andria", 2)
			};

			List<Item> items = new List<Item>()
			{
				new Item("Telephone"),
				new Item("TV"),
				new Item("Notebook"),
			};

			var orders = customers.Join(items, c => c.OrderId, i => i.Id, (c, i) => new { c.Id, c.OrderId, c.Name, i.Title });

			foreach (var order in orders)
			{

				Console.WriteLine("Customer Id: " + order.Id);
				Console.WriteLine("Order Id: " + order.OrderId);
				Console.WriteLine(order.Name);
				Console.WriteLine(order.Title);
				Console.WriteLine();
			}
			
		}
		class Customer
		{
			public int Id { get; private set; }
			static private int IdHelper { get; set; }
			public string Name { get; set; }
			public int OrderId { get; set; }
            public Customer(string name, int orderId)
            {
				IdHelper++;
				Id = IdHelper;
				Name = name;
				OrderId = orderId;
            }
        }
		class Item
		{
			public int Id { get; private set; }
			static private int IdHelper { get; set; }
			public string Title { get; set; }
			public Item(string title)
			{
				IdHelper++;
				Id = IdHelper;
				Title = title;
			}
		}
	}
}