using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.src.Interfaces
{
	internal interface IPaymentMethod
	{
		public void Pay(decimal amount);
	}
}
