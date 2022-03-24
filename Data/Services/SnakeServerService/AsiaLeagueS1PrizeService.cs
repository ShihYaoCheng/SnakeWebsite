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
    public class AsiaLeagueS1PrizeService
    {
        private readonly RestClient ServerClient;
        private ExternalServers externalServersConfig;
        private RestRequest restRequest;

        public static List<AsiaLeaguePrize> Prizes = new List<AsiaLeaguePrize>();

        public AsiaLeagueS1PrizeService(IOptions<ExternalServers> myConfiguration)
        {
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.TableServer);
            restRequest = new RestRequest($"Table/Unity/AsiaLeagueS1Prize");

        }

        public async Task<List<AsiaLeaguePrize>> GetAsiaLeaguePrizesAsync()
        {
            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(restRequest);

            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                //var rponse = JsonConvert.DeserializeObject<SnakeVersionJsonResponse>(restResponse.Content);
                //Prizes = JsonConvert.DeserializeObject<List<AsiaLeaguePrize>>(rponse.json);

                //1.12.1.1
                var jsonResult = JsonConvert.DeserializeObject(restResponse.Content).ToString();
                Prizes = JsonConvert.DeserializeObject<List<AsiaLeaguePrize>>(jsonResult);

            }
            return Prizes;
        }

        public AsiaLeaguePrize GetOnePrize(Boolean isGuild, int type, int place) 
        {
            
            AsiaLeaguePrize asiaLeaguePrize = Prizes.Find(x => x.IsOpen == true && x.IsGuild == isGuild && x.Type == type && x.Place == place);
            
            return asiaLeaguePrize;
        }


    }
}
