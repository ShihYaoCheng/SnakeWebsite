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
    public class AwardInfoService
    {
        private ExternalServers externalServersConfig;
        private readonly RestClient BackstageServer;

        public AwardInfoService(IOptions<ExternalServers> myConfiguration) 
        {

            externalServersConfig = myConfiguration.Value;
            BackstageServer = new RestClient(externalServersConfig.BackstageServer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<AwardInfo>> GetAwardInfos()
        {
            List<AwardInfo> result = new List<AwardInfo>();
            try
            {
                var LoginRestRequest = new RestRequest($"GetAwardInfos");
                IRestResponse restResponse = await BackstageServer.ExecuteGetAsync(LoginRestRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AwardInfo>>(restResponse.Content) ?? new List<AwardInfo>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetAwardInfos : " + ex.Message);
            }            
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="prizeCode"></param>
        /// <param name="place"></param>
        /// <param name="isGuild"></param>
        /// <param name="station"></param>
        /// <returns></returns>
        public async Task<AwardInfo> GetOneAwardInfo(uint userId, string prizeCode, int place, bool isGuild, int station)
        {
            AwardInfo result = new AwardInfo();
            try
            {
                var LoginRestRequest = new RestRequest(string.Format("GetOneAwardInfo?userId={0}&prizeCode={1}&place={2}&isGuild={3}&station={4}", userId, prizeCode, place, isGuild, station));
                IRestResponse restResponse = await BackstageServer.ExecuteGetAsync(LoginRestRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<AwardInfo>(restResponse.Content) ?? new AwardInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetOneAwardInfo : " + ex.Message);
            }            
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="prizeCode"></param>
        /// <param name="place"></param>
        /// <param name="isGuild"></param>
        /// <param name="station"></param>
        /// <returns></returns>
        public async Task<int> GetOneAwardInfoStatus(uint userId, string prizeCode, int place, bool isGuild, int station)
        {
            int result = 0;
            try
            {
                var LoginRestRequest = new RestRequest(string.Format("GetOneAwardInfoStatus?userId={0}&prizeCode={1}&place={2}&isGuild={3}&station={4}", userId, prizeCode, place, isGuild, station));
                IRestResponse restResponse = await BackstageServer.ExecuteGetAsync(LoginRestRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(restResponse.Content) ?? "0";
                    result = Convert.ToInt32(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetOneAwardInfoStatus : " + ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="awardInfo"></param>
        /// <returns></returns>
        public async Task<bool> InsertAwardInfo(AwardInfo awardInfo)
        {
            bool result = false;
            try
            {
                string jsonData = JsonSerializer.Serialize(awardInfo);
                var request = new RestRequest($"InsertAwardInfo", Method.POST);
                request.AddJsonBody(jsonData);
                IRestResponse restResponse = await BackstageServer.ExecuteAsync(request);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("InsertAwardInfo : " + ex.Message);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="awardInfo"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAwardInfo(AwardInfo awardInfo)
        {
            bool result = false;
            try
            {
                string jsonData = JsonSerializer.Serialize(awardInfo);
                var request = new RestRequest($"UpdateAwardInfo", Method.POST);
                request.AddJsonBody(jsonData);
                IRestResponse restResponse = await BackstageServer.ExecuteAsync(request);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateAwardInfo : " + ex.Message);
            }
            return result;
        }

    }
}
