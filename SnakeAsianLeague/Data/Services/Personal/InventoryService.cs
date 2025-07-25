﻿using Microsoft.Extensions.Options;
using QRCoder;
using RestSharp;
using SnakeAsianLeague.Data.Contracts;
using SnakeAsianLeague.Data.Entity;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Paging;
using System.Globalization;
using System.Net;
using System.Text.Json;

namespace SnakeAsianLeague.Data.Services.Personal
{
    public class InventoryService
    {
        private readonly static KeyValuePair<string, string> RequestKey = new KeyValuePair<string, string>("Backend-Auth-Handler", "gmregk343grgeggw[fk55234w46wfwef46gpwekf[43-i@@!#!@#@");
        private IConfiguration _config;
        private ExternalServers externalServersConfig;
        private readonly RestClient ServerClient;
        private readonly RestClient BlockChainServerClient;
        private IAuthManagement _AuthManagement;

        List<NFTData> NFTDataList;
        /// <summary>
        /// 排序後
        /// </summary>
        List<NFTData> Filter;


        public List<OptionKeyValue> RarityList = new List<OptionKeyValue>() { };
        public List<OptionKeyValue> ElementsList = new List<OptionKeyValue>() { };
        public List<OptionKeyValue> ClassList = new List<OptionKeyValue>() { };
        public List<OptionKeyValue> CountryList = new List<OptionKeyValue>() { };

        private readonly IHttpContextAccessor _httpContextAccessor;

        public InventoryService(IConfiguration config, IOptions<ExternalServers> myConfiguration, HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IAuthManagement authManagement)
        {
            _config = config;
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.UserServer);

            BlockChainServerClient = new RestClient(externalServersConfig.NftWebApi);
            _AuthManagement = authManagement;

            OptionKeyValue option = new OptionKeyValue();
            RarityList = option.Get_Default_Rarity();
            ElementsList = option.Get_Default_Elements();
            ClassList = option.Get_Default_Class();
            CountryList = option.Get_Default_Country();
            _httpContextAccessor = httpContextAccessor;
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
        public async Task<PagedList<NFTData>> GetRiderNFTDataPageList(string UserID, int PageNumber, int PageSize, string PPSRContractAddress ,string OpenSeaLink , string googleapis)
        {
            string ImgPath = googleapis;
            string LinkURL = OpenSeaLink;
            string asset_contract_address = PPSRContractAddress;

            List<RiderUnit> NFT_Riders = await Get_NFT_RiderByUserID(UserID);

            NFTDataList = new List<NFTData>();


            Random myObject = new Random();


            string Rarity = "";
            string Elements = "";

            OpenseaAssetsData rd = new OpenseaAssetsData();



            try
            {
                for (int i = 0; i < NFT_Riders.Count; i++)
                {


                    NFTData data = new NFTData();

                    data.TokenID = NFT_Riders[i].ppsr.Replace("#", "");
                    data.Number = NFT_Riders[i].ppsr.Replace("#", "PPSR ");
                    data.Name = NFT_Riders[i].serialNumber;
                    data.serialNumber = NFT_Riders[i].serialNumber;
                    //可能沒有拍賣紀錄
                    if (i % 50 == 0)
                    {
                        //rd = await GetOpenseaNFTRider(i + 1, 50);
                    }
                    assets assets = new assets();

                    if (rd.assets != null)
                    {
                        //遊戲api有資料但是還 沒上opensea/沒上鏈
                        assets = rd.assets.Where(m => m.token_id == data.Number).FirstOrDefault() ?? new assets();
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
                        data.IsOpen = true;

                        data.IsOfficial = true;
                    }

                    List<string> RarityElements = NFT_Riders[i].serialNumber.Split('_').ToList();  //ex : NFT_Unit3_2c_1
                    if (RarityElements[2] != null)
                    {
                        Rarity = RarityElements[2].Substring(0, 1);
                        Elements = RarityElements[2].Substring(1, 1);
                    }
                    data.ImgPath = string.Format(ImgPath, "ppsr", NFT_Riders[i].serialNumber);
                    data.LinkURL = string.Format(LinkURL, asset_contract_address, data.Number);
                    //data.RarityKey = Rarity;
                    //data.Elements = Elements;
                    //data.Class = NFT_Riders.selfUnits[i].occupationId;
                    //data.Country = CountryList[CountryInt].ToString();
                    data.RarityKey = Rarity;
                    data.RarityValue = RarityList.Where(m => m.Key == Rarity).First().Value;
                    data.Elements = Elements;
                    data.ElementsIcon = string.Format("/images/MarketPlace/ElementsIcon-{0}.webp", ElementsList.Where(m => m.Key == Elements).First().Value);
                    //if (NFT_Riders[i].occupationId != null)
                    //{
                    //    data.ClassKey = NFT_Riders[i].occupationId == "" ? "1" : NFT_Riders[i].occupationId;
                    //}
                    //else
                    //{

                    //}

                    data.ClassKey = "1";
                    data.ClassValue = ClassList.Where(m => m.Key == data.ClassKey).First().Value;

                    int value = myObject.Next(1, 1000);
                    data.EndTime = DateTime.Now.AddDays(value);
                    data.CalDays = Math.Truncate((DateTime.Now.AddDays(value) - DateTime.Now).TotalDays) + " d "
                                   + Math.Truncate(((DateTime.Now.AddDays(value) - DateTime.Now).TotalHours) - Math.Truncate((DateTime.Now.AddDays(value) - DateTime.Now).TotalDays) * 24) + " H ";



                    data.rentType = NFT_Riders[i].rentType;

                    if (data.rentType == 1)
                    {
                        //租金
                        data.nowRent = Decimal.Round(NFT_Riders[i].goldRent, 3);
                        //累計租金(累計收益)
                        data.totalRevenue = Decimal.Round(NFT_Riders[i].totalRevenue.Where(m => m.currencyType == 1).First().price, 3);
                    }
                    else if (data.rentType == 22)
                    {
                        data.nowRent = Decimal.Round(NFT_Riders[i].rent, 3);
                        //累計租金(累計收益)
                        data.totalRevenue = Decimal.Round(NFT_Riders[i].totalRevenue.Where(m => m.currencyType == 22).First().price, 3);
                    }



                    NFTDataList.Add(data);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" 個人 inventory 錯誤 :" + ex.Message);

            }


            /*加入一隻 Coming Soon*/
            //NFTData data1 = new NFTData();
            //data1.Number = "0";
            //data1.Name = "Coming Soon";
            //data1.IsOpen = false;
            //data1.IsOfficial = true;
            //NFTDataList.Add(data1);

            NFTDataList = NFTDataList.OrderBy(m => m.IsOpen == false).ThenBy(m => m.Number).ToList();
            Filter = NFTDataList;
            return PagedList<NFTData>.ToPagedList(NFTDataList, PageNumber, PageSize);

        }


