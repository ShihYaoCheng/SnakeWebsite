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
        private readonly RestClient BlockChainServerClient;

        private readonly RestClient ServerClient;
        public MetamaskTransfer(IOptions<ExternalServers> myConfiguration)
        {

            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.UserServer);
            BlockChainServerClient = new RestClient(externalServersConfig.NftWebApi);
            //ServerClient = new RestClient(externalServersConfig.UserServer);
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



        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<bool> SRCTransferToDB(uint UserID, decimal amount)
        {
            bool result = false;
            try
            {
                string URL = "/BC_SRCExchange/TransferToDB";
                var request = new RestRequest(URL, Method.GET);
                request.AddQueryParameter("userID", UserID.ToString());
                request.AddQueryParameter("amount", amount.ToString());
                IRestResponse restResponse = await BlockChainServerClient.ExecuteAsync(request);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    ResultTransferData ResultData = JsonSerializer.Deserialize<ResultTransferData>(restResponse.Content);
                    result = true;// ResultData.result;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
            }
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<bool> TSRCTransferToDB(uint UserID, decimal amount)
        {
            bool result = false;
            try
            {
                string URL = "/BC_TSRCExchange/TransferToDB"; 
                var request = new RestRequest(URL, Method.GET);
                request.AddQueryParameter("userID", UserID.ToString());
                request.AddQueryParameter("amount", amount.ToString());
                IRestResponse restResponse = await BlockChainServerClient.ExecuteAsync(request);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    ResultTransferData ResultData = JsonSerializer.Deserialize<ResultTransferData>(restResponse.Content);
                    result = true;// ResultData.result;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
            }
            return result;
        }




 


        public class ResultTransferData
        {
            public bool result { get; set; }

            public double amount { get; set; }
        }


    }
}
