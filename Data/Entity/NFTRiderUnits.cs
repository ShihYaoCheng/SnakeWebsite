namespace SnakeAsianLeague.Data.Entity
{
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

        public List<castings> castings { get; set; }
    }

    public class castings
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
    }
}
