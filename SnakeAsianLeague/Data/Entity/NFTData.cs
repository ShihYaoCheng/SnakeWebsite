namespace SnakeAsianLeague.Data.Entity
{
    public class NFTData
    {

        public string TokenID { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 角色詳細By編號
        /// </summary>
        public string serialNumber { get; set; }

        public string Price { get; set; }

        public string USD { get; set; }

        public string ImgPath { get; set; }

        public string LinkURL { get; set; }

        /// <summary>
        /// 稀有度key
        /// </summary>
        public string RarityKey { get; set; }
        /// <summary>
        /// 稀有度名子
        /// </summary>
        public string RarityValue { get; set; }

        /// <summary>
        /// 屬性
        /// </summary>
        public string Elements { get; set; }

        /// <summary>
        /// 屬性Icon 
        /// </summary>
        public string ElementsIcon { get; set; }

        /// <summary>
        /// 職業專精
        /// </summary>
        public string ClassKey { get; set; }
        /// <summary>
        /// 職業專精
        /// </summary>
        public string ClassValue { get; set; }

        public string Country { get; set; }

        public DateTime EndTime { get; set; }

        public string CalDays { get; set; }

        /// <summary>
        /// 是否公開販售
        /// </summary>
        public bool IsOpen { get; set; }

        /// <summary>
        /// 是否加入我的最愛
        /// </summary>
        public bool IsLove { get; set; }


        /// <summary>
        /// 使否為NFT
        /// </summary>
        public bool IsNFT { get; set; }


        /// <summary>
        /// 擁有者是否為官方
        /// </summary>
        public bool IsOfficial { get; set; }

        /// <summary>
        /// 是否遊戲端是否顯示
        /// </summary>
        public bool isAvailableInGame { get; set; }

        /// <summary>
        /// 當前租金
        /// </summary>
        public decimal nowRent { get; set; }

        /// <summary>
        /// 累計租金(累計收益)
        /// </summary>
        public decimal totalRevenue { get; set; }
    }
}
