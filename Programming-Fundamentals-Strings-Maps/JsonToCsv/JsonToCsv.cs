using System.Net;
using System.Globalization;
using System.Text.RegularExpressions;
using CsvHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JsonToCsvConverter;

public static class JsonToCsv
{
	private static IEnumerable<Country> countries = new List<Country>();

	public static void CheckUserInput(string userInput)
	{
		string userInputValidator = @"^(?<path>\w+)/\w+/$";

		Match match = Regex.Match(userInput, userInputValidator);

		if (!match.Success || !IsApiPathValid(match))
		{
			throw new Exception("Invalid input request");
		}
	}

	public static bool IsApiPathValid(Match match)
	{
		string path = match.Groups["path"].Value;

		string[] allApiPaths = Enum.GetNames(typeof(ApiPaths));
		bool isPathValid = allApiPaths.Any(x => x.Equals(path, StringComparison.OrdinalIgnoreCase));

		if (isPathValid)
		{
			return true;
		}

		return false;
	}

	public static string GetJson(string userInput)
	{
		Task<HttpResponseMessage> response = GetResponse(userInput);
		HttpStatusCode statusCode = response.Result.StatusCode;

		if (statusCode == HttpStatusCode.NotFound)
		{
			throw new Exception("No results found");
		}
		else if (statusCode != HttpStatusCode.OK)
		{
			throw new Exception("An error appeared! Try again.");
		}

		string responseAsString = ReadResponseAsStringAsync(response);

		try
		{
			countries = DeserializeJson(responseAsString);
		}
		catch (Exception)
		{
			throw new Exception("Invalid JSON. Try another request.");
		}

		string countriesAsJson = SerializeJson();

		return countriesAsJson;
	}

	public static Task<HttpResponseMessage> GetResponse(string userInput)
	{
		string url = $"https://restcountries.com/v3.1/{userInput}";

		HttpClient client = new HttpClient();
		Task<HttpResponseMessage> response = client.GetAsync(url);

		return response;
	}

	public static string ReadResponseAsStringAsync(Task<HttpResponseMessage> response)
	=> response.Result.Content.ReadAsStringAsync().Result;

	public static IEnumerable<Country> DeserializeJson(string responseAsString)
	 => JsonConvert.DeserializeObject<IEnumerable<Country>>(responseAsString)
		.ToArray();

	public static string SerializeJson()
	{
		JsonSerializerSettings settings = new JsonSerializerSettings
		{
			ContractResolver = new CamelCasePropertyNamesContractResolver(),
		};

		string serializedJson = JsonConvert
			.SerializeObject(countries, Formatting.Indented, settings);

		return serializedJson;
	}

	public static string GetCsv()
	{
		StringWriter writer = new StringWriter();
		CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

		csv.WriteField("name/common");
		csv.WriteField("name/official");
		csv.WriteField("region");
		csv.WriteField("subregion");
		csv.WriteField("capital");
		csv.NextRecord();

		foreach (Country country in countries)
		{
			var countryCommonName = country.Names.Common == null
				? string.Empty
				: country.Names.Common;

			csv.WriteField(countryCommonName);

			var countryOfficialName = country.Names.Official == null
				? string.Empty
				: country.Names.Official;

			csv.WriteField(countryOfficialName);

			var countryRegion = country.Region == null
				? string.Empty
				: country.Region;

			csv.WriteField(countryRegion);

			var countrySubregion = country.Subregion == null
				? string.Empty
				: country.Subregion;

			csv.WriteField(countrySubregion);

			var countryCapitals = country.Capitals == null
				? string.Empty
				: string.Join(",", country.Capitals);

			csv.WriteField(countryCapitals);
			csv.NextRecord();
		}

		return writer.ToString();
	}
}

