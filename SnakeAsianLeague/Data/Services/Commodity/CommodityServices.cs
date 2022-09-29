using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Entity.Commodity;
using SnakeAsianLeague.Data.Entity.Config;
using System.Net;
using System.Text.Json;

namespace SnakeAsianLeague.Data.Services.Commodity
{
    public class CommodityServices
    {

        private ExternalServers externalServersConfig;
        private readonly RestClient BackstageServerClient;

        public CommodityServices(IOptions<ExternalServers> myConfiguration)
        {
            externalServersConfig = myConfiguration.Value;

            BackstageServerClient = new RestClient(externalServersConfig.UserServer);
        }

        /// <summary>
        /// 取得 商城商品IAP品項
        /// </summary>
        /// mintCount 鍛造次數
        /// <returns></returns>
        public async Task<List<IAPItem>> GetIAPItem()
        {
            List<IAPItem> iAPItems = new List<IAPItem>();

            string URL = $"api/Commodity/GetIAPItems";

            var mLoginRestRequest = new RestRequest(URL);

            IRestResponse restResponse = await BackstageServerClient.ExecuteGetAsync(mLoginRestRequest);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                iAPItems = JsonSerializer.Deserialize<List<IAPItem>>(restResponse.Content) ?? new List<IAPItem>();
            }
            return iAPItems;
        }
    }
}
