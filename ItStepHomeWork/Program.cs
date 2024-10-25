using System;
using System.Collections.Generic;

internal class Program
{
	static void Main(string[] args)
	{
		CreditCard card = new CreditCard("Tsotne", "Basiashvili", "1089");
		CreditCard card1 = new CreditCard("Adomel", "Arabuli", "1125");
		// add balance
		card.Deposit(1000);
		Console.WriteLine(card.Balance);
		// trasfer money
		card.Transfer(500, card1);
		// show information
		card.DisplayInformation();
		card1.DisplayInformation();
		// change pin code
		card.ChangePinCode();
	}

	class CreditCard
	{
		private Random random = new Random();
		private string CardNumber { get => $"{random.Next(1000, 10000)}"; }
        private string FirstName { get; set; }
		private string LastName { get; set; }
		private string FullName { get => $"{FirstName} {LastName}"; }
		private string PinCode { get; set; }
		public decimal Balance { get; set; }
		private DateTime CardValidityPeriod { get; set; }
		private decimal creditLimit = 5000;

		public CreditCard(string firstName, string lastName, string pinCode)
        {
			CardValidityPeriod = DateTime.Now.AddYears(4);
			FirstName = firstName;
			LastName = lastName;
			PinCode = pinCode;
        }
		public void Deposit(decimal amount)
		{
			if (amount > 0 && Balance + amount <= creditLimit)
			{
				Balance += amount;
			}
		}
		public void Withdraw(decimal amount)
		{
			if (amount > 0 && amount <= Balance)
			{
				Balance -= amount;
			}
		}
		public void Transfer(decimal amount, CreditCard card)
		{
			if (amount > 0 && amount <= Balance && card.Balance + amount <= card.creditLimit)
			{
				Balance -= amount;
				card.Balance += amount;
			}
		}
		public void DisplayInformation()
		{
			Console.WriteLine("Enter Pin Code:");
			string pinInput = Console.ReadLine();
			if (pinInput == PinCode)
			{
				Console.WriteLine($"Fullname: {FullName}\nBalance: {Balance}$\nCard Number: {CardNumber}\nCard Validity Period: {CardValidityPeriod}");
			}
			else
			{
				Console.WriteLine("Incorrect Pin Code");
			}
		}
		public void ChangePinCode()
		{
			Console.WriteLine("Enter Current Pin:");
			string currentPin = Console.ReadLine();
			if (currentPin == PinCode)
			{
				Console.WriteLine("Enter New Pin");
				string newPin = Console.ReadLine();
				if (newPin.Length != 0)
				{
					PinCode = newPin;
				}
				else
				{
					Console.WriteLine("Invalid Pin Code");
				}
			}
			else
			{
				Console.WriteLine("Incorrect Pin Code");
			}
		}
	}
}
