using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Entity.Backstage;
using SnakeAsianLeague.Data.Entity.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Services.Backstage
{
    public class S2PrizeService
    {
        private ExternalServers externalServersConfig;
        private readonly RestClient SnakeACLBackstageServer;

        public S2PrizeService(IOptions<ExternalServers> myConfiguration)
        {
            externalServersConfig = myConfiguration.Value;
            SnakeACLBackstageServer = new RestClient(externalServersConfig.SnakeACLBackstageServer);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="seasonNum"></param>
        /// <returns></returns>
        public async Task<List<S2Prize>> GetSeasonPrizes(int seasonNum)
        {
            List<S2Prize> result = new List<S2Prize>();
            try
            {
                var LoginRestRequest = new RestRequest($"GetSeasonPrizes?seasonNum={seasonNum}");
                IRestResponse restResponse = await SnakeACLBackstageServer.ExecuteGetAsync(LoginRestRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<S2Prize>>(restResponse.Content) ?? new List<S2Prize>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetSeasonPrizes : " + ex.Message);
            }
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="seasonNum"></param>
        /// <returns></returns>
        public async Task<List<S2Prize>> GetSeasonPrizesMyCard(int seasonNum)
        {
            List<S2Prize> result = new List<S2Prize>();
            try
            {
                var LoginRestRequest = new RestRequest($"GetSeasonPrizesMyCard?seasonNum={seasonNum}");
                IRestResponse restResponse = await SnakeACLBackstageServer.ExecuteGetAsync(LoginRestRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<S2Prize>>(restResponse.Content) ?? new List<S2Prize>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetSeasonPrizesMyCard : " + ex.Message);
            }
            return result;
        }

        public async Task<S2Prize> GetOnePrize(int seasonNum, int station, int place)
        {
            S2Prize result = new S2Prize();
           
            try
            {
                var LoginRestRequest = new RestRequest($"GetOnePrize?seasonNum={seasonNum}&station={station}&place={place}");
                IRestResponse restResponse = await SnakeACLBackstageServer.ExecuteGetAsync(LoginRestRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<S2Prize>(restResponse.Content) ?? new S2Prize();
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetOnePrize : " + ex.Message);
            }
            return result;



            //string sql = "select S2PrizeId, SeasonNum, Station, S2PrizePlace, PrizeName, S2PrizeStatus from S2Prize "
            //    + " where S2PrizeStatus = 1 and SeasonNum = " + seasonNum 
            //    + " and Station = " + station + " and S2PrizePlace = " + place + " ; ";

            //List<S2Prize> Prizes = await _db.LoadData<S2Prize, dynamic>(sql, new { }, _config.GetConnectionString("dev"));

            //if (Prizes.Count ==1)
            //{
            //    return Prizes[0];
            //}
            //else
            //{
            //    return null;

            //}

        }

    }
}
