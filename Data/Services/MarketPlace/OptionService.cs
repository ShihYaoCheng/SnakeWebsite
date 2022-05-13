using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Entity;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Paging;
using System;
using System.Globalization;
using System.Net;
using System.Text.Json;

namespace SnakeAsianLeague.Data.Services.MarketPlace
{
    public class OptionService
    {
        private ExternalServers externalServersConfig;
        private readonly RestClient ServerClient;

        public OptionService(IOptions<ExternalServers> myConfiguration,HttpClient httpClient)
        {
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.UserServer);
        }




        //public List<string> RareList = new List<string>() { "N", "R", "SR", "SSR", "UR", "UUR" };
        public List<string> RareList = new List<string>() { "advanced", "rare", "epic", "legend", "abyss", "mythic" };

        public List<string> ClassList = new List<string>() { "Land", "Water", "Wind", "Fire" };

        public List<string> ProfessionList = new List<string>() { "Archer", "Necromancer", "Cleric", "Bard", "Magician", "Assassin", "Gunner", "Gladiator", "Dragoon" };

        public List<string> CountryList = new List<string>() { "Archer", "Necromancer", "Cleric", "Bard", "Magician", "Assassin" };

        List<NFTData> datas;
        public async Task<List<string>> GetRareList()
        {
            return RareList;
        }

        public async Task<List<string>> GetClassList()
        {
            return ClassList;
        }

        public async Task<List<string>> GetProfessionList()
        {
            return ProfessionList;
        }

        public async Task<List<string>> GetCountryList()
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


            List<NFTRiderUnits> nFTRiders = await GetNFTRiderUnits();

            OpenseaAssetsData rd = await GetOpenseaNFTRider();


            datas = new List<NFTData>();


            Random myObject = new Random();


            for (int i = 0; i < nFTRiders.Count; i++)
            {
                int value = myObject.Next(1, 1000);
                int RareInt = value % RareList.Count();
                int ClassInt = value % ClassList.Count();
                int ProfessionInt = value % RareList.Count();
                int CountryInt = value % RareList.Count();

                assets assets = new assets();

                if (rd.assets.Count > 0)
                {
                    assets = rd.assets.Where(m => m.token_id == nFTRiders[i].castings[0].tokenId).FirstOrDefault() ?? new assets(); 
                }

             

                NFTData data = new NFTData();
                data.Number = nFTRiders[i].castings[0].tokenId;
                data.Name = assets.name;
                if (assets.last_sale != null)
                {


                    var aaa = string.Format("{0,18:000000000000000000}", assets.last_sale.total_price);
                    var bbb = Math.Pow(10, assets.last_sale.payment_token.decimals);
                    var ccc = double.Parse(aaa.ToString()) / double.Parse(bbb.ToString());

                    Decimal usd_price = 0;
                    Decimal.TryParse(assets.last_sale.payment_token.usd_price ?? "0", out usd_price);
                    data.Price = ccc.ToString();    //myObject.Next(value, value * 10);
                    data.USD = (Decimal.Parse(data.Price) * usd_price).ToString("#,##0.###,", CultureInfo.InvariantCulture);   //myObject.Next(value, value * 10) * 30;
                    data.IsOpen = true;
                }
                else
                {
                    
                    data.IsOpen = false;
                }
                data.ImgPath = string.Format(@"https://storage.googleapis.com/pps-nft/ppsr/{0}.png", nFTRiders[i].serialNumber);
                //data.ImgPath = assets.image_url;


                data.LinkURL = string.Format("https://testnets.opensea.io/assets/0x2de6d9904ac58d6e50c328a0177c038b57f9e2d3/{0}", nFTRiders[i].castings[0].tokenId);
                data.Rare = RareList[RareInt].ToString();
                data.Class = ClassList[ClassInt].ToString();
                data.Profession = ProfessionList[ProfessionInt].ToString();
                data.Country = CountryList[CountryInt].ToString();
                data.EndTime = DateTime.Now.AddDays(value);
                data.CalDays = Math.Truncate((DateTime.Now.AddDays(value) - DateTime.Now).TotalDays) + " d "
                               + Math.Truncate(((DateTime.Now.AddDays(value) - DateTime.Now).TotalHours) - Math.Truncate((DateTime.Now.AddDays(value) - DateTime.Now).TotalDays) * 24) + " H ";



                //data.IsOpen = true;
                //if (value % 2 == 0)
                //{
                //    data.IsOpen = true;
                //}
                //else
                //{
                //    data.IsOpen = false;
                //}



                datas.Add(data);
            }





            //for (int i = 0; i < 30; i++)
            //{

            //    int value = myObject.Next(1, 1000);
            //    int RareInt = value % RareList.Count();
            //    int ClassInt = value % ClassList.Count();
            //    int ProfessionInt = value % RareList.Count();
            //    int CountryInt = value % RareList.Count();