        public async Task<PagedList<NFTData>> GetRiderNFTDataListOrderby(string OrderByString, int PageNumber, int PageSize)
        {
            if (OrderByString == "Highest Earned" || OrderByString == "Sort")
            {
                Filter = Filter.OrderBy(m => m.IsOpen == false).ThenByDescending(m => m.Number).ToList();

            }
            if (OrderByString == "Lowest Earned")
            {
                Filter = Filter.OrderBy(m => m.IsOpen == false).ThenBy(m => m.Number).ToList();
            }
            if (OrderByString == "Highest Price")
            {
                Filter = Filter.OrderBy(m => m.IsOpen == false).ThenByDescending(m => m.Price).ToList();
            }
            if (OrderByString == "Lowest Price")
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
        public async Task<PagedList<NFTData>> Get_NFT_by_Filter(int PageNumber, int PageSize, List<string> Rarity, List<string> Elements, List<string> Class, List<string> Country)
        {
            Rarity = Rarity.Count == 0 ? RarityList.Select(m => m.Key).ToList() : Rarity;
            Elements = Elements.Count == 0 ? ElementsList.Select(m => m.Key).ToList() : Elements;
            Class = Class.Count == 0 ? ClassList.Select(m => m.Key).ToList() : Class;
            Country = Country.Count == 0 ? CountryList.Select(m => m.Key).ToList() : Country;

            Filter = NFTDataList.Where(m => Rarity.Contains(m.RarityKey) && Elements.Contains(m.Elements) && Class.Contains(m.ClassKey)).ToList();

            return PagedList<NFTData>.ToPagedList(Filter, PageNumber, PageSize);
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
            limit = (limit > 50) ? 50 : limit;
            string asset_contract_address = _config.GetValue<string>("asset_contract_address");
            string RetrieveAssets = _config.GetValue<string>("RetrieveAssets");
            string X_API_KEY = _config.GetValue<string>("X-API-KEY");
            string URL = string.Format(RetrieveAssets, asset_contract_address, offset, limit);
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
        /// 取得 Rider 有被鍛造的 NFT 
        /// </summary>
        /// <returns></returns>
        private async Task<List<RiderUnit>> Get_NFT_RiderByUserID(string UserID)
        {
            string URL = "/Unit/CheckForBackEnd";
            var request = new RestRequest(URL, Method.GET);
            request.AddQueryParameter("UserID", UserID);
            request.AddHeader("Authorization", $"Bearer {_AuthManagement.GetAdminAccessTokenInCookie()}");

            IRestResponse restResponse = await ServerClient.ExecuteAsync(request);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                RiderList lists = JsonSerializer.Deserialize<RiderList>(restResponse.Content) ?? new RiderList();
                //自有
                List<RiderUnit> result = lists.selfUnits.Where(m => m.isNFT == true).ToList() ?? new List<RiderUnit>();
                //租任
                //List<RiderUnit> result = lists.leaseUnits.Where(m => m.isNFT == true).ToList() ?? new List<RiderUnit>();
                return result;
            }
            return new List<RiderUnit>();
        }

       



        /// <summary>
        /// 依照單位一件領取
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="ppsr"></param>
        /// <returns></returns>
        public async Task<List<totalRevenue>> ReceiveRentByUnit(string userId, string ppsr)
        {
            List<totalRevenue> result = new List<totalRevenue>();
            ppsr = string.Format("#{0}", ppsr);
            //ppsr = ppsr.Replace("#", "%23");
            string URL = "NFT/ReceiveRentByUnit";
            var request = new RestRequest(URL, Method.GET);
            request.AddQueryParameter("userID", userId);
            request.AddQueryParameter("ppsr", ppsr);
            request.AddHeader("Authorization", $"Bearer {_AuthManagement.GetAdminAccessTokenInCookie()}");

            IRestResponse restResponse = await ServerClient.ExecuteAsync(request);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                result = JsonSerializer.Deserialize<List<totalRevenue>>(restResponse.Content);
            }

            return result;
        }

