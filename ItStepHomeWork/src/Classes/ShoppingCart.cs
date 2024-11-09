using ConsoleApp1.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.src.Classes
{
	internal class ShoppingCart
	{
		public void Checkout(IPaymentMethod paymentMethod, decimal amount)
		{
			paymentMethod.Pay(amount);
		}
	}
}
