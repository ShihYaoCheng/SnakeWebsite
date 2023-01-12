using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Entity.Config;
using System.Net;
using System.Text.Json;

namespace SnakeAsianLeague.Data.Services.ForwardUrl
{
    public class ForwardUrlService
    {

        private ExternalServers externalServersConfig;
        private readonly RestClient ServerClient;

        public ForwardUrlService(IOptions<ExternalServers> myConfiguration)
        {
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.UserServer);
        }


        public class QRCodeDto
        { 
            public string Code { get; set; }
        }


        /// <summary>
        /// 掃QRCode紀錄掃碼玩家的IP以及是誰的邀請碼
        /// </summary>
        /// <param name="QRCode"></param>
        /// <returns></returns>
        public async Task QRcodeSaveInvitation(string QRCode)
        {

            string URL = $"/InvitationCode/QRcodeSaveInvitation";
            RestRequest request = new RestRequest(URL, Method.POST);
            request.AddQueryParameter("code", QRCode);
            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(request);
            bool result = restResponse.StatusCode == HttpStatusCode.OK;

        }

        private string Authenticate()
        {
            string auth = "Unity:Yx2fy5tFfDHAfU7Az";
            auth = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
            auth = "Basic " + auth;
            return auth;
        }
    }
}
