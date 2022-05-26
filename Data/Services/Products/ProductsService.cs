using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Entity;
using SnakeAsianLeague.Data.Entity.Config;
using System.Net;
using System.Text.Json;

namespace SnakeAsianLeague.Data.Services.Products
{
    public class ProductsService
    {
        private readonly static KeyValuePair<string, string> RequestKey = new KeyValuePair<string, string>("Backend-Auth-Handler", "gmregk343grgeggw[fk55234w46wfwef46gpwekf[43-i@@!#!@#@");
        private IConfiguration _config;
        private ExternalServers externalServersConfig;
        private readonly RestClient ServerClient;

        public ProductsService(IConfiguration config, IOptions<ExternalServers> myConfiguration, HttpClient httpClient)
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


        RiderIntroduce Rider = new RiderIntroduce();

        public List<OptionKeyValue> RarityList = new List<OptionKeyValue>() { };
        public List<OptionKeyValue> ElementsList = new List<OptionKeyValue>() { };
        public List<OptionKeyValue> ClassList = new List<OptionKeyValue>() { };
        public List<OptionKeyValue> CountryList = new List<OptionKeyValue>() { };


        /* 
        * src 抓取 資料庫 腳色
        * 騎士清單 http://104.199.196.10/api/user/NFT/Units?test=0
        * => 腳色明細 http://104.199.196.10/api/user/NFT/Unit?SerialNumber=NFT_Unit5_2b_1
        * 個人腳色 http://104.199.196.10/api/user/Unit/Checklist?UserID=10143
        * => selfUnits => 自己擁有的腳色(NFT+初始給的 
        * => 腳色明細 http://104.199.196.10/api/user/NFT/Unit?SerialNumber=NFT_Unit5_2b_1
        * 缺少腳色故事 技能說明 圖示 #endregion inventory
        * 公開數值
        * 配件部位 : 騎士 /  寵物 / 武器 / 蛇體 (並且不一定每個NFT皆有會有所有部分)，
        * 腳色對照表 取得正確名稱 
        * API https://docs.google.com/spreadsheets/d/1RUi-p6Ji5HwqoTGRzrdgWoUbjUymxeu9mG9wZr14rO8/edit#gid=261997991
        * => 主動技能庫
        * => 被動技能庫
        * 
        */




        public class testa {
            public List<leaseUnits> leaseUnits { get; set; }

            public List<leaseUnits> selfUnits { get; set; }

            public string fight { get; set; }
        }

        public class leaseUnits
        {
            public string serialNumber { get; set; }

            public string ppsr { get; set; }

            public int Level { get; set; }

            public int exp { get; set; }

            public double rent { get; set; }

            public string name { get; set; }

            public string winningPercentage { get; set; }

            public string appearancesCount { get; set; }

            public string isLove { get; set; }

            public string isNFT { get; set; }
        }


        public class SerialNumber
        {
            public string serialNumber { get; set; }

            public string name { get; set; }

            public double size { get; set; }

            public knight knight { get; set; }

            public knight snake { get; set; }

            public knight weapon { get; set; }

            public knight pet { get; set; }

        }


        public class knight {
            public string serialNumber { get; set; }
            public string name { get; set; }

            public int hp { get; set; }

            public int atk { get; set; }

            public int occupationID { get; set; }

            public string skill { get; set; }
        }


        public class snake
        {
            public string serialNumber { get; set; }
            public string name { get; set; }

            public int hp { get; set; }

            public int atk { get; set; }

            public int agl { get; set; }

            public int con { get; set; }

            public double ms { get; set; }

            public string skill { get; set; }
        }

        public class weapon
        {
            public string serialNumber { get; set; }
            public string name { get; set; }

            public double autoATKRange { get; set; }

            public double atkRange { get; set; }

            public double @as { get; set; }

            public string attrEffect { get; set; }

            public string attrEffectValue { get; set; }

            public string skill { get; set; }
        }

