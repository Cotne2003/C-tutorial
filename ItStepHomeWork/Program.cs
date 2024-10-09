internal class Program
{
	static void Main(string[] args)
	{
		Gauge g = new Gauge();

		while (!g.Full())
		{
			Console.WriteLine("Not full! Value: " + g.Value);
			g.Increase();
		}

		Console.WriteLine("Full! Value: " + g.Value);
		g.Decrease();
		Console.WriteLine("Not full! Value: " + g.Value);
	}
	class Gauge
	{
        public int Value { get; set; }
        public Gauge()
        {
			Value = 0;
        }
		public void Increase()
		{
			Value++;
			if (Value >= 5)
			{
				Value = 5;
			}
		}
		public void Decrease()
		{
			Value--;
			if (Value <= 0)
			{
				Value = 0;
			}
		}
		public bool Full()
		{
			if (Value == 5)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
    }
}