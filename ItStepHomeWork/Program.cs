internal class Program
{
	static void Main(string[] args)
	{
		DatabaseSimulation ds = new DatabaseSimulation();
		using (ds)
		{
			ds.OpenResource();
			ds.UseResource();
		}
	}

	class DatabaseSimulation : IDisposable
	{
		private bool isDatabaseOpen = false;

		public void OpenResource()
		{
			isDatabaseOpen = true;
			Console.WriteLine("Database is opened...");
		}
		public void UseResource()
		{
			if (isDatabaseOpen)
			{
				Console.WriteLine("Information is coming...");
			}
			else
			{
				throw new InvalidOperationException("Can not access information");
			}
		}
		private void CloseResource()
		{
			isDatabaseOpen = false;
			Console.Write("Databes is closed...");
		}

		public void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (isDatabaseOpen)
				{
					CloseResource();
					Console.Write(" via Dispose");
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~DatabaseSimulation()
		{
			Dispose(false);
		}
	}
}