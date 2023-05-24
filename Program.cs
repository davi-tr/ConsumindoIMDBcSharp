using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QuickType;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsumindoIMDB
{
    class Program
    {
        static async Task Main(string[] args)
        {



            HttpClient client = new HttpClient { BaseAddress = new Uri($"https://imdb-api.com/pt/API/Title/{LoadAPI()}/") };
            var response = await client.GetAsync("tt4975722");
            var content = await response.Content.ReadAsStringAsync();
            string pretty = PrettyJson(content);
            Console.WriteLine(pretty);

            var filme = JsonConvert.DeserializeObject<Imdb>(content);
            //Console.WriteLine(filme.Title);


            
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

