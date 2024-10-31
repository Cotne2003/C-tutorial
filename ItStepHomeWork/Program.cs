internal class Program
{
	static void Main(string[] args)
	{
		Birthday birthday = new Birthday();
		BirthdayMember person1 = new BirthdayMember("Tsotne");
		BirthdayMember person2 = new BirthdayMember("Giorgi");
		BirthdayMember person3 = new BirthdayMember("Andria");
		person1.Join(birthday);
		person2.Join(birthday);
		person3.Join(birthday);
		birthday.SendInvite();
	}
	class MyEventArgs : EventArgs
	{
		public string InviteMessage = "the cake is being cut!";
	}
	class Birthday
	{
		public EventHandler<MyEventArgs> CakeCut;

		protected virtual void OnCakeCut(MyEventArgs e)
		{
			CakeCut?.Invoke(this, e);
		}
		public void SendInvite()
		{
			MyEventArgs e = new MyEventArgs();
			OnCakeCut(e);
		}
	}
	class BirthdayMember
	{
		public string Name { get; set; }
        public BirthdayMember(string name)
        {
            Name = name;
        }
        private void CakeCutHandler(object sender, MyEventArgs e)
		{
			Console.WriteLine($"Hi {Name}, Come to the second floor, {e.InviteMessage}");
		}
		public void Join(Birthday birthday)
		{
			birthday.CakeCut += CakeCutHandler;
		}
	}
}