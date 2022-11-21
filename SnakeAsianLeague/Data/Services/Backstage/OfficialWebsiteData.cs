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

        public async Task RegisterFail(uint UserID, string phone)
        {
            restRequest = new RestRequest($"OfficialWebsiteLog/RegisterFail?UserID={UserID}&_PhoneNumber={phone}", Method.GET);
            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(restRequest);
        }

        public async Task Register(uint UserID ,string phone)
        {
            restRequest = new RestRequest($"OfficialWebsiteLog/Register?UserID={UserID}&_PhoneNumber={phone}", Method.GET);
            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(restRequest); 
        }

        public async Task DownloadHits(uint UserID)
        {
            restRequest = new RestRequest($"OfficialWebsiteLog/DownloadHits?UserID={UserID}");
            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(restRequest);
            //以下是測試
            //string returnText = "沒接到";
            //if (restResponse.StatusCode == HttpStatusCode.OK)
            //{
            //    returnText = restResponse.Content;
            //}

        }


    }
}
