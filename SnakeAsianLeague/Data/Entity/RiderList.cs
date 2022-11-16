namespace SnakeAsianLeague.Data.Entity
{
    public class RiderList
    {

        public List<RiderUnit> leaseUnits { get; set; }

        public List<RiderUnit> selfUnits { get; set; }

        public string fight { get; set; }
    }


    public class RiderUnit
    {
        public string serialNumber { get; set; }
        public string ppsr { get; set; }

        public int level { get; set; }

        public int exp { get; set; }


        /// <summary>
        /// 租金
        /// </summary>
        public decimal rent { get; set; }

        /// <summary>
        /// 累計租金(累計收益)
        /// </summary>
        public List<TotalRevenue> totalRevenue { get; set; }

        public string name { get; set; }

        public string winningPercentage { get; set; }

        public int appearancesCount { get; set; }

        /// <summary>
        /// 是否是我的最愛
        /// </summary>
        public bool isLove { get; set; }

        /// <summary>
        /// 是否是NFT
        /// </summary>
        public bool isNFT { get; set; }


        /// <summary>
        /// 遊戲中是否開放
        /// </summary>
        public bool IsAvailableInGame { get; set; }


        /// <summary>
        /// 職業代碼
        /// </summary>
        //public string occupationId { get; set; }
    }




    public class TotalRevenue
    { 
        public int currencyType { get; set; }

        public decimal price { get; set; }
    }


    public class gSRCCurrency { 
        public uint userId { get; set; }

        public decimal nftCurrency1 { get; set; }
    }

    public class Currencies
    { 
        public int currencyType { get; set; }

        public decimal price { get; set; }


    }


}


