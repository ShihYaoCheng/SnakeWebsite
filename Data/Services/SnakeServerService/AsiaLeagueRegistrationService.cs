using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Entity.SnakeServer;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Services.SnakeServerService
{
    public class AsiaLeagueRegistrationService
    {
        private readonly RestClient ServerClient;
        private ExternalServers externalServersConfig;
        private RestRequest restRequest;

        public AsiaLeagueRegistrationService(IOptions<ExternalServers> myConfiguration)
        {
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.UserServer);
            restRequest = new RestRequest($"AsiaLeagueRegistration");

        }

        public async Task<List<AsiaLeagueRegistration>> GetAsiaLeagueRegistrationsByUserId(AsiaLeagueSeasons season, uint userId)
        {
            restRequest.Parameters.Clear();
            restRequest.AddParameter("SeasonNum", (int)season);
            restRequest.AddParameter("UserId", userId);

            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(restRequest);

            List<AsiaLeagueRegistration> registrations = new List<AsiaLeagueRegistration>();
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                registrations = JsonConvert.DeserializeObject<List<AsiaLeagueRegistration>>(restResponse.Content);
            }

            return registrations;
        }

    }
}