        public class Pet
        {
            public string serialNumber { get; set; }
            public string name { get; set; }
            //"hp": 0,
            //"atk": 0,
            //"agl": 0,
            //"as": 0,
            //"ms": 0,
            //"con": 0,
            //"crit": 0,
            public string attrEffect { get; set; }
            //"attrEffectValue": 0,
            public string skill { get; set; }
        }

        public class Knights
        {
            public int playerKnightID { get; set; }
            public int level { get; set; }

            public int skill1 { get; set; }

            public int skill2 { get; set; }

            public int autoAtk { get; set; }

            public int isOwned { get; set; }

            public int petKey { get; set; }

            public int skinList { get; set; }

            public int skinID { get; set; }

            public int weaponSkinList { get; set; }

            public int weaponSkinID { get; set; }

            public int knightID { get; set; }
        }



        /// <summary>
        /// 依照合約地址 取得opewnsea NFT路經
        /// </summary>
        /// <param name="TokenID"></param>
        /// <returns></returns>
        public async Task<string> Get_OpenSeaURL(string TokenID)
        {
            string LinkURL = _config.GetValue<string>("OpenSeaLink");
            string asset_contract_address = _config.GetValue<string>("asset_contract_address");

            return string.Format(LinkURL, asset_contract_address, TokenID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<RiderIntroduce> Get_RiderIntroduce()
        {

            return Rider;
        }







        /// <summary>
        /// 取得騎士角色詳細By編號
        /// </summary>
        /// <param name="SerialNumber"></param>
        /// <returns></returns>
        public async Task<RiderIntroduce> GetNFT_Unit_SerialNumber(string SerialNumber)
        {

            string ImgPath = _config.GetValue<string>("googleapis");
            try
            {
                SerialNumber result = new SerialNumber();
                RestRequest request = new RestRequest($"NFT/Unit?SerialNumber={SerialNumber}");
                request.AddHeader("Authorization", Authenticate());

                IRestResponse restResponse = await ServerClient.ExecuteGetAsync(request);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = JsonSerializer.Deserialize<SerialNumber>(restResponse.Content) ?? new SerialNumber();

                    /*ImgPath*/
                    Rider.ImgPath = string.Format(ImgPath, result.serialNumber);
                    /*Attrbutes*/
                    Rider.Attrbutes = new Attrbutes();
                    List<string> RarityElements = result.serialNumber.Split('_').ToList();  //ex : NFT_Unit3_2c_1
                    if (RarityElements[2] != null)
                    {
                        Rider.Attrbutes.Rarity = RarityList.Where(m => m.Key == RarityElements[2].Substring(0, 1)).First().Value;
                        Rider.Attrbutes.Element = ElementsList.Where(m => m.Key == RarityElements[2].Substring(1, 1)).First().Value;
                        Rider.Attrbutes.ElementImgPath = string.Format("/images/Products/Element-{0}.png", Rider.Attrbutes.Element);
                    }
                    Rider.Attrbutes.CharacterClass = ClassList.Where(m => m.Key == result.knight.occupationID.ToString()).First().Value;
                    Rider.Attrbutes.BodyType = result.size;
                    /*Stats*/
                    Rider.Stats = new Stats();
                    Rider.Stats.HP = result.knight.hp;
                    Rider.Stats.Attack = result.knight.atk;
                    /*Avatars*/
                    Rider.Avatars = new Avatars();
                    Rider.Avatars.Ridder = result.knight == null ? "" : result.knight.name;
                    Rider.Avatars.Pet = result.pet == null ? "" : result.pet.name;
                    Rider.Avatars.Weapon = result.weapon == null ? "" : result.weapon.name;
                    Rider.Avatars.Snake = result.snake == null ? "" : result.snake.name;
                    /*skills*/
                    Rider.Skills = new List<Skill>();
                    Skill skill = new Skill();
                    skill.SkillsNmae = result.knight == null ? "" : result.knight.name;
                    Rider.Skills.Add(skill);
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
            }
            return Rider;
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



        public string getresult ()
        { 
            string result = "";


            return result;
        }
    }
}
