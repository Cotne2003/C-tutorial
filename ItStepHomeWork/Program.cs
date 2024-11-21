using System.Text.Json;

namespace FileStreams
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var url = "https://open.er-api.com/v6/latest/USD";

			using (HttpClient client = new HttpClient())
			{
				var response = client.GetAsync(url).Result;
				string responsBody = response.Content.ReadAsStringAsync().Result;

				ExchangeRatesResponse deserializedRates = JsonSerializer.Deserialize<ExchangeRatesResponse>(responsBody);
			}
		}

		class ExchangeRatesResponse
		{
			public Rates rates { get; set; }
		}

		class Rates
		{
			public double USD { get; set; }
			public double EUR { get; set; }
			public double GEL { get; set; }
		}

	}
}