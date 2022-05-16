namespace SnakeAsianLeague.Data.Entity
{
    public class NFTData
    {

        public string Number { get; set; }
        public string Name { get; set; }

        public string Price { get; set; }

        public string USD { get; set; }

        public string ImgPath { get; set; }

        public string LinkURL { get; set; }

        /// <summary>
        /// 稀有度
        /// </summary>
        public string Rarity { get; set; }

        /// <summary>
        /// 屬性
        /// </summary>
        public string Elements { get; set; }

        /// <summary>
        /// 職業專精
        /// </summary>
        public string Class { get; set; }

        public string Country { get; set; }

        public DateTime EndTime { get; set; }

        public string CalDays { get; set; }

        public bool IsOpen { get; set; }

        public bool IsLove { get; set; }

        public bool IsNFT { get; set; }
    }
}
