namespace SnakeAsianLeague.Data.Entity
{
    public class OpenseaOffersData
    {
        public Offers Offers { get; set; }
    }

    public class Offers
    {
        public DateTime created_date { get; set; }

        public payment_token_contract payment_token_contract { get; set; }

        public string base_price { get; set; }
    }

    public class payment_token_contract
    {
        public string symbol { get; set; }

        public string address { get; set; }

        public string image_url { get; set; }

        public string name { get; set; }

        public int decimals { get; set; }

        public string eth_price { get; set; }

        public string usd_price { get; set; }
    }
}

