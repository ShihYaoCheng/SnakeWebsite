
namespace SnakeAsianLeague.Data.Entity.View
{
    public class ExchangeCoin
    {
        //圖片
        public string imgUrl { get; set; }
        //兩個貨幣標題
        public string gTitle { get; set; }
        public string tokenTitle { get; set; }
        //貨幣金額
        public double gNumber { get; set; }
        public double tokenNumber { get; set; }
        //顯示增減的貨幣
        public double gNumberChange { get; set; }
        public double tokenNumberChange { get; set; }

        public ExchangeCoin(string Title, double gCoin, double tokenCoin)
        {
            imgUrl = Title;
            gTitle = "g" + Title;
            tokenTitle = Title + " TOKEN";
            gNumber = gCoin;
            tokenNumber = tokenCoin;
            gNumberChange = gCoin;
            tokenNumberChange = tokenCoin;
        }
        public void changeData(string Title, double gCoin, double tokenCoin)
        {
            imgUrl = Title;
            gTitle = "g" + Title;
            tokenTitle = Title + " TOKEN";
            gNumber = gCoin;
            tokenNumber = tokenCoin;
            gNumberChange = gCoin;
            tokenNumberChange = tokenCoin;
        }
    }
}
