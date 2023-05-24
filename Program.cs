using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QuickType;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsumindoIMDB
{
    class Program
    {
        static async Task Main(string[] args)
        {



            HttpClient client = new HttpClient { BaseAddress = new Uri($"https://imdb-api.com/en/API/Top250Movies/{LoadAPI()}/") };
            var response = await client.GetAsync("");
            var content = await response.Content.ReadAsStringAsync();
            //string pretty = PrettyJson(content);

            var filme = JsonConvert.DeserializeObject<TopMovies>(content);
            foreach (var i in filme.Items)
            {
                string numeroFormatado = i.ImDbRatingCount.ToString("N0");
                Console.WriteLine(i.Rank + ": "+ i.Title + "-> "+ i.ImDbRating  + "("+numeroFormatado+")");
            }



        }
        public static string PrettyJson(string unPrettyJson)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            var jsonElement = System.Text.Json.JsonSerializer.Deserialize<JsonElement>(unPrettyJson);

            return System.Text.Json.JsonSerializer.Serialize(jsonElement, options);
        }

        public static string LoadAPI()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();
            string apikey = config["apikey"];
            return apikey;
        }

    }
}

