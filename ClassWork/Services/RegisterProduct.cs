using ClassWork.Interfaces;

namespace ClassWork.Services
{
	public class RegisterProduct : IRegister
	{
		private readonly IRegister _register;

		public RegisterProduct(IRegister register)
		{
			_register = register;
		}

		public void RegisterUserOrProduct(string name, int id)
		{
			_register.RegisterUserOrProduct(name, id);
			Console.WriteLine($"New Product - {name} by id - {id} is added.");
		}
	}
}
