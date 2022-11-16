using AngleSharp;

using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Entity;
using SnakeAsianLeague.Data.Entity.BlockChain;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Paging;
using System;
using System.Globalization;
using System.Net;
using System.Numerics;
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
        private readonly RestClient BlockChainServerClient;





        public List<OptionKeyValue> RarityList = new List<OptionKeyValue>() { };
        public List<OptionKeyValue> ElementsList = new List<OptionKeyValue>() { };
        public List<OptionKeyValue> ClassList = new List<OptionKeyValue>() { };
        public List<OptionKeyValue> CountryList = new List<OptionKeyValue>() { };



        public OptionService(IConfiguration config, IOptions<ExternalServers> myConfiguration,HttpClient httpClient )
        {
            _config = config;
            externalServersConfig = myConfiguration.Value;
            
            ServerClient = new RestClient(externalServersConfig.UserServer);
            BlockChainServerClient = new RestClient(externalServersConfig.NftWebApi);
            //ServerClient = new RestClient("https://rel.ponponsnake.com/api/user");
            //Console.WriteLine("ServerClient.BaseUrl: " + ServerClient.BaseUrl);
            OptionKeyValue option = new OptionKeyValue();
            RarityList = option.Get_Default_Rarity();
            ElementsList = option.Get_Default_Elements();
            ClassList = option.Get_Default_Class();
            CountryList = option.Get_Default_Country();

        }



        /// <summary>
        /// NFT 原始資料
        /// </summary>
        List<NFTData> datas;

        /// <summary>
        /// 篩選後NFT資料
        /// </summary>
        List<NFTData> Filter =  new List<NFTData>();

        /// <summary>
        /// 取得OpenSeaURL NFT資產 官方網址
        /// </summary>
        /// <returns></returns>
        public async Task<string> Get_OpenSeaURL( int NFTtype)
        {
            string url = "";
            switch (NFTtype)
            {
                case 0:
                    url = "OpenSeaURL_PPSR";
                    break;
                case 1:
                    url = "OpenSeaURL_PPSBP";
                    break;
            }

            string OpenSeaURL = _config.GetValue<string>(url);            
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
        public async Task<List<NFTData>> GetNFTDataPageList(int pageNumber, int pageSize ,string PPSRContractAddress , string UserID)
        {

            string ImgPath = _config.GetValue<string>("googleapis");
            string LinkURL = _config.GetValue<string>("OpenSeaLink");
            string asset_contract_address = PPSRContractAddress;

            List<NFTRiderUnits> NFT_Riders = await GetNFTRiderUnits(pageNumber , pageSize);
            //我的最愛清單
            List<RiderUnit> myLove = await Get_NFT_RiderByUserID(UserID);


            //Console.WriteLine("GetNFTRiderUnits: " + NFT_Riders.Count);
            datas = new List<NFTData>();


            Random myObject = new Random();


            string Rarity = "";
            string Elements = "";

            OpenseaAssetsData rd = new OpenseaAssetsData();

            for (int i = 0; i < NFT_Riders.Count; i++)
            {


                NFTData data = new NFTData();
                data.TokenID = NFT_Riders[i].castings[0].tokenId;
                data.Number = string.Format(" PPSR {0}", NFT_Riders[i].castings[0].tokenId);
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


                if (NFT_Riders[i].castings.Count > 0)
                {
                    if (NFT_Riders[i].castings[0].totalRevenue.Count > 0)
                    {
                        data.Price = (Math.Floor(NFT_Riders[i].castings[0].totalRevenue.Where(m => m.currencyType == 22).First().price  * 100) / 100 ).ToString();

                        data.IsOpen = NFT_Riders[i].castings[0].isAvailableInGame;
                    }
                }



                List<string> RarityElements = NFT_Riders[i].serialNumber.Split('_').ToList();  //ex : NFT_Unit3_2c_1
                if (RarityElements[2] != null)
                {
                    Rarity = RarityElements[2].Substring(0, 1);
                    Elements = RarityElements[2].Substring(1, 1);
                }
                data.ImgPath = string.Format(ImgPath, "ppsr", NFT_Riders[i].serialNumber);
                data.LinkURL = string.Format(LinkURL, asset_contract_address, NFT_Riders[i].castings[0].tokenId);
                data.RarityKey = Rarity;
                data.RarityValue = RarityList.Where(m => m.Key == Rarity).First().Value;
                data.Elements = Elements;
                data.ElementsIcon = string.Format("/images/MarketPlace/ElementsIcon-{0}.webp", ElementsList.Where(m => m.Key == Elements).First().Value);
                data.ClassKey = NFT_Riders[i].occupationId == "" ? "1" : NFT_Riders[i].occupationId;
                data.ClassValue = ClassList.Where(m => m.Key == data.ClassKey).First().Value;
                //data.Country = CountryList[CountryInt].ToString();

                //int value = myObject.Next(1, 1000);
                int value = int.Parse(data.TokenID);

                data.EndTime = DateTime.Now.AddDays(value);
                data.CalDays = Math.Truncate((DateTime.Now.AddDays(value) - DateTime.Now).TotalDays) + " d "
                               + Math.Truncate(((DateTime.Now.AddDays(value) - DateTime.Now).TotalHours) - Math.Truncate((DateTime.Now.AddDays(value) - DateTime.Now).TotalDays) * 24) + " H ";

                data.isAvailableInGame = NFT_Riders[i].castings[0].isAvailableInGame;


                if (myLove.Count > 0 && myLove.Where(m => m.ppsr == "#" + data.TokenID).Count() > 0)
                {
                    data.IsLove = true;
                }
                
                datas.Add(data);
            }


            datas = datas.DistinctBy(m => m.TokenID).ToList();
            datas = datas.OrderBy(m => m.IsOpen == false).ThenBy(m => m.Number).ToList();



           

            

            Filter = datas;

            return datas;
        }

        /// <summary>
        /// 篩選頁數
        /// </summary>
        /// <param name="PageNumber"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        //public async Task<PagedList<NFTData>> GetNFTDataPageListbyPage(int PageNumber, int PageSize)
        //{
        //    return PagedList<NFTData>.ToPagedList(datas, PageNumber, PageSize);
        //}

        /// <summary>
        /// 篩選頁數
        /// </summary>
        /// <param name="PageNumber"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<List<NFTData>> GetNFTDataPageListbyPage()
        {
            return datas;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<NFTData>> GetNFTDataIsLove()
        {
            return Filter = datas.Where(m => m.IsLove == true).ToList();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrderByString"></param>
        /// <param name="PageNumber"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<PagedList<NFTData>> NFTDataListOrderby(string OrderByString , int PageNumber, int PageSize , string PPSRContractAddress)
        {
          //  datas = await GetNFTDataPageList(PageNumber, PageSize,  PPSRContractAddress);


            if (OrderByString == "HighestEarned" || OrderByString == "Sort")
            {
                Filter = Filter.OrderBy(m => m.IsOpen == false).ThenByDescending(m => m.Number).ToList();
                
            }
            if (OrderByString == "LowestEarned")
            {
                Filter = Filter.OrderBy(m => m.IsOpen == false).ThenBy(m => m.Number).ToList();
            }
            if (OrderByString == "HighestPrice")
            {
                Filter = Filter.OrderBy(m => m.IsOpen == false).ThenByDescending(m => m.Price).ToList();
            }
            if (OrderByString == "LowestPrice")
            {
                Filter = Filter.OrderBy(m => m.IsOpen == false).ThenBy(m => m.Price).ToList();
            }
            if (OrderByString == "Newest")
            {
                Filter = Filter.OrderBy(m => m.IsOpen == false).ThenByDescending(m => m.EndTime).ToList();
            }
            if (OrderByString == "Oldest")
            {
                Filter = Filter.OrderBy(m => m.IsOpen == false).ThenBy(m => m.EndTime).ToList();
            }
            return PagedList<NFTData>.ToPagedList(Filter, PageNumber, PageSize);
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
        //public async Task<PagedList<NFTData>> Get_NFT_by_Filter(int PageNumber, int PageSize, List<string> Rarity, List<string> Elements, List<string> Class, List<string> Country)
        //{
        //    Rarity = Rarity.Count == 0 ? RarityList.Select(m => m.Key).ToList() : Rarity;
        //    Elements = Elements.Count == 0 ? ElementsList.Select(m => m.Key).ToList() : Elements;
        //    Class = Class.Count == 0 ? ClassList.Select(m => m.Key).ToList() : Class;
        //    Country = Country.Count == 0 ? CountryList.Select(m => m.Key).ToList() : Country;
        //    Filter = datas.Where(m => Rarity.Contains(m.RarityKey) && Elements.Contains(m.Elements) && Class.Contains(m.ClassKey)).ToList();
        //    return PagedList<NFTData>.ToPagedList(Filter, PageNumber, PageSize);
        //}


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
        public async Task<List<NFTData>> Get_NFT_by_Filter( List<string> Rarity, List<string> Elements, List<string> Class, List<string> Country ,bool IsLove)
        {
            Rarity = Rarity.Count == 0 ? RarityList.Select(m => m.Key).ToList() : Rarity;
            Elements = Elements.Count == 0 ? ElementsList.Select(m => m.Key).ToList() : Elements;
            Class = Class.Count == 0 ? ClassList.Select(m => m.Key).ToList() : Class;
            Country = Country.Count == 0 ? CountryList.Select(m => m.Key).ToList() : Country;
            Filter = datas.Where(m => Rarity.Contains(m.RarityKey) && Elements.Contains(m.Elements) && Class.Contains(m.ClassKey) && m.IsLove == IsLove).ToList();
            return Filter;
        }





        /// <summary>
        /// 取得 Rider 有被鍛造的 NFT 
        /// </summary>
        /// mintCount 鍛造次數
        /// <returns></returns>
        private async Task<List<NFTRiderUnits>> GetNFTRiderUnits( int pageNumber ,  int pageSize )
        {
            string URL = $"NFT/Units";
            var mLoginRestRequest = new RestRequest(URL);
            mLoginRestRequest.AddHeader("Authorization", Authenticate());
            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(mLoginRestRequest);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                List<NFTRiderUnits> nFTRiderUnits = JsonSerializer.Deserialize<List<NFTRiderUnits>>(restResponse.Content) ?? new List<NFTRiderUnits>();
                return nFTRiderUnits.Where(m => m.mintCount > 0).ToList();
            }
            return new List<NFTRiderUnits>();
        }





        /// <summary>
        /// 取得 Rider 有被鍛造的 NFT 
        /// </summary>
        /// mintCount 鍛造次數
        /// <returns></returns>
        public async Task<int> GetNFTRiderUnitsCount()
        {
            int result = 0;
            var LoginRestRequest = new RestRequest($"NFT/Units");
            LoginRestRequest.AddHeader("Authorization", Authenticate());
            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(LoginRestRequest);
            //Console.WriteLine(" ResponseUri :" + restResponse.ResponseUri);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                List<NFTRiderUnits> nFTRiderUnits = JsonSerializer.Deserialize<List<NFTRiderUnits>>(restResponse.Content) ?? new List<NFTRiderUnits>();
                result = nFTRiderUnits.Where(m => m.mintCount > 0).Count();
            }
            return result;
        }



        /// <summary>
        /// 抓取 offers 清單
        /// polygon matic 鏈 抓不到
        /// </summary>
        /// <param name="TokenID"></param>
        /// <returns></returns>
        //private async Task<OpenseaOffersData> Get_NFTRider_Offers(string TokenID )
        //{
        //    string asset_contract_address = _config.GetValue<string>("asset_contract_address");
        //    string RetrieveAssets = _config.GetValue<string>("RetrieveOffers");
        //    string X_API_KEY = _config.GetValue<string>("X-API-KEY");
        //    string URL = string.Format(RetrieveAssets, asset_contract_address, TokenID );
        //    RestClient client = new RestClient(URL);
        //    RestRequest request = new RestRequest(Method.GET);
        //    /*opensea 正式環境 需要加入這2段*/
        //    request.AddHeader("Accept", "application/json");
        //    request.AddHeader("X-API-KEY", X_API_KEY);
        //    IRestResponse response = client.Execute(request);

        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        OpenseaOffersData rd = JsonSerializer.Deserialize<OpenseaOffersData>(response.Content) ?? new OpenseaOffersData();

        //        return rd;
        //    }
        //    return new OpenseaOffersData();

        //}



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
        ////public async Task<OpenseaAssetsData> GetOpenseaNFTRider(int PageNumber, int PageSize)
        //public async Task<decimal> GetSpiderHighestOffer(string TokenID)
        //{
        //    decimal result = 0;
        //    string asset_contract_address = _config.GetValue<string>("asset_contract_address");
        //    string OpenSeaLink = _config.GetValue<string>("OpenSeaLink");
        //    string URL = string.Format(OpenSeaLink, asset_contract_address, TokenID);

        //    HttpClient httpClient = new HttpClient();


        //    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "http://developer.github.com/v3/#user-agent-required");
        //    var responseMessage = await httpClient.GetAsync(URL); //發送請求

        //    if (responseMessage.StatusCode == HttpStatusCode.OK)
        //    {
        //        string responseResult = responseMessage.Content.ReadAsStringAsync().Result;//取得內容

        //        string value1 = "<div class=\"Overflowreact__OverflowContainer-sc-7qr9y8-0 jPSCbX Price--amount\" tabindex=\"-1\">";
        //        string value2 = "<!-- --> <span class=\"Price--raw-symbol\"></span>";
        //        var str1 = responseResult.IndexOf(value1);
        //        var str2 = responseResult.IndexOf(value2);
        //        if (str1 != str2  && str1 != -1 && str2 != -1 && str2 > str1)
        //        {
        //            var price = responseResult.Substring(str1 + value1.Length , str2 - str1 - value1.Length);

        //            decimal.TryParse(price, out result);

        //        }
        //        Console.WriteLine(string.Format("{0} : {1}", URL, responseMessage.StatusCode));
        //        return result;
        //    }
        //    else
        //    {
        //        Console.WriteLine(string.Format("{0} : {1}", URL, responseMessage.StatusCode));
        //    }
        //    return result;
        //}

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
        //public async Task<decimal> GetSpiderSale(string TokenID)
        //{
        //    decimal result = 0;
        //    //string asset_contract_address = _config.GetValue<string>("asset_contract_address");
        //    //string OpenSeaLink = _config.GetValue<string>("OpenSeaLink");

        //    string OpenSeaURL = _config.GetValue<string>("OpenSeaURL");


        //    string URL = string.Format(OpenSeaURL);

        //    HttpClient httpClient = new HttpClient();


        //    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "http://developer.github.com/v3/#user-agent-required");
        //    var responseMessage = await httpClient.GetAsync(URL); //發送請求

        //    if (responseMessage.StatusCode == HttpStatusCode.OK)
        //    {
        //        string responseResult = responseMessage.Content.ReadAsStringAsync().Result;//取得內容

        //        string value1 = "class=\"Blockreact__Block-sc-1xf18x6-0 Flexreact__Flex-sc-1twd32i-0 FlexColumnreact__FlexColumn-sc-1wwz3hp-0 VerticalAlignedreact__VerticalAligned-sc-b4hiel-0 CenterAlignedreact__CenterAligned-sc-cjf6mn-0 Avatarreact__AvatarContainer-sc-sbw25j-0 uqDNW jYqxGr ksFzlZ iXcsEj cgnEmv dukFGY\"><span class=\"Blockreact__Block-sc-1xf18x6-0 Avatarreact__ImgAvatar-sc-sbw25j-1 uqDNW hzWBaN\" style=\"display:inline-block\"></span></div></div><div class=\"Overflowreact__OverflowContainer-sc-7qr9y8-0 jPSCbX Price--amount\" tabindex=\"-1\">";
        //        string value2 = "<!-- --> <span class=\"Price--raw-symbol\"></span></div></div></div></div></div></div></div>";

        //        var str1 = responseResult.IndexOf(value1);
        //        var str2 = responseResult.IndexOf(value2);
        //        if (str1 != str2 && str1 != -1 && str2 != -1  && str2> str1)
        //        {
        //            var price = responseResult.Substring(str1 + value1.Length, str2 - str1 - value1.Length);

        //            decimal.TryParse(price, out result);

        //        }
        //        Console.WriteLine(string.Format("{0} : {1}", URL, responseMessage.StatusCode));
        //        return result;
        //    }
        //    else
        //    {
        //        Console.WriteLine( string.Format( "{0} : {1}" , URL, responseMessage.StatusCode));
        //    }
        //    return result;
        //}



        public class UnitDto
        {
            public string UserID { get; set; }
            public string ppsr { get; set; }
        }



        /// <summary>
        /// 將NFT加入我的最愛
        /// </summary>
        /// <param name="UsersID"></param>
        public async Task<bool> AddLove(string UserID, string ppsr)
        {
            bool result = false;
            try
            {
                string URL = "Unit/AddLove";
                RestRequest request = new RestRequest(URL, Method.POST);
                request.AddHeader("Authorization", Authenticate());
                request.AddHeader(RequestKey.Key, RequestKey.Value);

                UnitDto dto = new UnitDto();
                dto.UserID = UserID;
                dto.ppsr = "#"+ppsr;
                JsonParameter JP = new JsonParameter("", dto);
                request.AddParameter(JP);

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
        public async Task<bool> RemoveLove(string UserID, string ppsr)
        {
            bool result = false;
            try
            {
                string URL = "Unit/RemoveLove";
                RestRequest request = new RestRequest(URL, Method.POST);
                request.AddHeader("Authorization", Authenticate());
                request.AddHeader(RequestKey.Key, RequestKey.Value);
                UnitDto dto = new UnitDto();
                dto.UserID = UserID;
                dto.ppsr = "#" + ppsr;
                JsonParameter JP = new JsonParameter("", dto);
                request.AddParameter(JP);
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
        /// 取得 Rider 有被鍛造的 NFT 
        /// </summary>
        /// mintCount 鍛造次數
        /// <returns></returns>
        private async Task<List<RiderUnit>> Get_NFT_RiderByUserID(string UserID)
        {
            string URL = "/Unit/CheckForBackEnd";
            var request = new RestRequest(URL, Method.GET);
            request.AddQueryParameter("UserID", UserID);
            request.AddHeader("Authorization", Authenticate());

            IRestResponse restResponse = await ServerClient.ExecuteAsync(request);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                RiderList lists = JsonSerializer.Deserialize<RiderList>(restResponse.Content) ?? new RiderList();

                List<RiderUnit> result = new List<RiderUnit>();

                //自有
                List<RiderUnit> result1 = lists.selfUnits.Where(m => m.isNFT == true).ToList() ?? new List<RiderUnit>();
                //租任
                List<RiderUnit> result2 = lists.leaseUnits.Where(m => m.isNFT == true).ToList() ?? new List<RiderUnit>();

                result.AddRange(result1);
                result.AddRange(result2);
                result = result.Where(m => m.isLove == true).ToList() ?? new List<RiderUnit>();
                return result;
            }
            return new List<RiderUnit>();
        }

        /// <summary>
        /// 改變租金
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="ppsrID"></param>
        /// <param name="Price"></param>
        //public async Task<bool> ChangeRent(int UserID, string ppsr, int Price)
        //{
        //    bool result = false;
        //    try
        //    {
        //        string URL = "/NFT/ChangeRent";
        //        RestRequest request = new RestRequest(URL, Method.POST);
        //        request.AddHeader("Authorization", Authenticate());
        //        request.AddHeader(RequestKey.Key, RequestKey.Value);
        //        request.AddQueryParameter("userID", UserID.ToString());
        //        request.AddQueryParameter("ppsr", ppsr);
        //        request.AddQueryParameter("price", Price.ToString());
        //        var response = await ServerClient.ExecuteAsync(request);
        //        result = response.StatusCode == HttpStatusCode.OK;
        //    }
        //    catch (Exception ex)
        //    {
        //        string errormsg = ex.Message;
        //    }
        //    return result;
        //}

        /// <summary>
        /// NFT PPS 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> GetPPSMetadataList()
        {
            bool result = false;
            try 
            {
                string URL = "/BC_CharacterContract/NFTMetadataList";
                var request = new RestRequest(URL, Method.GET);
                IRestResponse restResponse = await BlockChainServerClient.ExecuteAsync(request);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    NFTMetaData ResultData = JsonSerializer.Deserialize<NFTMetaData>(restResponse.Content);
                    List<MetadataList> DataList = new List<MetadataList>();

                    foreach (var item in ResultData.metadataList)
                    {
                        var json = item.Value;
                        MetadataList rd = JsonSerializer.Deserialize<MetadataList>(json);
                        DataList.Add(rd);
                    }
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
            }
            return result;
        }


        /// <summary>
        /// NFT PPSI 
        /// </summary>
        /// <returns></returns>
        public async Task<List<MetadataList>> GetPPSIMetadataList(string contractAddress_PPSR)
        {
            List<MetadataList> DataList = new List<MetadataList>();
            try
            {
                string LinkURL = _config.GetValue<string>("OpenSeaLink");                
                string URL = "/BC_PPSI/NFTMetadataList";
                var request = new RestRequest(URL, Method.GET);
                IRestResponse restResponse = await BlockChainServerClient.ExecuteAsync(request);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    NFTMetaData ResultData = JsonSerializer.Deserialize<NFTMetaData>(restResponse.Content);


                    foreach (var item in ResultData.metadataList)
                    {
                        var json = item.Value;                        
                        MetadataList rd = JsonSerializer.Deserialize<MetadataList>(json);

                        //取得url
                        int num = item.Key;
                        string getLinkURL = string.Format(LinkURL, contractAddress_PPSR, num);
                        rd.LinkURL = getLinkURL;
                        DataList.Add(rd);

                    }
                } 
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
            }
            return DataList;
        }





        /// <summary>
        /// AddItemToMarket
        /// </summary>
        /// <param name="nftContract">合約地址</param>
        /// <param name="tokenId">NFT 編號</param>
        /// <param name="price">價錢</param>
        /// <returns></returns>
        public async Task SetMarkmaskShopItem(string nftContract, BigInteger tokenId, BigInteger price )
        {
            string Url = "Add_ShopItem";

            var request = new RestRequest(Url, Method.GET);
            IRestResponse restResponse = await BlockChainServerClient.ExecuteAsync(request);

            request.AddQueryParameter("nftContract", nftContract);
            request.AddQueryParameter("tokenId", tokenId.ToString());
            request.AddQueryParameter("price", price.ToString());
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                NFTMetaData ResultData = JsonSerializer.Deserialize<NFTMetaData>(restResponse.Content);


                
            }

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="nftContract">NFT 地址合約</param>
        /// <param name="tokenId">NFT ID編號</param>
        /// <param name="price">價錢</param>
        /// <returns></returns>
        public async Task GetMarkmaskShopList(string nftContract , decimal tokenId , decimal price)
        {
            string Url = "SellItemAndTransferOwnership";
            var request = new RestRequest(Url, Method.GET);
            IRestResponse restResponse = await BlockChainServerClient.ExecuteAsync(request);

            request.AddQueryParameter("nftContract", nftContract);
            request.AddQueryParameter("tokenId", tokenId.ToString());
            request.AddQueryParameter("price", price.ToString());
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                NFTMetaData ResultData = JsonSerializer.Deserialize<NFTMetaData>(restResponse.Content);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="nftContract"></param>
        /// <param name="tokenId"></param>
        /// <param name="price"></param>
        public async void DeleteMarkmaskShopList(string nftContract, decimal tokenId, decimal price)
        {
            string Url = "";
            var request = new RestRequest(Url, Method.GET);
            IRestResponse restResponse = await BlockChainServerClient.ExecuteAsync(request);


        }



        public void getLatestPrice(uint tokenId)
        {
            string Url = "";
        }

    }
}
