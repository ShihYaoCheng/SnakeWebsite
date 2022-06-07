using AngleSharp;

using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Entity;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Paging;
using System;
using System.Globalization;
using System.Net;
using System.Text;
using System.Text.Json;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace SnakeAsianLeague.Data.Services.MarketPlace
{
    public class OptionService
    {
        private readonly static KeyValuePair<string, string> RequestKey = new KeyValuePair<string, string>("Backend-Auth-Handler", "gmregk343grgeggw[fk55234w46wfwef46gpwekf[43-i@@!#!@#@");
        private IConfiguration _config;

        private ExternalServers externalServersConfig;
        private readonly RestClient ServerClient;
        




        public List<OptionKeyValue> RarityList = new List<OptionKeyValue>() { };
        public List<OptionKeyValue> ElementsList = new List<OptionKeyValue>() { };
        public List<OptionKeyValue> ClassList = new List<OptionKeyValue>() { };
        public List<OptionKeyValue> CountryList = new List<OptionKeyValue>() { };



        public OptionService(IConfiguration config, IOptions<ExternalServers> myConfiguration,HttpClient httpClient )
        {
            _config = config;
            

            
            externalServersConfig = myConfiguration.Value;
            
            ServerClient = new RestClient(externalServersConfig.UserServer);

            OptionKeyValue option = new OptionKeyValue();
            RarityList = option.Get_Default_Rarity();
            ElementsList = option.Get_Default_Elements();
            ClassList = option.Get_Default_Class();
            CountryList = option.Get_Default_Country();

        }




        List<NFTData> datas;

        /// <summary>
        /// 取得OpenSeaURL NFT資產 官方網址
        /// </summary>
        /// <returns></returns>
        public async Task<string> Get_OpenSeaURL()
        {
            string OpenSeaURL = _config.GetValue<string>("OpenSeaURL");            
            return OpenSeaURL;
        }


        /// <summary>
        /// 取得稀有度
        /// </summary>
        /// <returns></returns>
        public async Task<List<OptionKeyValue>> Get_Default_Rarity()
        {
            return RarityList;
        }

        /// <summary>
        /// 取得屬性
        /// </summary>
        /// <returns></returns>
        public async Task<List<OptionKeyValue>> Get_Default_Elements()
        {
            return ElementsList;
        }

        /// <summary>
        /// 取得職業專精
        /// </summary>
        /// <returns></returns>
        public async Task<List<OptionKeyValue>> Get_Default_Class()
        {
            return ClassList;
        }

        /// <summary>
        /// 取得國家
        /// </summary>
        /// <returns></returns>
        public async Task<List<OptionKeyValue>> Get_Default_Country()
        {
            return CountryList;
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="PageNumber"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<PagedList<NFTData>> GetNFTDataPageList( int PageNumber , int PageSize)
        {

            string ImgPath = _config.GetValue<string>("googleapis");
            string LinkURL = _config.GetValue<string>("OpenSeaLink");
            string asset_contract_address = _config.GetValue<string>("asset_contract_address");

            List<NFTRiderUnits> NFT_Riders = await GetNFTRiderUnits();

            datas = new List<NFTData>();


            Random myObject = new Random();

            
            string Rarity = "";
            string Elements = "";

            OpenseaAssetsData rd = new OpenseaAssetsData();

            for (int i = 0; i < NFT_Riders.Count; i++)
            {
                

                NFTData data = new NFTData();
                data.TokenID = NFT_Riders[i].castings[0].tokenId;
                data.Number =  string.Format(" PPSR {0}",NFT_Riders[i].castings[0].tokenId);
                data.Name = NFT_Riders[i].name;
                data.serialNumber = NFT_Riders[i].serialNumber;
                //可能沒有拍賣紀錄




                if (i % 50 == 0)
                {
                    rd = await GetOpenseaNFTRider(i + 1, 50);
                }

                assets assets = new assets();

                if (rd.assets != null)
                {
                    //遊戲api有資料但是還 沒上opensea/沒上鏈
                    assets = rd.assets.Where(m => m.token_id == NFT_Riders[i].castings[0].tokenId).FirstOrDefault() ?? new assets();
                }

                if (assets.last_sale != null)
                {
                    string total_price = assets.last_sale.total_price;
                    Decimal decimals = Convert.ToDecimal(Math.Pow(10, assets.last_sale.payment_token.decimals));
                    Decimal Price = Decimal.Parse(total_price.ToString()) / Decimal.Parse(decimals.ToString());
                    Decimal usd_price = 0;
                    Decimal.TryParse(assets.last_sale.payment_token.usd_price ?? "0", out usd_price);
                    data.Price = Price.ToString();    //myObject.Next(value, value * 10);
                    data.USD = (Decimal.Parse(data.Price) * usd_price).ToString("#,##0.###,", CultureInfo.InvariantCulture);
                    data.IsOpen = true;
                    data.IsOfficial = true;

                }
                else
                {
                    data.IsOfficial = true;
                    data.IsOpen = false;
                }


                //decimal HighestOfferPrice = await GetSpiderHighestOffer(data.Number);

                //if (HighestOfferPrice != 0)
                //{
                //    data.Price = HighestOfferPrice.ToString();
                //    data.IsOpen = true;
                //    data.IsOfficial = true;
                //}
                //else
                //{
                //    decimal SalePrice = await GetSpiderSale(data.Number);

                //    if (SalePrice != 0)
                //    {
                //        data.Price = SalePrice.ToString();
                //        data.IsOpen = true;
                //        data.IsOfficial = false;
                //    }
                //    else
                //    {
                //        data.IsOpen = false;
                //        data.IsOfficial = false;
                //    }
                //}


                List<string> RarityElements = NFT_Riders[i].serialNumber.Split('_').ToList();  //ex : NFT_Unit3_2c_1
                if (RarityElements[2] != null)
                {
                    Rarity = RarityElements[2].Substring(0, 1);
                    Elements = RarityElements[2].Substring(1, 1);
                }
                data.ImgPath = string.Format(ImgPath,"ppsr", NFT_Riders[i].serialNumber);
                data.LinkURL = string.Format(LinkURL, asset_contract_address, NFT_Riders[i].castings[0].tokenId);
                data.RarityKey = Rarity;
                data.RarityValue = RarityList.Where(m => m.Key == Rarity).First().Value;
                data.Elements = Elements;
                data.ElementsIcon = string.Format("/images/MarketPlace/Element-{0}.png", ElementsList.Where(m => m.Key == Elements).First().Value);
                data.ClassKey = NFT_Riders[i].occupationId == "" ? "1" : NFT_Riders[i].occupationId;
                data.ClassValue = ClassList.Where(m => m.Key == data.ClassKey).First().Value;
                //data.Country = CountryList[CountryInt].ToString();

                int value = myObject.Next(1, 1000);
                data.EndTime = DateTime.Now.AddDays(value);
                data.CalDays = Math.Truncate((DateTime.Now.AddDays(value) - DateTime.Now).TotalDays) + " d "
                               + Math.Truncate(((DateTime.Now.AddDays(value) - DateTime.Now).TotalHours) - Math.Truncate((DateTime.Now.AddDays(value) - DateTime.Now).TotalDays) * 24) + " H ";
                datas.Add(data);
            }


            ///*加入一隻 Coming Soon*/
            //NFTData data1 = new NFTData();
            //data1.Number ="0";
            //data1.Name = "Coming Soon";
            //data1.IsOpen = false;
            //data1.IsOfficial = true;
            //data1.ImgPath = data1.ImgPath==null ? "/images/MarketPlace/NFTproduct.png" : data1.ImgPath;
            //datas.Add(data1);

            datas = datas.OrderBy(m => m.IsOpen == false).ThenBy(m => m.Number).ToList();
            return PagedList<NFTData>.ToPagedList(datas, PageNumber, PageSize);
        }



        /// <summary>
        /// 篩選頁數
        /// </summary>
        /// <param name="PageNumber"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<PagedList<NFTData>> GetNFTDataPageListbyPage(int PageNumber, int PageSize)
        {

            return PagedList<NFTData>.ToPagedList(datas, PageNumber, PageSize);
        }
        


        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrderByString"></param>
        /// <param name="PageNumber"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<PagedList<NFTData>> NFTDataListOrderby(string OrderByString , int PageNumber, int PageSize)
        {
            if (OrderByString == "Highest Earned" || OrderByString == "Sort")
            {
                datas = datas.OrderBy(m => m.IsOpen == false).ThenByDescending(m => m.Number).ToList();
                
            }
            if (OrderByString == "Lowest Earned")
            {
                datas = datas.OrderBy(m => m.IsOpen == false).ThenBy(m => m.Number).ToList();
            }
            if (OrderByString == "Highest Price")
            {
                datas = datas.OrderBy(m => m.IsOpen == false).ThenByDescending(m => m.Price).ToList();
            }
            if (OrderByString == "Lowest Price")
            {
                datas = datas.OrderBy(m => m.IsOpen == false).ThenBy(m => m.Price).ToList();
            }
            if (OrderByString == "Newest")
            {
                datas = datas.OrderBy(m => m.IsOpen == false).ThenByDescending(m => m.EndTime).ToList();
            }
            if (OrderByString == "Oldest")
            {
                datas = datas.OrderBy(m => m.IsOpen == false).ThenBy(m => m.EndTime).ToList();
            }
            return PagedList<NFTData>.ToPagedList(datas, PageNumber, PageSize);
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="PageNumber"></param>
        /// <param name="PageSize"></param>
        /// <param name="Rarity"></param>
        /// <param name="Elements"></param>
        /// <param name="Class"></param>
        /// <param name="Country"></param>
        /// <returns></returns>
        public async Task<PagedList<NFTData>> Get_NFT_by_Filter(int PageNumber, int PageSize , List<string> Rarity , List<string> Elements, List<string> Class, List<string> Country)
        {

            List<NFTData> Filter = new List<NFTData>();
            Rarity = Rarity.Count == 0 ? RarityList.Select(m => m.Key).ToList() : Rarity;
            Elements = Elements.Count == 0 ? ElementsList.Select(m => m.Key).ToList() : Elements;
            Class = Class.Count == 0 ? ClassList.Select(m => m.Key).ToList() : Class;
            Country = Country.Count == 0 ? CountryList.Select(m => m.Key).ToList() : Country;
            //if (Rarity.Count == 0)
            //{
            //    Rarity = RarityList.Select(m=>m.Key).ToList();
            //    //Rarity.Add("");
            //}
            //if (Elements.Count == 0)
            //{
            //    Elements = ElementsList.Select(m => m.Key).ToList();
            //    //Elements.Add("");
            //}
            //if (Class.Count == 0)
            //{
            //    Class = ClassList.Select(m => m.Key).ToList();
            //    //Class.Add("");
            //}
            //if (Country.Count == 0)
            //{
            //    Country = CountryList.Select(m => m.Key).ToList();
            //    Country.Add("");
            //    Country.Add(null);
            //}
            //|| Country.Contains(m.Country)

            Filter = datas.Where(m => Rarity.Contains(m.RarityKey) && Elements.Contains(m.Elements) && Class.Contains(m.ClassKey) ).ToList();

            return PagedList<NFTData>.ToPagedList(Filter, PageNumber, PageSize);
        }





        /// <summary>
        /// 取得 Rider 有被鍛造的 NFT 
        /// </summary>
        /// mintCount 鍛造次數
        /// <returns></returns>
        private async Task<List<NFTRiderUnits>> GetNFTRiderUnits()
        {
            //var LoginRestRequest = new RestRequest($"NFT/Units");
            //LoginRestRequest.AddHeader("Authorization", Authenticate());

            //IRestResponse restResponse = await ServerClient.ExecuteGetAsync(LoginRestRequest);
            //if (restResponse.StatusCode == HttpStatusCode.OK)
            //{
            //    List<NFTRiderUnits> nFTRiderUnits = JsonSerializer.Deserialize<List<NFTRiderUnits>>(restResponse.Content) ?? new List<NFTRiderUnits>();
            //    return nFTRiderUnits.Where(m => m.mintCount > 0).ToList();
            //}
            //return  new List<NFTRiderUnits>();


            string URL = @"http://104.199.196.10/api/user/NFT/Units";

            var mLoginRestRequest = new RestRequest(URL);
            mLoginRestRequest.AddHeader("Authorization", Authenticate());

            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(mLoginRestRequest);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                List<NFTRiderUnits> nFTRiderUnits = JsonSerializer.Deserialize<List<NFTRiderUnits>>(restResponse.Content) ?? new List<NFTRiderUnits>();
                return nFTRiderUnits.Where(m => m.mintCount > 0).ToList();
            }
            return  new List<NFTRiderUnits>();
        }




        /// <summary>
        /// 抓取 offers 清單
        /// polygon matic 鏈 抓不到
        /// </summary>
        /// <param name="TokenID"></param>
        /// <returns></returns>
        private async Task<OpenseaOffersData> Get_NFTRider_Offers(string TokenID )
        {
            string asset_contract_address = _config.GetValue<string>("asset_contract_address");
            string RetrieveAssets = _config.GetValue<string>("RetrieveOffers");
            string X_API_KEY = _config.GetValue<string>("X-API-KEY");
            string URL = string.Format(RetrieveAssets, asset_contract_address, TokenID );
            RestClient client = new RestClient(URL);
            RestRequest request = new RestRequest(Method.GET);
            /*opensea 正式環境 需要加入這2段*/
            request.AddHeader("Accept", "application/json");
            request.AddHeader("X-API-KEY", X_API_KEY);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                OpenseaOffersData rd = JsonSerializer.Deserialize<OpenseaOffersData>(response.Content) ?? new OpenseaOffersData();

                return rd;
            }
            return new OpenseaOffersData();

        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string Authenticate()
        {
            string auth = "Unity:Yx2fy5tFfDHAfU7Az";
            auth = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
            auth = "Basic " + auth;
            return auth;
        }



        /// <summary>
        /// 呼叫opensea api 依照資產地址
        /// opensea api 最多抓50筆
        /// polygon matic 鏈 抓不到
        /// </summary>
        /// <param name="offset">第幾筆開始</param>
        /// <param name="limit">顯示幾筆資料/抓取資料筆數</param>
        /// 
        /// <returns></returns>
        //public async Task<OpenseaAssetsData> GetOpenseaNFTRider(int PageNumber, int PageSize)
        public async Task<OpenseaAssetsData> GetOpenseaNFTRider(int offset, int limit)
        {
            limit = (limit > 50 ) ? 50 : limit;            
            string asset_contract_address = _config.GetValue<string>("asset_contract_address");
            string RetrieveAssets = _config.GetValue<string>("RetrieveAssets");
            string X_API_KEY = _config.GetValue<string>("X-API-KEY");
            string URL = string.Format(RetrieveAssets, asset_contract_address, offset , limit);
            


            RestClient client = new RestClient(URL);
            RestRequest request = new RestRequest(Method.GET);
            /*opensea 正式環境 需要加入這2段*/
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("X-API-KEY", X_API_KEY);
            IRestResponse response = client.Execute(request);

            
            if (response.StatusCode == HttpStatusCode.OK)
            {
                OpenseaAssetsData rd = JsonSerializer.Deserialize<OpenseaAssetsData>(response.Content) ?? new OpenseaAssetsData();

                return rd;
            }
            return new OpenseaAssetsData();
        }







        /// <summary>
        /// 呼叫opensea api 依照資產地址
        /// opensea api 最多抓50筆
        /// polygon matic 鏈 抓不到
        /// </summary>
        /// <param name="offset">第幾筆開始</param>
        /// <param name="limit">顯示幾筆資料/抓取資料筆數</param>
        /// 
        /// <returns></returns>
        //public async Task<OpenseaAssetsData> GetOpenseaNFTRider(int PageNumber, int PageSize)
        public async Task<decimal> GetSpiderHighestOffer(string TokenID)
        {
            decimal result = 0;
            string asset_contract_address = _config.GetValue<string>("asset_contract_address");
            string OpenSeaLink = _config.GetValue<string>("OpenSeaLink");
            string URL = string.Format(OpenSeaLink, asset_contract_address, TokenID);

            HttpClient httpClient = new HttpClient();


            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "http://developer.github.com/v3/#user-agent-required");
            var responseMessage = await httpClient.GetAsync(URL); //發送請求

            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                string responseResult = responseMessage.Content.ReadAsStringAsync().Result;//取得內容

                string value1 = "<div class=\"Overflowreact__OverflowContainer-sc-7qr9y8-0 jPSCbX Price--amount\" tabindex=\"-1\">";
                string value2 = "<!-- --> <span class=\"Price--raw-symbol\"></span>";
                var str1 = responseResult.IndexOf(value1);
                var str2 = responseResult.IndexOf(value2);
                if (str1 != str2  && str1 != -1 && str2 != -1 && str2 > str1)
                {
                    var price = responseResult.Substring(str1 + value1.Length , str2 - str1 - value1.Length);

                    decimal.TryParse(price, out result);
                    
                }
                Console.WriteLine(string.Format("{0} : {1}", URL, responseMessage.StatusCode));
                return result;
            }
            else
            {
                Console.WriteLine(string.Format("{0} : {1}", URL, responseMessage.StatusCode));
            }
            return result;
        }

        /// <summary>
        /// 呼叫opensea api 依照資產地址
        /// opensea api 最多抓50筆
        /// polygon matic 鏈 抓不到
        /// </summary>
        /// <param name="offset">第幾筆開始</param>
        /// <param name="limit">顯示幾筆資料/抓取資料筆數</param>
        /// 
        /// <returns></returns>
        //public async Task<OpenseaAssetsData> GetOpenseaNFTRider(int PageNumber, int PageSize)
        public async Task<decimal> GetSpiderSale(string TokenID)
        {
            decimal result = 0;
            //string asset_contract_address = _config.GetValue<string>("asset_contract_address");
            //string OpenSeaLink = _config.GetValue<string>("OpenSeaLink");

            string OpenSeaURL = _config.GetValue<string>("OpenSeaURL");

            
            string URL = string.Format(OpenSeaURL);

            HttpClient httpClient = new HttpClient();


            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "http://developer.github.com/v3/#user-agent-required");
            var responseMessage = await httpClient.GetAsync(URL); //發送請求

            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                string responseResult = responseMessage.Content.ReadAsStringAsync().Result;//取得內容

                string value1 = "class=\"Blockreact__Block-sc-1xf18x6-0 Flexreact__Flex-sc-1twd32i-0 FlexColumnreact__FlexColumn-sc-1wwz3hp-0 VerticalAlignedreact__VerticalAligned-sc-b4hiel-0 CenterAlignedreact__CenterAligned-sc-cjf6mn-0 Avatarreact__AvatarContainer-sc-sbw25j-0 uqDNW jYqxGr ksFzlZ iXcsEj cgnEmv dukFGY\"><span class=\"Blockreact__Block-sc-1xf18x6-0 Avatarreact__ImgAvatar-sc-sbw25j-1 uqDNW hzWBaN\" style=\"display:inline-block\"></span></div></div><div class=\"Overflowreact__OverflowContainer-sc-7qr9y8-0 jPSCbX Price--amount\" tabindex=\"-1\">";
                string value2 = "<!-- --> <span class=\"Price--raw-symbol\"></span></div></div></div></div></div></div></div>";

                var str1 = responseResult.IndexOf(value1);
                var str2 = responseResult.IndexOf(value2);
                if (str1 != str2 && str1 != -1 && str2 != -1  && str2> str1)
                {
                    var price = responseResult.Substring(str1 + value1.Length, str2 - str1 - value1.Length);

                    decimal.TryParse(price, out result);

                }
                Console.WriteLine(string.Format("{0} : {1}", URL, responseMessage.StatusCode));
                return result;
            }
            else
            {
                Console.WriteLine( string.Format( "{0} : {1}" , URL, responseMessage.StatusCode));
            }
            return result;
        }





        /// <summary>
        /// 將NFT加入我的最愛
        /// </summary>
        /// <param name="UsersID"></param>
        public async Task<bool> AddLove(int UserID, string ppsr)
        {
            bool result = false;
            try
            {
                string URL = "Unit/AddLove";
                RestRequest request = new RestRequest(URL, Method.POST);
                request.AddHeader("Authorization", Authenticate());
                request.AddHeader(RequestKey.Key, RequestKey.Value);
                request.AddQueryParameter("userID", UserID.ToString());
                request.AddQueryParameter("ppsr", ppsr);
                var response = await ServerClient.ExecuteAsync(request);
                result = response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
            }
            return result;
        }


        /// <summary>
        /// 移除我的最愛
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="ppsrID"></param>
        public async Task<bool> RemoveLove(int UserID, string ppsr)
        {
            bool result = false;
            try
            {
                string URL = "Unit/RemoveLove";
                RestRequest request = new RestRequest(URL, Method.POST);
                request.AddHeader("Authorization", Authenticate());
                request.AddHeader(RequestKey.Key, RequestKey.Value);
                request.AddQueryParameter("userID", UserID.ToString());
                request.AddQueryParameter("ppsr", ppsr);
                var response = await ServerClient.ExecuteAsync(request);
                result = response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
            }
            return result;
        }


        /// <summary>
        /// 改變租金
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="ppsrID"></param>
        /// <param name="Price"></param>
        public async Task<bool> ChangeRent(int UserID, string ppsr, int Price)
        {
            bool result = false;
            try
            {
                string URL = "/NFT/ChangeRent";
                RestRequest request = new RestRequest(URL, Method.POST);
                request.AddHeader("Authorization", Authenticate());
                request.AddHeader(RequestKey.Key, RequestKey.Value);
                request.AddQueryParameter("userID", UserID.ToString());
                request.AddQueryParameter("ppsr", ppsr);
                request.AddQueryParameter("price", Price.ToString());
                var response = await ServerClient.ExecuteAsync(request);
                result = response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
            }
            return result;
        }
    }
}
