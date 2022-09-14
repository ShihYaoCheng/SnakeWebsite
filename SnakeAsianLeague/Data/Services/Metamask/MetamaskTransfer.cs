using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Entity.Config;
using System.Net;
using System.Text.Json;

namespace SnakeAsianLeague.Data.Services.Metamask
{
    public class MetamaskTransfer
    {
        //public object ServerClient { get; private set; }
        private ExternalServers externalServersConfig;

        private readonly RestClient ServerClient;
        public MetamaskTransfer(IOptions<ExternalServers> myConfiguration)
        {
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.UserServer);
            //ServerClient = new RestClient("https://rel.ponponsnake.com/api/user");
        }


        public class TransferData
        {
            public uint userId { get; set; }

            public decimal amount { get; set; }
        }

        public class getSRCData
        {
            public uint userId { get; set; }
        }


        public async Task<bool> SRCTransferToDB(uint UserID, decimal amount)
        {
            bool result = false;
            try
            {
                string URL = "/User/SRC/TransferToDB";
                TransferData transferData = new TransferData();
                transferData.userId = UserID;
                transferData.amount = amount;

                string jsonData = JsonSerializer.Serialize(transferData);
                var request = new RestRequest(URL, Method.POST);
                request.AddJsonBody(jsonData);
                request.AddHeader("Authorization", Authenticate());
                IRestResponse restResponse = await ServerClient.ExecuteAsync(request);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    ResultTransferData ResultData = JsonSerializer.Deserialize<ResultTransferData>(restResponse.Content);
                    result = ResultData.result;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
            }
            return result;
        }
       

        private string Authenticate()
        {
            string auth = "Unity:Yx2fy5tFfDHAfU7Az";
            auth = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
            auth = "Basic " + auth;
            return auth;
        }



        public class ResultTransferData
        {
            public bool result { get; set; }

            public double amount { get; set; }
        }
    }
}
