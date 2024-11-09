using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.src.OopPrinciples.Coupling
{
	internal class Order
	{
		private INotificationSender OrderSender;
        public Order(INotificationSender orderSender)
        {
            OrderSender = orderSender;
        }

        public void SendNotification()
		{
			OrderSender.SendNotification("hehehhe");
		}
	}
}
