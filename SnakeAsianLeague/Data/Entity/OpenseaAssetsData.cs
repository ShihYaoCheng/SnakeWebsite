namespace SnakeAsianLeague.Data.Entity
{

    /// <summary>
    /// https://docs.opensea.io/reference/retrieving-assets-rinkeby
    /// 參考opensea api assets 回傳資料結構 有需再加
    /// 
    /// </summary>
    public class OpenseaAssetsData
    { 
        public List<assets> assets { get; set; }
    }
    public class assets
    {

        public int id { get; set; }

        public string name { get; set; }
        public string token_id { get; set; }

        public string image_url { get; set; }

        public sale? last_sale { get; set; }
    }


    public class sale
    { 
        public string total_price { get; set; }

        public payment_token? payment_token { get; set; }
    }

    public class payment_token
    { 
        public string symbol { get; set; }
        public string address { get; set; }
        public string image_url { get; set; }
        public string name { get; set; }
        public int decimals { get; set; }
        public string? eth_price { get; set; }
        public string? usd_price { get; set; }
    }
}

