using System.Text.Json;

namespace ATM
{
	internal class ATM
	{
		static void Main(string[] Args)
		{
			Console.WriteLine("Hello to ATM");
			User userCard = new User();
			Console.WriteLine(userCard.Name == null);
			string leave = "";
			while (leave != "no")
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
				Console.WriteLine("7. Leave ATM");

				if (int.TryParse(Console.ReadLine(), out int value))
				{
					switch (value)
					{
						case 1:
							Console.WriteLine($"Your account name is ${userCard.Name}");
							break;
						case 2:
							Console.WriteLine($"Your account pin code is ${userCard.Pin}");
							break;
						case 3:
							Console.WriteLine($"Your balance is ${userCard.Balance}");
							break;
						case 4:
							while (decimal.TryParse(Console.ReadLine(), out decimal amount))
							{
								userCard.Deposit(amount);
							}
							break;
						case 5:
							while (decimal.TryParse(Console.ReadLine(), out decimal amount))
							{
								userCard.Withdraw(amount);
							}
							break;
						default:
							Console.WriteLine("Invalid operation");
							break;
					}
				}
			}
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
				if (amount > Balance)
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