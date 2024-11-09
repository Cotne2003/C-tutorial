using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.src.OopPrinciples.Coupling
{
	internal class EmailSender : INotificationSender
	{
		public void SendNotification(string message)
		{
			Console.Write(message);
		}
	}
}
