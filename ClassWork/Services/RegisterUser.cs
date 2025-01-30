using ClassWork.Interfaces;

namespace ClassWork.Services
{
	public class RegisterUser : IRegister
	{
		private readonly IRegister _register;

		public RegisterUser(IRegister register)
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
