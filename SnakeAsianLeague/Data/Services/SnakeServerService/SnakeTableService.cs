using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Entity.SnakeServer;
using System.Net;

namespace SnakeAsianLeague.Data.Services.SnakeServerService
{
    public class SnakeTableService
    {
        private readonly RestClient ServerClient;
        private ExternalServers externalServersConfig;
        private readonly RestRequest ApiGetSheet;


        public SnakeTableService(IOptions<ExternalServers> myConfiguration)
        {
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.TableServer);
            ApiGetSheet = new RestRequest("/Table/Unity/Check", Method.GET);
        }

        public async Task<ServerResponce> GetSheetFromTableServerAsync(string sheetName)
        {
            var request = new RestRequest(ApiGetSheet.Resource, ApiGetSheet.Method);
            request.AddParameter("from", 0);
            request.AddParameter("fileName", sheetName);

            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(request);

            ServerResponce serverResponce = new ServerResponce();
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                serverResponce.Success = true;
                serverResponce.Content = restResponse.Content;
            }
            else
            {
                serverResponce.Success = false;
                serverResponce.Content = restResponse.Content;
            }


            return serverResponce;
        }

    }
}
