namespace SnakeAsianLeague.Data.Entity.Commodity
{
    public class CommodityDto
    {
    }

    public class IAPItem
    {

        public string platform { get; set; }
        public string productID { get; set; }

        public string productUrl { get; set; }
        public int limitType { get; set; }
        public int saleType { get; set; }
        public int itemTag { get; set; }
        public int itemType { get; set; }
        public int itemID { get; set; }
        public int addValue { get; set; }
        public int addPlus { get; set; }
        public int status { get; set; }
        public int limitCount { get; set; }
        public int price { get; set; }

        public double priceUSD { get; set; }
        public double priceUSDT { get; set; }
         

    }
}
