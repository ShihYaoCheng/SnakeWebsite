using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using SnakeAsianLeague.Data.Contracts;
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
        private IAuthManagement _AuthManagement;

        public WarmUpActivitiesService(IOptions<ExternalServers> myConfiguration , IAuthManagement authManagement)
        {
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.UserServer);
                _AuthManagement = authManagement;
        }

        public async Task<List<LeaderboardDTO>> GetLeaderboard()
        {
            restRequest = new RestRequest($"Leaderboard/Activity", Method.GET);
            restRequest.AddParameter("userId", 0);

            restRequest.AddHeader("Authorization", $"Bearer {_AuthManagement.GetAdminAccessTokenInCookie()}");
            List<LeaderboardDTO> LeaderboardList = new List<LeaderboardDTO>();

            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(restRequest);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                LeaderboardList = JsonConvert.DeserializeObject<List<LeaderboardDTO>>(restResponse.Content);
            }

            return LeaderboardList;



        }

    }
}

