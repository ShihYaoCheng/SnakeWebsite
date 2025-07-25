using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Contracts;
using SnakeAsianLeague.Data.Entity;
using SnakeAsianLeague.Data.Entity.BlockChain;
using SnakeAsianLeague.Data.Entity.Config;
using System.Net;
using System.Text.Json;

namespace SnakeAsianLeague.Data.Services.Products
{
    public class ProductsService
    {


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



        private readonly static KeyValuePair<string, string> RequestKey = new KeyValuePair<string, string>("Backend-Auth-Handler", "gmregk343grgeggw[fk55234w46wfwef46gpwekf[43-i@@!#!@#@");
        private IConfiguration _config;
        private ExternalServers externalServersConfig;
        private readonly RestClient ServerClient;
        private readonly RestClient BlockChainServerClient;
        private IAuthManagement _AuthManagement;

        public ProductsService(IConfiguration config, IOptions<ExternalServers> myConfiguration, HttpClient httpClient, IAuthManagement authManagement)
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
        }


        RiderIntroduce Rider = new RiderIntroduce();

        public List<OptionKeyValue> RarityList = new List<OptionKeyValue>() { };
        public List<OptionKeyValue> ElementsList = new List<OptionKeyValue>() { };
        public List<OptionKeyValue> ClassList = new List<OptionKeyValue>() { };
        public List<OptionKeyValue> CountryList = new List<OptionKeyValue>() { };

        /// <summary>
        /// 依照合約地址 取得opewnsea NFT路經
        /// </summary>
        /// <param name="TokenID"></param>
        /// <returns></returns>
        public async Task<string> Get_OpenSeaURL(string TokenID , string PPSRContractAddress,string OpenSeaLink)
        {
            //string LinkURL = _config.GetValue<string>("OpenSeaLink");
            TokenID = TokenID.Replace("%", "").Trim();
            string LinkURL = string.Format(OpenSeaLink , PPSRContractAddress , TokenID);
            //return string.Format("https://testnets.opensea.io/assets/mumbai/"+ PPSRContractAddress + "/"+ TokenID);
            //return string.Format("https://opensea.io/assets/matic/" + PPSRContractAddress + "/" + TokenID);
            return LinkURL;
        }

        /// <summary>
        /// 取得目前NFT資料
        /// </summary>
        /// <returns></returns>
        public async Task<RiderIntroduce> Get_RiderIntroduce()
        {
            return Rider;
        }



