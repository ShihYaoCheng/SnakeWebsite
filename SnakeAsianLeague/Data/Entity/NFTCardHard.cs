namespace SnakeAsianLeague.Data.Entity
{
    public class HeartParameter
    {
        public string TokenId { get; set; }
        public bool isLove { get; set; }
        public object checkedValue { get; set; }

        public HeartParameter(string tokenId, bool islove, object checkedvalue)
        {
            TokenId = tokenId;
            isLove = islove;
            checkedValue = checkedvalue;

        }
    }
}
