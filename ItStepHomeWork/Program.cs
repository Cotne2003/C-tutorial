namespace FileStreams
{
	internal class Program
	{
		static void Main(string[] args)
		{
			const string path = "C:\\Users\\Tsotne\\OneDrive\\Desktop\\ClassWork\\data.bin";
			string test = "";

			using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
			using (BinaryWriter bw = new BinaryWriter(fs))
			{
				bw.Write(30);
				bw.Write("hello");
				bw.Write('h');
				bw.Write(true);
				bw.Write(1.5);
				bw.Write(1.5m);
				using (BinaryReader br = new BinaryReader(fs))
				{
					Console.WriteLine(br.ReadInt32());
					Console.WriteLine(br.ReadString());
					Console.WriteLine(br.ReadChar());
				}

			}
		}
	}
}