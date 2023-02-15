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
    public class AsiaLeagueFinalQualifiedIdentityService
    {
        private readonly static KeyValuePair<string, string> RequestKey = new KeyValuePair<string, string>("Backend-Auth-Handler", "gmregk343grgeggw[fk55234w46wfwef46gpwekf[43-i@@!#!@#@");
        private readonly RestClient ServerClient;
        private ExternalServers externalServersConfig;
        private IAuthManagement _AuthManagement;

        private readonly RestRequest ApiGetFinalQualifiy = new RestRequest("AsiaLeagueFinalQualifiedIdentity", Method.GET);

        public AsiaLeagueFinalQualifiedIdentityService(IOptions<ExternalServers> myConfiguration, IAuthManagement authManagement)
        {
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.UserServer);
            _AuthManagement = authManagement;

        }

        public async Task<List<AsiaLeagueFinalQualifiedIdentity>> GetFinalQualifiy(AsiaLeagueSeasons season, int identityId)
        {
            var request = new RestRequest(ApiGetFinalQualifiy.Resource, ApiGetFinalQualifiy.Method);
            request.AddHeader("Authorization", $"Bearer {_AuthManagement.GetAdminAccessTokenInCookie()}");
            request.AddHeader(RequestKey.Key, RequestKey.Value);
            request.AddParameter("SeasonNum", (int)season);
            request.AddParameter("IdentityId", identityId);

            var response = await ServerClient.ExecuteAsync(request);

            List<AsiaLeagueFinalQualifiedIdentity> identities = new List<AsiaLeagueFinalQualifiedIdentity>();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                identities = JsonConvert.DeserializeObject<List<AsiaLeagueFinalQualifiedIdentity>>(response.Content);
            }
            
            return identities;
        }


    }
}