        /// <summary>
        /// 一件領取租金
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<totalRevenue>> ReceiveRent(string userId)
        {

            List<totalRevenue> result = new List<totalRevenue>();

            string URL = "/NFT/ReceiveRent";
            var request = new RestRequest(URL, Method.GET);
            request.AddQueryParameter("userID", userId);
            request.AddHeader("Authorization", $"Bearer {_AuthManagement.GetAdminAccessTokenInCookie()}");

            IRestResponse restResponse = await ServerClient.ExecuteAsync(request);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                result = JsonSerializer.Deserialize<List<totalRevenue>>(restResponse.Content);
            }
            return result;

        }

        /// <summary>
        /// 計算領取租金
        /// 抓取SRC租金
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<decimal> CalReceiveRent(string userId)
        {
            List<RiderUnit> DataList = await Get_NFT_RiderByUserID(userId);
            decimal result = decimal.Parse(DataList.Where(m => m.rentType == 22).Select(m => m.totalRevenue.Where(n => n.currencyType == 22).First().price).Sum().ToString());
            //decimal result = 0;
            return Math.Round(result, 3, MidpointRounding.AwayFromZero);
        }


        /// <summary>
        /// 計算領取租金
        /// 抓取星鑽租金
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<decimal> CalReceiveRentGold(string userId)
        {
            List<RiderUnit> DataList = await Get_NFT_RiderByUserID(userId);
            decimal result = decimal.Parse(DataList.Where(m => m.rentType == 1).Select(m => m.totalRevenue.Where(n => n.currencyType == 1).First().price).Sum().ToString());
            //decimal result = 0;
            return Math.Round(result, 3, MidpointRounding.AwayFromZero);
        }



        /// <summary>
        /// 透過 userId 取得遊戲gSRC數量
        /// </summary>
        /// <returns></returns>
        public async Task<decimal> GetgSRCCurrency1(string UserID, int currencyType)
        {

            decimal result = 0;

            result = await GetAllCurrencies(UserID, currencyType);
            //string URL = "/NFT/NFTCurrency1";
            //var request = new RestRequest(URL, Method.GET);
            //request.AddQueryParameter("userId", UserID);
            //request.AddHeader("Authorization", Authenticate());

            //IRestResponse restResponse = await ServerClient.ExecuteAsync(request);
            //if (restResponse.StatusCode == HttpStatusCode.OK)
            //{
            //    gSRCCurrency data = JsonSerializer.Deserialize<gSRCCurrency>(restResponse.Content) ?? new gSRCCurrency();
            //    result = decimal.Round(data.nftCurrency1, 3);
            //}
            return result;

        }



