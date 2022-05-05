using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Entity;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Paging;
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




        public List<string> RareList = new List<string>() { "N", "R", "SR", "SSR", "UR", "UUR" };

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


            

            datas = new List<NFTData>();


            Random myObject = new Random();


            for (int i = 0; i < nFTRiders.Count; i++)
            {
                int value = myObject.Next(1, 1000);
                int RareInt = value % RareList.Count();
                int ClassInt = value % ClassList.Count();
                int ProfessionInt = value % RareList.Count();
                int CountryInt = value % RareList.Count();

                NFTData data = new NFTData();
                data.Number = value.ToString();
                data.Name = nFTRiders[i].name;
                data.Price = myObject.Next(value, value * 10);
                data.USD = myObject.Next(value, value * 10) * 30;
                data.ImgPath = string.Format(@"https://storage.googleapis.com/pps-nft/ppsr/{0}.png", nFTRiders[i].serialNumber);
                data.Rare = RareList[RareInt].ToString();
                data.Class = ClassList[ClassInt].ToString();
                data.Profession = ProfessionList[ProfessionInt].ToString();
                data.Country = CountryList[CountryInt].ToString();
                data.EndTime = DateTime.Now.AddDays(value);
                data.CalDays = Math.Truncate((DateTime.Now.AddDays(value) - DateTime.Now).TotalDays) + " d "
                               + Math.Truncate(((DateTime.Now.AddDays(value) - DateTime.Now).TotalHours) - Math.Truncate((DateTime.Now.AddDays(value) - DateTime.Now).TotalDays) * 24) + " H ";

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
                data.Price = myObject.Next(value, value * 10);
                data.USD = myObject.Next(value, value * 10) * 30;
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
        /// 
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        private async Task<List<NFTRiderUnits>> GetNFTRiderUnits()
        {
            var LoginRestRequest = new RestRequest($"NFT/Units");
            LoginRestRequest.AddHeader("Authorization", Authenticate());

            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(LoginRestRequest);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
               // List<NFTRiderUnits> nFTRiders = new List<NFTRiderUnits>();

                return  JsonSerializer.Deserialize<List<NFTRiderUnits>>(restResponse.Content) ??  new List<NFTRiderUnits>(); 
                
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
    }
}
