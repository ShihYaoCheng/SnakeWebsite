namespace SnakeAsianLeague.Data.Services.BlockChainProcessor
{
    public class BlockChainProcessorSever
    {


        
        string channelAccessToken = "rEkO8R7f6dQDmdMrobDtiUkaSFbINS5kfKM3ozup4zQGssi3NL4Msak/VtnNKo6LgIv2tCb/VufpihcZ5GADLYiXtjLT5Hz6wYyqsUcK3W7UaIKxVQlo/Ris/rAOwsCikKdcD0p1frf9RKz8bpNJhQdB04t89/1O/w1cDnyilFU=";

        public BlockChainProcessorSever()
        {

        }

        public void LineBotMessage(string msg)
        {
            string UserID = "U39d8c008277c061933705c821020bf68";
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(channelAccessToken);
            bot.PushMessage(UserID, msg);
        }

        public void LineBotMessageByUserID(string UserID , string msg)
        {
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(channelAccessToken);
            bot.PushMessage(UserID, msg);
        }

    }
}
