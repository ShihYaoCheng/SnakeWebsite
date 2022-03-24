using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
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

        private readonly RestRequest ApiGetFinalQualifiy = new RestRequest("AsiaLeagueFinalQualifiedIdentity", Method.GET);

        public AsiaLeagueFinalQualifiedIdentityService(IOptions<ExternalServers> myConfiguration)
        {
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.UserServer);

        }

        public async Task<List<AsiaLeagueFinalQualifiedIdentity>> GetFinalQualifiy(AsiaLeagueSeasons season, int identityId)
        {
            var request = new RestRequest(ApiGetFinalQualifiy.Resource, ApiGetFinalQualifiy.Method);
            request.AddHeader("Authorization", Authenticate());
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
        private string Authenticate()
        {
            string auth = "Unity:Yx2fy5tFfDHAfU7Az";
            auth = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
            auth = "Basic " + auth;
            return auth;
        }

    }
}