        /// <summary>
        /// 透過 userId 取得遊戲gSRC數量
        /// 1 Gold
        /// 22 SRC
        /// 28 ERNC
        /// </summary>
        /// <returns></returns>
        public async Task<decimal> GetAllCurrencies(string UserID, int currencyType)
        {

            decimal result = 0;
            string URL = "/NFT/AllCurrencies";
            var request = new RestRequest(URL, Method.GET);
            request.AddQueryParameter("userId", UserID);
            request.AddHeader("Authorization", $"Bearer {_AuthManagement.GetAdminAccessTokenInCookie()}");

            IRestResponse restResponse = await ServerClient.ExecuteAsync(request);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                List<Currencies> data = JsonSerializer.Deserialize<List<Currencies>>(restResponse.Content) ?? new List<Currencies>();


                try
                {
                    result = decimal.Round(data.Where(m => m.currencyType == currencyType).First().price, 3);
                }
                catch (Exception)
                {

                    result = 0;
                }
            }
            return result;

        }











        public class AllowanceData
        {
            public decimal allowance { get; set; }
        }



        public class CountData
        {
            public decimal count { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<decimal> SRCExchangeApprove(string UserID, decimal amount)
        {

            decimal result = 0;
            string URL = "/BC_SRCExchange/Approve";
            var request = new RestRequest(URL, Method.GET);
            request.AddQueryParameter("userID", UserID);
            request.AddQueryParameter("amount", amount.ToString());
            IRestResponse restResponse = await BlockChainServerClient.ExecuteAsync(request);

            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                AllowanceData data = JsonSerializer.Deserialize<AllowanceData>(restResponse.Content) ?? new AllowanceData();
                result = data.allowance;
            }
            return result;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<decimal> TSRCExchangeApprove(string UserID, decimal amount)
        {

            decimal result = 0;
            string URL = "/BC_TSRCExchange/Approve";
            var request = new RestRequest(URL, Method.GET);
            request.AddQueryParameter("userID", UserID);
            request.AddQueryParameter("amount", amount.ToString());
            IRestResponse restResponse = await BlockChainServerClient.ExecuteAsync(request);

            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                AllowanceData data = JsonSerializer.Deserialize<AllowanceData>(restResponse.Content) ?? new AllowanceData();
                result = data.allowance;
            }
            return result;
        }




        #region


        /// <summary>
        /// 取得邀請碼
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public async Task<InvitationCodeDto> GetInvitationCode(string UserID)
        {
            InvitationCodeDto result = new InvitationCodeDto();
            string URL = $"InvitationCode";
            var request = new RestRequest(URL, Method.GET);
            request.AddQueryParameter("userId", UserID);
            request.AddHeader("Authorization", $"Bearer {_AuthManagement.GetUserAccessTokenInCookie()}");
            IRestResponse restResponse = await ServerClient.ExecuteAsync(request);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                result = JsonSerializer.Deserialize<InvitationCodeDto>(restResponse.Content) ?? new InvitationCodeDto();
            }
            return result;
        }

        /// <summary>
        /// 取得回傳訊息
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public async Task<bool> GetInvitationResponse(string UserID)
        {
            bool result = false;
            string URL = $"InvitationCode";
            var request = new RestRequest(URL, Method.GET);
            request.AddQueryParameter("userId", UserID);
            request.AddHeader("Authorization", $"Bearer {_AuthManagement.GetUserAccessTokenInCookie()}");
            IRestResponse restResponse = await ServerClient.ExecuteAsync(request);
            if (restResponse.StatusCode == HttpStatusCode.NotFound)
            {
                result=true;
            }

            return result;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task<string> CreateQrCode(string Code)
        {
            string Base64String = "";
            QRCodeGenerator generator = new QRCodeGenerator();
            string host = _httpContextAccessor.HttpContext.Request.Host.Value;
            string URL = $"https://{host}/ForwardUrl/{Code}";
            QRCodeData codeData = generator.CreateQrCode(URL, QRCodeGenerator.ECCLevel.M, true);
            QRCoder.BitmapByteQRCode qrcode = new BitmapByteQRCode(codeData);
            byte[] bitmap = qrcode.GetGraphic(10);
            Base64String = Convert.ToBase64String(bitmap);
            return Base64String;
        }

        #endregion




    }

}
