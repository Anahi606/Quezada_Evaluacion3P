using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Quezada_Evaluacion3P.Models;

namespace Quezada_Evaluacion3P.Services
{
    public class AQApiService
    {
        private const string ApiUrl = "https://api.rawg.io/api/games?key=c1843dfe3a34440dbf3adf0357a610ed";

        public async Task<List<AQGame>> GetGames()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(ApiUrl);
                var games = JsonConvert.DeserializeObject<List<AQGame>>(response);
                return games;
            }
        }
    }
}