            //    NFTData data = new NFTData();
            //    data.Number = value.ToString();
            //    data.Name = value.ToString() + "-" + ProfessionList[ProfessionInt].ToString();
            //    data.Price = myObject.Next(value, value * 10);
            //    data.USD = myObject.Next(value, value * 10) * 30;
            //    data.ImgPath = "/images/MarketPlace/ERNC.png";
            //    data.Rare = RareList[RareInt].ToString();
            //    data.Class = ClassList[ClassInt].ToString();
            //    data.Profession = ProfessionList[ProfessionInt].ToString();
            //    data.Country = CountryList[CountryInt].ToString();
            //    data.EndTime = DateTime.Now.AddDays(value);
            //    data.CalDays = Math.Truncate((DateTime.Now.AddDays(value) - DateTime.Now).TotalDays) + " d "
            //                   + Math.Truncate(((DateTime.Now.AddDays(value) - DateTime.Now).TotalHours) - Math.Truncate((DateTime.Now.AddDays(value) - DateTime.Now).TotalDays) * 24) + " H ";

            //    if (value % 2 == 0)
            //    {
            //        data.IsOpen = true;
            //    }
            //    else
            //    {
            //        data.IsOpen = false;
            //    }



            //    datas.Add(data);
            //}
            datas = datas.OrderBy(m => m.IsOpen == false).ThenBy(m => m.Number).ToList();
            return PagedList<NFTData>.ToPagedList(datas, PageNumber, PageSize);
        }

        public async Task<PagedList<NFTData>> GetNFTDataPageListbyPage(int PageNumber, int PageSize)
        {

            return PagedList<NFTData>.ToPagedList(datas, PageNumber, PageSize);
        }
        


        public async Task<List<NFTData>> GetNFTDataList()
        {
            datas = new List<NFTData>();


            Random myObject = new Random();



            for (int i = 0; i < 30; i++)
            {

                int value = myObject.Next(1, 1000);
                int RareInt = value % RareList.Count();
                int ClassInt = value % ClassList.Count();
                int ProfessionInt = value % RareList.Count();
                int CountryInt = value % RareList.Count();

                NFTData data = new NFTData();
                data.Number = value.ToString();
                data.Name = value.ToString() + "-" + ProfessionList[ProfessionInt].ToString();
                data.Price = myObject.Next(value, value * 10).ToString();
                data.USD = (myObject.Next(value, value * 10) * 30).ToString();
                data.ImgPath = "/images/MarketPlace/ERNC.png";
                data.Rare = RareList[RareInt].ToString();
                data.Class = ClassList[ClassInt].ToString();
                data.Profession = ProfessionList[ProfessionInt].ToString();
                data.Country = CountryList[CountryInt].ToString();
                data.EndTime = DateTime.Now.AddDays(value);
                data.CalDays = Math.Truncate(( DateTime.Now.AddDays(value)  - DateTime.Now ).TotalDays)    +  " d " 
                               + Math.Truncate(((DateTime.Now.AddDays(value) - DateTime.Now).TotalHours) - Math.Truncate(( DateTime.Now.AddDays(value) - DateTime.Now).TotalDays) * 24)  + " H ";

                if (value % 2 == 0)
                {
                    data.IsOpen = true;
                }
                else
                {
                    data.IsOpen = false;
                }



                datas.Add(data);
            }

            datas = datas.OrderBy(m => m.IsOpen ==false).ThenBy( m => m.Number).ToList();
            return datas;
        }

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
        /// 取得 Rider 有被鍛造的 NFT 
        /// </summary>
        /// mintCount 鍛造次數
        /// <returns></returns>
        private async Task<List<NFTRiderUnits>> GetNFTRiderUnits()
        {
            var LoginRestRequest = new RestRequest($"NFT/Units");
            LoginRestRequest.AddHeader("Authorization", Authenticate());

            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(LoginRestRequest);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                List<NFTRiderUnits> nFTRiderUnits = JsonSerializer.Deserialize<List<NFTRiderUnits>>(restResponse.Content) ?? new List<NFTRiderUnits>();
                return nFTRiderUnits.Where(m => m.mintCount > 0).ToList();
            }
            return  new List<NFTRiderUnits>();
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



        public async Task<OpenseaAssetsData> GetOpenseaNFTRider()
        {
            //var client = new RestClient("https://testnets-api.opensea.io/api/v1/assets?asset_contract_address=0x2DE6D9904AC58D6e50c328a0177c038b57F9E2D3&order_direction=desc&offset=0&limit=20");
            //var request = new RestRequest(Method.GET);
            //IRestResponse response = client.Execute(request);
            var client = new RestClient("https://testnets-api.opensea.io/api/v1/assets?asset_contract_address=0x2DE6D9904AC58D6e50c328a0177c038b57F9E2D3&order_direction=desc&offset=0&limit=20");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var rd = JsonSerializer.Deserialize<OpenseaAssetsData>(response.Content) ?? new OpenseaAssetsData();

                return rd;
            }
            return new OpenseaAssetsData();
        }
    }
}
