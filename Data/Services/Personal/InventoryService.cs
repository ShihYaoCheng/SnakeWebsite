using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Entity;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Paging;

namespace SnakeAsianLeague.Data.Services.Personal
{
    public class InventoryService
    {
        private readonly static KeyValuePair<string, string> RequestKey = new KeyValuePair<string, string>("Backend-Auth-Handler", "gmregk343grgeggw[fk55234w46wfwef46gpwekf[43-i@@!#!@#@");
        private IConfiguration _config;
        private ExternalServers externalServersConfig;
        private readonly RestClient ServerClient;

        List<NFTData> NFTDataList;


        public List<OptionKeyValue> RarityList = new List<OptionKeyValue>() { };
        public List<OptionKeyValue> ElementsList = new List<OptionKeyValue>() { };
        public List<OptionKeyValue> ClassList = new List<OptionKeyValue>() { };
        public List<OptionKeyValue> CountryList = new List<OptionKeyValue>() { };



        public InventoryService(IConfiguration config , IOptions<ExternalServers> myConfiguration, HttpClient httpClient)
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
        public async Task<PagedList<NFTData>> GetRiderNFTDataPageList(int PageNumber, int PageSize)
        {
            NFTDataList = new List<NFTData>();


            Random myObject = new Random();



            for (int i = 0; i < 15; i++)
            {

                int value = myObject.Next(1, 1000);
                //int RareInt = value % RareList.Count();
                //int ClassInt = value % ClassList.Count();
                //int ProfessionInt = value % RareList.Count();
                //int CountryInt = value % RareList.Count();

                NFTData data = new NFTData();
                data.Number = value.ToString();
                data.Name = value.ToString() + "-";//+ ProfessionList[ProfessionInt].ToString();
                data.Price = myObject.Next(value, value * 10).ToString();
                data.USD = (myObject.Next(value, value * 10) * 30).ToString();
                data.ImgPath = "/images/MarketPlace/NFTproduct.png";
                //data.Rare = RareList[RareInt].ToString();
                //data.Class = ClassList[ClassInt].ToString();
                //data.Class = ClassList[ProfessionInt].ToString();
                //data.Country = CountryList[CountryInt].ToString();
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



                NFTDataList.Add(data);
            }

            NFTDataList = NFTDataList.OrderBy(m => m.IsOpen == false).ThenBy(m => m.Number).ToList();
            return PagedList<NFTData>.ToPagedList(NFTDataList, PageNumber, PageSize);

        }


        public async Task<PagedList<NFTData>> GetRiderNFTDataListOrderby(string OrderByString, int PageNumber, int PageSize)
        {
            if (OrderByString == "Highest Earned" || OrderByString == "Sort")
            {
                NFTDataList = NFTDataList.OrderBy(m => m.IsOpen == false).ThenByDescending(m => m.Number).ToList();

            }
            if (OrderByString == "Lowest Earned")
            {
                NFTDataList = NFTDataList.OrderBy(m => m.IsOpen == false).ThenBy(m => m.Number).ToList();
            }
            if (OrderByString == "Highest Price")
            {
                NFTDataList = NFTDataList.OrderBy(m => m.IsOpen == false).ThenByDescending(m => m.Price).ToList();
            }
            if (OrderByString == "Lowest Price")
            {
                NFTDataList = NFTDataList.OrderBy(m => m.IsOpen == false).ThenBy(m => m.Price).ToList();
            }
            if (OrderByString == "Newest")
            {
                NFTDataList = NFTDataList.OrderBy(m => m.IsOpen == false).ThenByDescending(m => m.EndTime).ToList();
            }
            if (OrderByString == "Oldest")
            {
                NFTDataList = NFTDataList.OrderBy(m => m.IsOpen == false).ThenBy(m => m.EndTime).ToList();
            }
            return PagedList<NFTData>.ToPagedList(NFTDataList, PageNumber, PageSize);
        }
    }
}
