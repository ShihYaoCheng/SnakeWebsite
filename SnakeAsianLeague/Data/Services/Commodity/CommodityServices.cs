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
            string URL = $"Identity/GetIIAPItems";
            RestRequest RestRequest = new RestRequest(URL);
            Console.WriteLine("tttest");
            IRestResponse restResponse = await BackstageServerClient.ExecuteGetAsync(RestRequest);

            Console.WriteLine(restResponse.StatusCode);
            Console.WriteLine(restResponse.Content);

            if (restResponse.StatusCode == HttpStatusCode.OK)
            {


                mIAPItems = new List<IAPItem>();
                iAPItems = JsonSerializer.Deserialize<List<IAPItem>>(restResponse.Content) ?? new List<IAPItem>();

                //IAPItem item = new IAPItem();

                //item.platform = "blockchain";
                //item.productID = "com.cqigames.snakeknight.nftcurrency1_1";
                //item.productUrl = "https://dev.origingaia.com/backstage/UploadImages/512x512/com.cqigames.snakeknight.nftcurrency1_1.png";
                //item.limitType = 0;
                //item.saleType = 0;
                //item.itemTag = 0;
                //item.itemType = 22;
                //item.itemID = 1;
                //item.addValue = 40;
                //item.addPlus = 0;
                //item.status = 1;
                //item.limitCount = 0;
                //item.price = 80;
                //item.priceUSD = 2.51;
                //item.priceUSDT = 2.52;
                //iAPItems.Add(item);
                //item = new IAPItem();
                //item.platform = "blockchain";
                //item.productID = "com.cqigames.snakeknight.nftcurrency1_2";
                //item.productUrl = "https://dev.origingaia.com/backstage/UploadImages/512x512/com.cqigames.snakeknight.nftcurrency1_2.png";
                //item.limitType = 0;
                //item.saleType = 0;
                //item.itemTag = 0;
                //item.itemType = 22;
                //item.itemID = 2;
                //item.addValue = 76;
                //item.addPlus = 4;
                //item.status = 1;
                //item.limitCount = 0;
                //item.price = 152;
                //item.priceUSD = 4.76;
                //item.priceUSDT = 4.77;
                //iAPItems.Add(item);
                //item = new IAPItem();
                //item.platform = "blockchain";
                //item.productID = "com.cqigames.snakeknight.nftcurrency1_3";
                //item.productUrl = "https://dev.origingaia.com/backstage/UploadImages/512x512/com.cqigames.snakeknight.nftcurrency1_3.png";
                //item.limitType = 0;
                //item.saleType = 0;
                //item.itemTag = 0;
                //item.itemType = 22;
                //item.itemID = 3;
                //item.addValue = 156;
                //item.addPlus = 9;
                //item.status = 1;
                //item.limitCount = 0;
                //item.price = 312;
                //item.priceUSD = 9.8;
                //item.priceUSDT = 9.81;
                //iAPItems.Add(item);
                //item = new IAPItem();
                //item.platform = "blockchain";
                //item.productID = "com.cqigames.snakeknight.nftcurrency1_4";
                //item.productUrl = "https://dev.origingaia.com/backstage/UploadImages/512x512/com.cqigames.snakeknight.nftcurrency1_4.png";
                //item.limitType = 0;
                //item.saleType = 0;
                //item.itemTag = 0;
                //item.itemType = 22;
                //item.itemID = 4;
                //item.addValue = 316;
                //item.addPlus = 21;
                //item.status = 1;
                //item.limitCount = 0;
                //item.price = 632;
                //item.priceUSD = 19.84;
                //item.priceUSDT = 19.85;
                //iAPItems.Add(item);
                //item = new IAPItem();
                //item.platform = "blockchain";
                //item.productID = "com.cqigames.snakeknight.nftcurrency1_5";
                //item.productUrl = "https://dev.origingaia.com/backstage/UploadImages/512x512/com.cqigames.snakeknight.nftcurrency1_5.png";
                //item.limitType = 0;
                //item.saleType = 0;
                //item.itemTag = 0;
                //item.itemType = 22;
                //item.itemID = 5;
                //item.addValue = 636;
                //item.addPlus = 48;
                //item.status = 1;
                //item.limitCount = 0;
                //item.price = 1272;
                //item.priceUSD = 39.95;
                //item.priceUSDT = 39.96;
                //iAPItems.Add(item);
                //item = new IAPItem();
                //item.platform = "blockchain";
                //item.productID = "com.cqigames.snakeknight.nftcurrency1_6";
                //item.productUrl = "https://dev.origingaia.com/backstage/UploadImages/512x512/com.cqigames.snakeknight.nftcurrency1_6.png";
                //item.limitType = 0;
                //item.saleType = 0;
                //item.itemTag = 0;
                //item.itemType = 22;
                //item.itemID = 6;
                //item.addValue = 1276;
                //item.addPlus = 108;
                //item.status = 1;
                //item.limitCount = 0;
                //item.price = 2552;
                //item.priceUSD = 80.16;
                //item.priceUSDT = 80.17;
                //iAPItems.Add(item);
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
        public async Task<bool> PurchaseByUSDT(uint UserID , double USDT , string productID)
        {
            bool result = false;
            double amountOfUSDT = USDT;
            if (mIAPItems.Count > 0)
            {
                amountOfUSDT = mIAPItems.Where(m => m.productID == productID).First().priceUSDT;
            }



            RestRequest RestRequest = new RestRequest($"/CQIPurchase/PurchaseByUSDT?userID={UserID}&amountOfUSDT={amountOfUSDT}&productID={productID}");
            //RestRequest RestRequest = new RestRequest($"​CQIPurchase​/PurchaseByUSDT?userID={UserID}&amountOfUSDT={amountOfUSDT}&productID={productID}");

            IRestResponse restResponse = await NftWebApiServerClient.ExecuteGetAsync(RestRequest);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                result = true;
            }
            return result;
        }
    }
}
