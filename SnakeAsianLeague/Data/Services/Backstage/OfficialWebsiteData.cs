using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Entity.Config;
using System.Net;

namespace SnakeAsianLeague.Data.Services.Backstage
{
    public class OfficialWebsiteData
    {
        private readonly RestClient ServerClient;
        private ExternalServers externalServersConfig;
        private RestRequest restRequest;

        public OfficialWebsiteData(IOptions<ExternalServers> myConfiguration) {
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.BackstageApiServer);
        }

        public async Task<string> Register(){
            restRequest = new RestRequest("OfficialWebsiteData/Register" , Method.GET);
            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(restRequest);
            string returnText = "沒接到";
            if(restResponse.StatusCode == HttpStatusCode.OK)
            {
                returnText = restResponse.Content;
            }
            return returnText;
        }

        public async Task<string> DownloadHits(uint UserID)
        {
            restRequest = new RestRequest($"OfficialWebsiteData/DownloadHits?UserID={UserID}");
            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(restRequest);
            string returnText = "沒接到";
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                returnText = restResponse.Content;
            }
            return returnText;
        }


    }
}
