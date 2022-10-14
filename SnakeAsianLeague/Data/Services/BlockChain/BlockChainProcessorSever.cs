using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Entity.BlockChain;
using SnakeAsianLeague.Data.Entity.Config;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Web;

namespace SnakeAsianLeague.Data.Services.BlockChain
{
    public class BlockChainProcessorSever
    {


        
        string channelAccessToken = "rEkO8R7f6dQDmdMrobDtiUkaSFbINS5kfKM3ozup4zQGssi3NL4Msak/VtnNKo6LgIv2tCb/VufpihcZ5GADLYiXtjLT5Hz6wYyqsUcK3W7UaIKxVQlo/Ris/rAOwsCikKdcD0p1frf9RKz8bpNJhQdB04t89/1O/w1cDnyilFU=";
        private ExternalServers externalServersConfig;
        private readonly RestClient NftServerClient;

        public BlockChainInfoDTO BlockChainInfoDTO { get; private set; } = new BlockChainInfoDTO();

        public BlockChainProcessorSever(IOptions<ExternalServers> myConfiguration)
        {
            externalServersConfig = myConfiguration.Value;
            NftServerClient = new RestClient(externalServersConfig.NftWebApi);

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

        string LineNotifyId = "x4pjZXiauL780ZPbmEM8EkFjX8brpUy3Bp724Ugb18M";

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


        public async Task GetBlockChainInfoDTO()
        {
            BlockChainInfoDTO result = new BlockChainInfoDTO();

            try
            {
                RestRequest request = new RestRequest($"BlockChainInfo/GetBlockChainInfo");
                IRestResponse restResponse = await NftServerClient.ExecuteGetAsync(request);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = JsonSerializer.Deserialize<BlockChainInfoDTO>(restResponse.Content) ?? new BlockChainInfoDTO();
                }
            }
            catch (Exception)
            {
                result = new BlockChainInfoDTO();
            }
            this.BlockChainInfoDTO = result;
        }

    }
}
