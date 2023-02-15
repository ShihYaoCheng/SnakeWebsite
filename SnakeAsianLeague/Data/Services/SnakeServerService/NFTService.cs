using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using SnakeAsianLeague.Data.Contracts;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Entity.SnakeServer;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Services.SnakeServerService
{
    public class NFTService
    {
        private readonly static KeyValuePair<string, string> RequestKey = new KeyValuePair<string, string>("Backend-Auth-Handler", "gmregk343grgeggw[fk55234w46wfwef46gpwekf[43-i@@!#!@#@");
        private readonly RestClient ServerClient;
        private ExternalServers externalServersConfig;

        private readonly RestRequest ApiPostNFTWalletAddress = new RestRequest("NFT/WalletAddress", Method.POST);

        private IAuthManagement _AuthManagement;

        public NFTService(IOptions<ExternalServers> myConfiguration , IAuthManagement  authManagement)
        {
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.UserServer);
            _AuthManagement = authManagement;
        }

        public async Task<ServerResponce> PostNFTWalletAddress(uint userID, string address)
        {
            
            var request = new RestRequest(ApiPostNFTWalletAddress.Resource, ApiPostNFTWalletAddress.Method);
            request.AddQueryParameter("UserID", userID.ToString());
            request.AddQueryParameter("WalletAddress", address.ToLower());
            request.AddHeader("Authorization", $"Bearer {_AuthManagement.GetAdminAccessTokenInCookie()}");
            var response = await ServerClient.ExecuteAsync(request);


            

            ServerResponce serverResponce = new ServerResponce();
            if ( response.StatusCode == HttpStatusCode.Created)
            {
                serverResponce.Success = true;
                serverResponce.Content = "綁定成功";

            }
            else if (response.StatusCode == HttpStatusCode.OK)
            {
                serverResponce.Success = true;
                serverResponce.Content = "已綁定";
            }
            else
            {
                serverResponce.Success = false;
                serverResponce.Content = response.Content;
            }
            

            return serverResponce;
        }


    }

    public class WalletAddressDTO
    {
        public uint UserID { get; set; }

        public string WalletAddress { get; set; }
    }
}
