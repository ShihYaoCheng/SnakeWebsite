
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
        //預熱活動用
        public void changeTSRCData(string Title, decimal gCoin, decimal tokenCoin)
        {
            imgUrl = "SRC";
            gTitle = "g" + Title;
            tokenTitle = "t"+Title ;
            gNumber = gCoin;
            tokenNumber = tokenCoin;
            gNumberChange = gCoin;
            tokenNumberChange = tokenCoin;

        }
    }


    public class CoinData
    {
        //貨幣金額
        public decimal gSRC { get; set; }  
        public decimal gERNC { get; set; }
        public decimal tokenSRC { get; set; }
        public decimal tokenERNC { get; set; }
        //臨時用
        public decimal SRC { get; set; }
        

        /// <summary>
        /// 星鑽
        /// </summary>
        public decimal Gold { get; set; }


        public CoinData()
        { 
        }

        public CoinData( decimal GSRC, decimal GERNC, decimal TokenSRC , decimal TokenERNC , decimal Gold)
        {
            gSRC = GSRC;
            gERNC = GERNC;
            tokenSRC = TokenSRC;
            tokenERNC = TokenERNC;
            Gold = Gold;
        }
        public void gSRCchange(decimal Value)
        {
            gSRC = Value;
        }
        public void gERNCchange(decimal Value)
        {
            gERNC = Value;
        }
        public void tokenSRCchange(decimal Value)
        {
            tokenSRC = Value;
        }
        public void SRCchange(decimal Value)
        {
            SRC = Value;
        }
        public void tokenERNCchange(decimal Value)
        {
            tokenERNC = Value;
        }

        public void SetGoldChange(decimal Value)
        {
            Gold = Value;
        }

    }
}
