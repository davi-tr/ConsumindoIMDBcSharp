using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QuickType;
using System.Text.Json;
using System.Threading.Tasks;
using SeriesIMDB;

namespace ConsumindoIMDB
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int x;
            do
            {
                PrintMenu();
                x = int.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        await PrintTop250Movie();
                        break;
                    case 2:
                        Console.WriteLine("Informe o nome do filme:");
                        
                        await PrintSearchMovie(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Informe o nome da série");

                        await PrintSearchSeries(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Valor invalido");
                        break;
                }
            } while ( x < 10);

        }

        public static void PrintMenu()
        {
            Console.WriteLine("\n1 - Para exibir uma lista com top 250 filmes");
            Console.WriteLine("\n2 - Pesquisar um filme");
            Console.WriteLine("\n3 - Pesquisar serie");
            //Console.WriteLine("\n1 - Para exibir uma lista com top 250 filmes");

        }
        public static async Task PrintTop250Movie()
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri($"https://imdb-api.com/pt/API/Top250Movies/{LoadAPI()}/") };
            var response = await client.GetAsync("");
            var content = await response.Content.ReadAsStringAsync();
            //string pretty = PrettyJson(content);

            var filme = JsonConvert.DeserializeObject<TopMovies>(content);
            foreach (var i in filme.Items)
            {
                string numeroFormatado = i.ImDbRatingCount.ToString("N0");
                Console.WriteLine(i.Rank + ": " + i.Title + "-> " + i.ImDbRating + "(" + numeroFormatado + ")");
            }

        }
        public static async Task PrintSearchMovie(string NomeFilme)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri($"https://imdb-api.com/pt/API/Search/{LoadAPI()}/") };
            var response = await client.GetAsync($"{NomeFilme}");
            var content = await response.Content.ReadAsStringAsync();
            //string pretty = PrettyJson(content);

            var filme = JsonConvert.DeserializeObject<SearchMovieC>(content);
            int j = 0;
            foreach (var i in filme.Results)
            {
                j++;
                if (j == 1)
                {
                    Console.WriteLine("ID: " + i.Id);
                    Console.WriteLine("Titulo: "+ i.Title);
                    Console.WriteLine("Descrição: " + i.Description);

                    Console.WriteLine("Gostaria de fazer uma busca detalhada sobre o filme?");
                    Console.WriteLine("(S) - Sim ou (N) - Não");
                    string resp = Console.ReadLine();
                    if (resp == "S")
                    {
                        await PrintSearchMovieID(i.Id);
                        return;
                    }else if (resp == "s") 
                    {
                        await PrintSearchMovieID(i.Id);
                        return;
                    }

                }

            }
            
        }
        public static async Task PrintSearchSeries(string NomeSerie)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri($"https://imdb-api.com/en/API/SearchSeries/{LoadAPI()}/") };
            var response = await client.GetAsync($"{NomeSerie}");
            var content = await response.Content.ReadAsStringAsync();
            //string pretty = PrettyJson(content);

            var serie = JsonConvert.DeserializeObject<ImbdSeries>(content);
            int j = 0;
            foreach (var i in serie.Results)
            {
                j++;
                if (j == 1)
                {
                    Console.WriteLine("ID: " + i.Id);
                    Console.WriteLine("Titulo: " + i.Title);
                    Console.WriteLine("Descrição: " + i.Description);

                    Console.WriteLine("Gostaria de fazer uma busca detalhada sobre a Serie?");
                    Console.WriteLine("(S) - Sim ou (N) - Não");
                    string resp = Console.ReadLine();
                    if (resp == "S")
                    {
                        await PrintSearchMovieID(i.Id);
                        return;
                    }
                    else if (resp == "s")
                    {
                        await PrintSearchMovieID(i.Id);
                        return;
                    }

                }

            }

        }

        public static async Task PrintSearchMovieID(string id)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri($"https://imdb-api.com/pt/API/Title/{LoadAPI()}/") };
            var response = await client.GetAsync($"{id}");
            var content = await response.Content.ReadAsStringAsync();
            //string pretty = PrettyJson(content);

            var filme = JsonConvert.DeserializeObject<Imdb>(content);
            Console.WriteLine("Nome do filme: " + filme.FullTitle);
            Console.WriteLine("\nPlot em portugues:" + filme.PlotLocal);
            Console.WriteLine("\n\nEstrelado por: ");
            foreach (var i in filme.StarList)
            {
                Console.WriteLine(i.Name);
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

