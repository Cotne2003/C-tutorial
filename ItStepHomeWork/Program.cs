using System.Diagnostics.Metrics;

internal class Program
{
	static void Main(string[] args)
	{
		using (FileStream fs = new FileStream("C:\\Users\\Tsotne\\OneDrive\\Desktop\\hehe\\tsotne.txt", FileMode.Create))
		{
			fs.Close();
		}
	}
	public class CustomClass : IDisposable
	{
		public bool isResourceOpen = false;
		public void OpenResource()
		{
			Console.WriteLine("Resource is open");
			isResourceOpen = true;
		}
		public void UseResource()
		{
			if (!isResourceOpen)
			{
				throw new InvalidOperationException("Resource is not opened");
			}
		}
		public void CloseResource()
		{
			Console.WriteLine("Resource is close");
			isResourceOpen = false;
		}
		public virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (isResourceOpen)
				{
					CloseResource();
				}
			}
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		~CustomClass()
		{
			Dispose(false);
		}
	}
}