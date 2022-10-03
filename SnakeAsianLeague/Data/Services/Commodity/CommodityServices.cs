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
        private readonly RestClient NftWebApiServerClient;

        private List<IAPItem> mIAPItems;

        public CommodityServices(IOptions<ExternalServers> myConfiguration)
        {
            externalServersConfig = myConfiguration.Value;

            BackstageServerClient = new RestClient(externalServersConfig.BackstageApiServer);

            NftWebApiServerClient = new RestClient(externalServersConfig.NftWebApi);
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
            RestRequest RestRequest = new RestRequest(URL);
            IRestResponse restResponse = await BackstageServerClient.ExecuteGetAsync(RestRequest);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {


                mIAPItems = new List<IAPItem>();
                iAPItems = JsonSerializer.Deserialize<List<IAPItem>>(restResponse.Content) ?? new List<IAPItem>();
                mIAPItems = iAPItems;

           


            }
            return iAPItems;
        }



        /// <summary>
        /// 購買遊戲商品品項
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="USDT"></param>
        /// <param name="productID"></param>
        /// <returns></returns>
        public async Task<bool> PurchaseByUSDT(uint UserID , decimal USDT , string productID)
        {
            bool result = false;
            decimal amountOfUSDT = USDT;
            if (mIAPItems.Count > 0)
            {
                amountOfUSDT = mIAPItems.Where(m => m.productID == productID).First().priceUSDT;
            }
            RestRequest RestRequest = new RestRequest($"​CQIPurchase​/PurchaseByUSDT?userID={UserID}&amountOfUSDT={amountOfUSDT}&productID={productID}");

            IRestResponse restResponse = await NftWebApiServerClient.ExecuteGetAsync(RestRequest);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                result = true;
            }
            return result;
        }
    }
}
