using ConsoleApp1.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.src.Classes
{
	internal class CreditCardPayment : IPaymentMethod
	{
		public void Pay(decimal amount)
		{
			Console.WriteLine($"Paying [{amount}] using credit card");
		}
	}
}
