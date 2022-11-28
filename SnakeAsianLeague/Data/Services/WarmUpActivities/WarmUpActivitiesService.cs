using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Entity.SnakeServer;
using System.Net;

namespace SnakeAsianLeague.Data.Services.WarmUpActivities
{
    public class WarmUpActivitiesService
    {

        private readonly RestClient ServerClient;
        private ExternalServers externalServersConfig;
        private RestRequest restRequest;

        public WarmUpActivitiesService(IOptions<ExternalServers> myConfiguration)
        {
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.UserServer);
        }

        public async Task<OwnedVirtualCurrrencyLeaderboardDTO> GetLeaderboard()
        {
            restRequest = new RestRequest($"Leaderboard/ForWeb", Method.GET);
            restRequest.AddParameter("count", 50);

            restRequest.AddHeader("Authorization", Authenticate());
            OwnedVirtualCurrrencyLeaderboardDTO LeaderboardList = new OwnedVirtualCurrrencyLeaderboardDTO();

            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(restRequest);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                LeaderboardList = JsonConvert.DeserializeObject<OwnedVirtualCurrrencyLeaderboardDTO>(restResponse.Content);
            }

            return LeaderboardList;



        }

        private string Authenticate()
        {
            string auth = "Unity:Yx2fy5tFfDHAfU7Az";
            auth = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
            auth = "Basic " + auth;
            return auth;
        }
    }
}

