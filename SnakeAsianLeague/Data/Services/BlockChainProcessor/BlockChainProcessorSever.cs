using System.Net;
using System.Text;
using System.Web;

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



        string lineNotifyUrl = @"https://notify-api.line.me/api/notify";

        string LineNotifyId = "n9eaStbarwnMN7sU0QfnryxpB7kzMvX5UEh3LHp037U";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void SemdLineNotifyMsg(string msg)
        {

            msg = @"message=" + HttpUtility.UrlEncode(msg);
            var byteArray = Encoding.UTF8.GetBytes(msg);
            var request = (HttpWebRequest)WebRequest.Create(lineNotifyUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Authorization", $"Bearer {LineNotifyId}");
            request.Timeout = 30000;

            var dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            var response = (HttpWebResponse)request.GetResponse();
            var responseCode = (int)response.StatusCode;
            var responseStream = response.GetResponseStream();
            var responseMsg = responseStream != null ? new StreamReader(responseStream).ReadToEnd() : "Null Response";

        }

    }
}
