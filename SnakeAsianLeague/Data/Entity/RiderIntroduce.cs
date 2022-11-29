namespace SnakeAsianLeague.Data.Entity
{
    public class RiderIntroduce
    {
        public RiderIntroduce()
        {

        }

        public string TokenID { get; set; }
        public string serialNumber { get; set; }
        public string Name { get; set; }
        public string Owned { get; set; }

        public string walletAddress { get; set; }

        public NowRentAndTotalRevenue Income { get; set; }

        public string ImgPath { get; set; }

        /// <summary>
        /// 是否遊戲端是否顯示
        /// </summary>
        public bool isAvailableInGame { get; set; }

        public Attrbutes Attrbutes { get; set; }

        public Stats Stats { get; set; }


        public Avatars Avatars { get; set; }

        public List<Skill> Skills { get; set; }


    }






    public class Attrbutes
    {
        /// <summary>
        /// 稀有度
        /// </summary>
        public string Rarity { get; set; }

        /// <summary>
        /// 屬性
        /// </summary>
        public string Element { get; set; }

        /// <summary>
        /// 屬性img 
        /// </summary>
        public string ElementImgPath { get; set; }

        /// <summary>
        /// 體型
        /// </summary>
        public double BodyType { get; set; }

        /// <summary>
        /// 描述 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 職業專精
        /// </summary>
        public string CharacterClass { get; set; }
    }

    public class Stats
    {
        public double HP { get; set; }

        public double Attack { get; set; }


        public double Dexterity { get; set; }


        public double MovingSpeed { get; set; }

        public string AttackingSpeed { get; set; }

        public double Stamina { get; set; }

        public string CriticalChance { get; set; }

        public string ElementEffect { get; set; }
    }

    public class Avatars
    {
        /// <summary>
        /// 
        /// </summary>
        public string Ridder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Pet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Weapon { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Snake { get; set; }
    }

    public class Skill
    {
        public string SkillsName { get; set; }

        public double CD { get; set; }

        public double Duration { get; set; }

        public string Description { get; set; }

        public string SkillsIcon { get; set; }


    }

    /// <summary>
    /// 收益
    /// </summary>
    public class NowRentAndTotalRevenue
    { 
        /// <summary>
        /// 現在租金
        /// </summary>
        public List<RentCurrencyType> nowRent { get; set; }
        /// <summary>
        /// 累計收益
        /// </summary>
        public List<RentCurrencyType> totalRevenue { get; set;   }
    }

    public class RentCurrencyType
    { 
        public int currencyType { get; set; }

        public decimal price { get; set; }
    }


    public class UnitRecordLog
    { 
        public List<RecordsLog> records { get; set; }

        public List<RentCurrencyType> amountNotYetClaimed { get; set; }
    }


    public class RecordsLog
    {
        /// <summary>
        /// 租戶id
        /// </summary>
        public uint tenant { get; set; }
        /// <summary>
        /// 租戶名稱
        /// </summary>
        public string tenantName { get; set; }
        /// <summary>
        /// 租用時間
        /// </summary>
        public DateTime date { get; set; }


        public string dateFormat { get; set; }
        /// <summary>
        /// 貨幣類別
        /// </summary>
        public int currencyType { get; set; }

        public string currencyTypeName { get; set; }
        /// <summary>
        /// 租金
        /// </summary>
        public decimal rent { get; set; }
        /// <summary>
        /// 領取時間
        /// </summary>
        public DateTime? receivedDate { get; set; }

        public string receivedDateFormat { get; set; }
    }



    public class NFTUnitPriceDTO
    {
        /// <summary>
        /// 擁有者錢包
        /// </summary>
        public string wallet { get; set; }
        public string ppsr { get; set; }     // 首拍編號
        public decimal price { get; set; }       // 價錢 

        public int currencyType { get; set; }       // 價錢 
    }


    public class NFTUnitCurrencyTypeDTO
    {
        /// <summary>
        /// 擁有者錢包
        /// </summary>
        public string wallet { get; set; }
        public string ppsr { get; set; }     // 首拍編號
        public int currencyType { get; set; }       // 價錢 
    }
}



