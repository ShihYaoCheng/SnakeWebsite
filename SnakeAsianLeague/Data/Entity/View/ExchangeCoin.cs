
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
        public decimal gNumber { get; set; }
        public decimal tokenNumber { get; set; }
        //顯示增減的貨幣
        public decimal gNumberChange { get; set; }
        public decimal tokenNumberChange { get; set; }

        
  


        public ExchangeCoin(string Title, decimal gCoin, decimal tokenCoin)
        {
            imgUrl = Title;
            gTitle = "g" + Title;
            tokenTitle = Title + "Token";
            gNumber = gCoin;
            tokenNumber = tokenCoin;
            gNumberChange = gCoin;
            tokenNumberChange = tokenCoin;
           
        }
        public void changeData(string Title, decimal gCoin, decimal tokenCoin)
        {
            imgUrl = Title;
            gTitle = "g" + Title;
            tokenTitle = Title + "Token";
            gNumber = gCoin;
            tokenNumber = tokenCoin;
            gNumberChange = gCoin;
            tokenNumberChange = tokenCoin;
           
        }
    }
}
