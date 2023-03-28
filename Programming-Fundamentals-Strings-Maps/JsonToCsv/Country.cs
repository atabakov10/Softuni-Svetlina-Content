using Newtonsoft.Json;

namespace JsonToCsvConverter
{
	public class Country
	{
		[JsonProperty("name")]
		public CountryName Names { get; set; }

		public string Region { get; set; }

		public string Subregion { get; set; }

		[JsonProperty("capital")]
		public string[] Capitals { get; set; }
	}
}
