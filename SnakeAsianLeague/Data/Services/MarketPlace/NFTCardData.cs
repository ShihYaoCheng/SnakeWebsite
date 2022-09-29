namespace SnakeAsianLeague.Data.Services.MarketPlace
{
    public class NFTCardData
    {

        public string ppsr { get; set; }
        public decimal totalRevenue { get; set; }
        public object onClickValue { get; set; }

        public void getData(string Ppsr, decimal TotalRevenue , object OnClickValue) {
            ppsr = Ppsr;
            totalRevenue = TotalRevenue;
            onClickValue = OnClickValue;
        }
    }
}
