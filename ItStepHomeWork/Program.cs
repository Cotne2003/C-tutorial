using System.Text.Json;

namespace ATM
{
	internal class ATM
	{
		static void Main(string[] Args)
		{
			Console.WriteLine("Hello to ATM");
			const string atmJsonPath = "C:\\Users\\Tsotne\\OneDrive\\Desktop\\ItStepAcademyProjects\\ATMApp\\DB\\atm.json";
			string atmJsonContent = File.ReadAllText(atmJsonPath);
			User userCard = new User();
			try
			{
				userCard = JsonSerializer.Deserialize<User>(atmJsonContent);
				Console.WriteLine($"Welcome back {userCard.Name}! Press any key to start operations");
				Console.ReadLine();
			}
			catch (System.Text.Json.JsonException e)
			{
				Console.WriteLine("Welcome to your first ATM account! Press any key to create account");
				Console.ReadLine();
			}
			bool leave = false;
			while (!leave)
			{
				if (userCard.Name == null)
				{
					Console.Write("Please enter your name: ");
					string? name = Console.ReadLine();

					while (name.Length == 0)
					{
						Console.Write("Name should not be empty. Please enter again: ");
						name = Console.ReadLine();
					}
					userCard.Name = name;
				}

				Console.Clear();

				Console.WriteLine("Choose your operation\n");

				Console.WriteLine("1. Show name");
				Console.WriteLine("2. Show Pincode");
				Console.WriteLine("3. Show Balance");
				Console.WriteLine("4. Deposit");
				Console.WriteLine("5. Withdraw");
				Console.WriteLine("6. Change Pincode (Recommended if you haven't changed it yet)");
				Console.WriteLine("7. Leave ATM");

				if (int.TryParse(Console.ReadLine(), out int value))
				{
					decimal amount;
					switch (value)
					{
						case 1:
							Console.WriteLine($"Your account name is {userCard.Name}");
							Console.WriteLine("Enter any key to return to menu");
							Console.ReadLine();
							break;
						case 2:
							Console.WriteLine($"Your account pin code is {userCard.Pin}");
							Console.WriteLine("Enter any key to return to menu");
							Console.ReadLine();
							break;
						case 3:
							Console.WriteLine($"Your balance is {userCard.Balance}");
							Console.WriteLine("Enter any key to return to menu");
							Console.ReadLine();
							break;
						case 4:
							Console.Write("Enter amount to deposit: ");
							amount = decimal.Parse(Console.ReadLine());
							userCard.Deposit(amount);
							Console.WriteLine("Enter any key to return to menu");
							Console.ReadLine();
							break;
						case 5:
							Console.Write("Enter amount to deposit: ");
							amount = decimal.Parse(Console.ReadLine());
							userCard.Withdraw(amount);
							Console.WriteLine("Enter any key to return to menu");
							Console.ReadLine();
							break;
						case 6:
							Console.Write("Enter your new pin code: ");
							string? newPin = Console.ReadLine();
							userCard.ChangePin(newPin);
							Console.WriteLine("Enter any key to return to menu");
							Console.ReadLine();
							break;
						case 7:
							leave = true;
							break;
						default:
							Console.WriteLine("Invalid operation");
							break;
					}
				}
			}
			File.WriteAllText(atmJsonPath, JsonSerializer.Serialize(userCard));
		}

		public class User
		{
			public string Name { get; set; }
			public string Pin { get; set; }
			public decimal Balance { get; set; }
			public User()
			{
				Balance = 0;
				Pin = "0000";
			}

			public void Deposit(decimal amount)
			{
				if (amount > 0)
				{
					Balance += amount;
					Console.WriteLine("The amount has been deposited succesfully");
				}
				else
				{
					Console.WriteLine("Invalid operation");
				}
			}

			public void Withdraw(decimal amount)
			{
				if (amount > 0 && amount <= Balance)
				{
					Balance -= amount;
					Console.WriteLine("The amount has been withdraw succesfully");
				}
				else if (amount > Balance)
				{
					Console.WriteLine("Not enought money to withdraw");
				}
				else
				{
					Console.WriteLine("Invalid operation");
				}
			}

			public void ChangePin(string newPin)
			{
				if (int.TryParse(newPin, out int pinInNum))
				{
					if (newPin.Length == 4)
					{
						Pin = newPin;
						Console.WriteLine($"new pin: {Pin} - changed succesfully");
					}
					else
					{
						Console.WriteLine("Pin code must be 4 digits");
					}
				}
				else
				{
					Console.WriteLine("Invalid pin. Pin code must be number");
				}
			}
		}
	}
}