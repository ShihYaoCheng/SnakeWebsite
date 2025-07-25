﻿namespace SnakeAsianLeague.Data.Entity
{
    /// <summary>
    /// api /NFT/Units  取得所有角色列表 
    /// </summary>
    public class NFTRiderUnits
    {
        /// <summary>
        /// 鍛造次數
        /// </summary>
        public int mintCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string serialNumber { get; set; }

        /// <summary>
        /// 職業代碼
        /// </summary>
        public string occupationId { get; set; }
        /// <summary>
        /// 名子
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 尺寸
        /// </summary>
        public double size { get; set; }
        /// <summary>
        /// 騎士
        /// </summary>
        public string knight { get; set; }
        /// <summary>
        /// 蛇蛇
        /// </summary>
        public string snake { get; set; }
        /// <summary>
        /// 武器
        /// </summary>
        public string weapon { get; set; }
        /// <summary>
        /// 寵物
        /// </summary>
        public string pet { get; set; }

        public List<RiderUnits_Castings> castings { get; set; }
    }

    public class RiderUnits_Castings
    {
        /// <summary>
        /// 
        /// </summary>
        public string tokenId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ppsr { get; set; }


        /// <summary>
        /// 合約編號
        /// </summary>
        public string contractAddress { get; set; }


        /// <summary>
        /// 遊戲端是否顯示
        /// </summary>
        public bool isAvailableInGame { get; set; }


        public List<totalRevenue> totalRevenue { get; set; }
    }


    public class totalRevenue
    { 
        public int currencyType { get; set; }

        public decimal price { get; set; }
    }
}