        /// <summary>
        /// 取得擁有者錢包
        /// </summary>
        /// <param name="SerialNumber"></param>
        /// <returns></returns>
        public async Task<string> GetNFT_Unit_Owned(string tokenId)
        {
            string walletAddress = "";
            NFTRiderUnit result = new NFTRiderUnit();
            RestRequest request = new RestRequest($"NFT/Unit?tokenId={tokenId}");
            request.AddHeader("Authorization", $"Bearer {_AuthManagement.GetAdminAccessTokenInCookie()}");
            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(request);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                result = JsonSerializer.Deserialize<NFTRiderUnit>(restResponse.Content) ?? new NFTRiderUnit();
                if (result.castings != null)
                {
                    walletAddress = result.castings.owner;
                }
            }
            return walletAddress;
        }

        /// <summary>
        /// 取得騎士角色詳細By編號
        /// </summary>
        /// <param name="SerialNumber"></param>
        /// <returns></returns>
        public async Task<RiderIntroduce> GetNFT_Unit_SerialNumber(string TokenID , string googleapis)
        {

            string asset_contract_address = _config.GetValue<string>("asset_contract_address");
            string ImgPath = googleapis;
            try
            {
                NFTRiderUnit result = new NFTRiderUnit();
                RestRequest request = new RestRequest($"NFT/Unit?tokenId={TokenID}");
                request.AddHeader("Authorization", $"Bearer {_AuthManagement.GetAdminAccessTokenInCookie()}");

                IRestResponse restResponse = await ServerClient.ExecuteGetAsync(request);

                GetCharacterMetaData(TokenID);


                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = JsonSerializer.Deserialize<NFTRiderUnit>(restResponse.Content) ?? new NFTRiderUnit();



                    if (result.castings != null)
                    {
                        /*Owned*/
                        Rider.TokenID = TokenID;
                        Rider.Owned = result.castings.owner;
                        Rider.walletAddress = asset_contract_address;
                        if (Rider.Owned.Length > 20)
                        {
                            Rider.Owned = string.Format("{0}...{1}", Rider.Owned.Substring(0, 5), Rider.Owned.Substring(Rider.Owned.Length - 4, 4));
                            
                        }

                        /*Income*/
                        Rider.Income = new NowRentAndTotalRevenue();
                        Rider.Income = await Get_NowRentAndTotalRevenue("#" +TokenID);
                        Rider.isAvailableInGame = result.castings.isAvailableInGame;
                        Rider.receiveCurrency = result.castings.receiveCurrency;
                    }
                    else
                    {
                        /*Owned*/
                        //Rider.Owned = asset_contract_address;

                        Rider.walletAddress = asset_contract_address;
                        Rider.Owned = string.Format("{0}...{1}", asset_contract_address.Substring(0, 5), asset_contract_address.Substring(asset_contract_address.Length - 4, 4));
                        /*Income*/
                        Rider.Income = new NowRentAndTotalRevenue();
                        Rider.isAvailableInGame = false;
                    }

                    /*ImgPath*/
                    Rider.Name = result.serialNumber;
                    Rider.ImgPath = string.Format(ImgPath,"ppsr", result.serialNumber);
                    /*Attrbutes*/
                    Rider.Attrbutes = new Attrbutes();
                    List<string> RarityElements = result.serialNumber.Split('_').ToList();  //ex : NFT_Unit3_2c_1
                    if (RarityElements[2] != null)
                    {
                        Rider.Attrbutes.Rarity = RarityList.Where(m => m.Key == RarityElements[2].Substring(0, 1)).First().Value;
                        Rider.Attrbutes.Element = ElementsList.Where(m => m.Key == RarityElements[2].Substring(1, 1)).First().Value;
                        Rider.Attrbutes.ElementImgPath = string.Format("/images/Products/ElementsIcon-{0}.webp", Rider.Attrbutes.Element);
                    }

                    if (result.knight != null)
                    {
                        Rider.Attrbutes.CharacterClass = ClassList.Where(m => m.Key == result.knight.occupationID.ToString()).First().Value;
                    }
                    Rider.Attrbutes.BodyType = result.size;
                    /*Stats*/

                    List<OptionNameValue> BattleData = await Get_BattleData();
                    if (Rider.isAvailableInGame)
                    {
                        Rider.Stats = new Stats();
                        Rider.Stats.HP = Cal_HP(result);
                        Rider.Stats.Attack = Cal_Attack(result);
                        Rider.Stats.Dexterity = Cal_Dexterity(result);
                        Rider.Stats.MovingSpeed = Cal_MovingSpeed(result);
                        //Rider.Stats.AttackingSpeed = Cal_AttackingSpeed(result, BattleData);
                        Rider.Stats.Stamina = Cal_Stamina(result);
                        //Rider.Stats.CriticalChance = Cal_CriticalChance(result, BattleData);
                        Rider.Stats.ElementEffect = Cal_ElementEffect(result);
                    }
                    
                    /*Avatars*/
                    Rider.Avatars = new Avatars();
                    Rider.Avatars.Ridder = result.knight == null ? "" : result.knight.serialNumber;
                    Rider.Avatars.Pet = result.pet == null ? "" : result.pet.serialNumber;
                    Rider.Avatars.Weapon = result.weapon == null ? "" : result.weapon.serialNumber;
                    Rider.Avatars.Snake = result.snake == null ? "" : result.snake.serialNumber;
                    /*skills*/
                    Rider.Skills = new List<Skill>();
                    if (result.knight != null)
                    {
                        if (result.knight.skill != "")
                        {
                            Skill skill = new Skill();
                            skill.SkillsName = string.Format("{0}.Name", result.knight.skill);
                            skill.SkillsIcon = string.Format(ImgPath, "skill", result.knight.skill);
                            skill.Description = string.Format("{0}.Description", result.knight.skill);
                            Rider.Skills.Add(skill);
                        }
                    }
                    if (result.snake != null)
                    {
                        if (result.snake.skill != "")
                        {
                            Skill skill = new Skill();
                            skill.SkillsName = string.Format("{0}.Name", result.snake.skill);
                            skill.SkillsIcon = string.Format(ImgPath, "skill", result.snake.skill);
                            skill.Description = string.Format("{0}.Description", result.snake.skill);
                            Rider.Skills.Add(skill);
                        }
                    }
                    if (result.weapon != null)
                    {
                        if (result.weapon.skill != "")
                        {
                            Skill skill = new Skill();
                            skill.SkillsName = string.Format("{0}.Name", result.weapon.skill);
                            skill.SkillsIcon = string.Format(ImgPath, "skill", result.weapon.skill);
                            skill.Description = string.Format("{0}.Description", result.weapon.skill);
                            Rider.Skills.Add(skill);
                        }
                    }
                    if (result.pet != null)
                    {
                        if (result.pet.skill != "")
                        {
                            Skill skill = new Skill();
                            skill.SkillsName = string.Format("{0}.Name", result.pet.skill);
                            skill.SkillsIcon = string.Format(ImgPath, "skill", result.pet.skill);
                            skill.Description = string.Format("{0}.Description", result.pet.skill);
                            Rider.Skills.Add(skill);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
            }
            return Rider;
        }



        /// <summary>
        /// 抓取收益
        /// url #特殊符號 注意轉換問題以處理
        /// </summary>
        /// <param name="PPSR"> ex: #1 </param>
        /// <returns></returns>
        public async Task<NowRentAndTotalRevenue> Get_NowRentAndTotalRevenue(string PPSR)
        {
            NowRentAndTotalRevenue result = new NowRentAndTotalRevenue();
            try
            {
                PPSR = PPSR.Replace("#", "%23");
                RestRequest request = new RestRequest($"NFT/NowRentAndTotalRevenue?PPSR={PPSR}");
                request.AddHeader("Authorization", $"Bearer {_AuthManagement.GetAdminAccessTokenInCookie()}");

                IRestResponse restResponse = await ServerClient.ExecuteGetAsync(request);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = JsonSerializer.Deserialize<NowRentAndTotalRevenue>(restResponse.Content) ?? new NowRentAndTotalRevenue();
                }
            }
            catch (Exception ex)
            {
                result = new NowRentAndTotalRevenue();
            }
            return result;
        }


        /// <summary>
        /// 取得戰場特殊參數
        /// </summary>
        /// <returns></returns>
        public async Task<List<OptionNameValue>> Get_BattleData()
        {
            List<OptionNameValue> result = new List<OptionNameValue>();
            try
            {
                RestRequest request = new RestRequest($"User/Fight/BattleData");
                request.AddHeader("Authorization", $"Bearer {_AuthManagement.GetAdminAccessTokenInCookie()}");

                IRestResponse restResponse = await ServerClient.ExecuteGetAsync(request);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = JsonSerializer.Deserialize<List<OptionNameValue>>(restResponse.Content) ?? new List<OptionNameValue>();
                }
            }
            catch (Exception)
            {
                result = new List<OptionNameValue>();
            }
            return result;
        }






        /// <summary>
        /// 改變租金
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="ppsrID"></param>
        /// <param name="Price"></param>
        public async Task<bool> ChangeRent(string Address, string ppsr, decimal Price ,int currencyType)
        {
            bool result = false;
            try
            {
                NFTUnitPriceDTO dto = new NFTUnitPriceDTO();
                dto.wallet = Address;
                dto.ppsr = "#"+ppsr;
                dto.price = Price;
                dto.currencyType = currencyType;

                string URL = "/NFT/ChangeRent";
                RestRequest request = new RestRequest(URL, Method.POST);
                request.AddHeader("Authorization", $"Bearer {_AuthManagement.GetUserAccessTokenInCookie()}");
                request.AddHeader(RequestKey.Key, RequestKey.Value);

                JsonParameter JP = new JsonParameter("", dto);
                request.AddParameter(JP);

                var response = await ServerClient.ExecuteAsync(request);
                if (await ChangeRentCurrencyType(Address, ppsr, currencyType))
                {
                    result = response.StatusCode == HttpStatusCode.OK;
                }

            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
            }
            return result;
        }





        /// <summary>
        /// 修改租金  類別 1:星鑽 22:gSRC
        /// </summary>
        /// <param name="Address"></param>
        /// <param name="ppsr"></param>
        /// <param name="Price"></param>
        /// <returns></returns>
        public async Task<bool> ChangeRentCurrencyType(string Address, string ppsr, int currencyType)
        {
            bool result = false;
            try
            {
                NFTUnitCurrencyTypeDTO dto = new NFTUnitCurrencyTypeDTO();
                dto.wallet = Address;
                dto.ppsr = "#" + ppsr;
                dto.currencyType = currencyType;

                string URL = "NFT/ChangeRentCurrencyType";
                RestRequest request = new RestRequest(URL, Method.POST);
                request.AddHeader("Authorization", $"Bearer {_AuthManagement.GetUserAccessTokenInCookie()}");
                request.AddHeader(RequestKey.Key, RequestKey.Value);

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
        /// 取得租金紀錄
        /// </summary>
        /// <param name="TokenID"></param>
        /// <returns></returns>
        public async Task<UnitRecordLog> GetNFTUnitRecord(string TokenID)
        {
            UnitRecordLog result = new UnitRecordLog();
            try
            {
                string ppsr = "#" + TokenID;
                ppsr = ppsr.Replace("#", "%23");
                RestRequest request = new RestRequest($"NFT/UnitRecord?ppsr={ppsr}");
                request.AddHeader("Authorization", $"Bearer {_AuthManagement.GetAdminAccessTokenInCookie()}");

                IRestResponse restResponse = await ServerClient.ExecuteGetAsync(request);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = JsonSerializer.Deserialize<UnitRecordLog>(restResponse.Content) ?? new UnitRecordLog();
                    foreach (var item in result.records)
                    {
                        if (item.currencyType == 1)
                        {
                            item.currencyTypeName = "Gem";
                        } 
                        else if (item.currencyType == 22)
                        {
                            item.currencyTypeName = "gSRC";
                        }

                        item.rent = Math.Round(item.rent, 3, MidpointRounding.AwayFromZero);
                        item.dateFormat = item.date.ToString("yyyy-MM-dd");

                        if (item.receivedDate != null)
                        {
                            item.receivedDateFormat = item.receivedDate?.ToString("yyyy-MM-dd");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = new UnitRecordLog();
            }
            return result;
        }




        /// <summary>
        /// 總生命 HP = Unit_Knight(G) + Unit_Snake(G) + Unit_Pet(F)
        /// </summary>
        /// <returns></returns>
        private double Cal_HP(NFTRiderUnit Data)
        {
            double Knight = Data.knight == null ? 0 : Data.knight.hp;
            double Snake = Data.snake == null ? 0 : Data.snake.hp;
            double Pet = Data.pet == null ? 0 : Data.pet.hp;
            double result = Knight + Snake + Pet;
            return result;
        }


        /// <summary>
        /// 總攻擊力 Attack  = Unit_Knight(H) + Unit_Snake(H) + Unit_Pet(G)
        /// </summary>
        /// <returns></returns>
        private double Cal_Attack(NFTRiderUnit Data)
        {
            double Knight = Data.knight == null ? 0 : Data.knight.atk;
            double Snake = Data.snake == null ? 0 : Data.snake.atk;
            double Pet = Data.pet == null ? 0 : Data.pet.atk;
            double result = Knight + Snake + Pet;
            return result;
        }

        /// <summary>
        /// 總靈活 Dexterity  = Unit_Snake(I) + Unit_Pet(I)
        /// </summary>
        /// <returns></returns>
        private double Cal_Dexterity(NFTRiderUnit Data)
        {
            double Snake = Data.snake == null ? 0 : Data.snake.agl;
            double Pet = Data.pet == null ? 0 : Data.pet.agl;
            double result = Snake + Pet;
            return result;
        }

        /// <summary>
        /// 總移動速度 Moving Speed  = Unit_Snake(K) + Unit_Pet(J)
        /// </summary>
        /// <returns></returns>
        private double Cal_MovingSpeed(NFTRiderUnit Data)
        {
            double Snake = Data.snake == null ? 0 : Data.snake.ms;
            double Pet = Data.pet == null ? 0 : Data.pet.ms;
            double result =  Snake + Pet;
            return result;
        }

        /// <summary>
        /// 總攻擊速度 Attacking Speed  = Unit_Weapon(I) + Unit_Pet(I)
        /// Attacking Speed(以百分比顯示)= (BattleData(C3)/(BattleData(C3)-(Unit_Weapon(I)+ Unit_Pet(I))*0.01)
        /// </summary>
        /// <returns></returns>
        private string Cal_AttackingSpeed(NFTRiderUnit Data , List<OptionNameValue> BattleData)
        {
            double Wapon = Data.weapon == null ? 0 : Data.weapon.@as;
            double Pet = Data.pet == null ? 0 : Data.pet.@as;
            double BattleDataAttackSpeed = BattleData.Where(m => m.name == "AttackSpeed").First().value;
            var molecular = (Wapon + Pet) * 0.01;
            var denominator = BattleDataAttackSpeed - (Wapon + Pet) * 0.01;

            string result = Convert.ToDouble(  (BattleDataAttackSpeed / denominator * 100).ToString() ).ToString("0.00") + "%";    //Wapon + Pet;
            return result;
        }

        /// <summary>
        /// 總體力 Stamina = Unit_Snake(J) + Unit_Pet(K)
        /// </summary>
        /// <returns></returns>
        private double Cal_Stamina(NFTRiderUnit Data)
        {
            double Snake = Data.snake == null ? 0 : Data.snake.con;
            double Pet = Data.pet == null ? 0 : Data.pet.con;
            double result = Snake + Pet;
            return result;
        }

        /// <summary>
        /// 總爆擊率 Critical Chance  = BattleData(C2) + Unit_Pet(L) (*%之後以百分比顯示)
        /// </summary>
        /// <returns></returns>
        private string Cal_CriticalChance(NFTRiderUnit Data, List<OptionNameValue> BattleData)
        {
            double Pet = Data.pet == null ? 0 : Data.pet.crit;

            double BattleDataCritical = BattleData.Where(m => m.name == "Critical").First().value;
            string result = string.Format(" {0} %", BattleDataCritical + Pet);
            return result;
        }

        /// <summary>
        /// 總屬性特效    Element Effect  = Unit_Weapon(K)+Unit_Pet(N) (*%之後以百分比顯示)
        /// </summary>
        /// <returns></returns>
        private string Cal_ElementEffect(NFTRiderUnit Data)
        {
            double Wapon = Data.weapon == null ? 0 : Data.weapon.attrEffectValue;
            double Pet = Data.pet == null ? 0 : Data.pet.attrEffectValue;
            string result = string.Format(" {0} %", Wapon + Pet);
            return result;
        }





        /// <summary>
        /// 取得opensea metadata 資料  by tokenid
        /// markplace名字要相互對應
        /// </summary>
        public async Task<PPSRMetadata_General> GetCharacterMetaData(string TokenID)
        {
            string Url = $"BC_CharacterContract/Metadata/{TokenID}";
            var request = new RestRequest(Url, Method.GET);
            IRestResponse restResponse = await BlockChainServerClient.ExecuteAsync(request);
            //request.AddQueryParameter("tokenId ", TokenID);


            PPSRMetadata_General result = new PPSRMetadata_General();
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                result = JsonSerializer.Deserialize<PPSRMetadata_General>(restResponse.Content) ?? new PPSRMetadata_General();

            }
            return result;
        }
    }
}
