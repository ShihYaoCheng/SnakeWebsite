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
    public class SponsorService
    {
        private ExternalServers externalServersConfig;
        private readonly RestClient SnakeACLBackstageServer;

        public SponsorService(IOptions<ExternalServers> myConfiguration)
        {
            externalServersConfig = myConfiguration.Value;
            SnakeACLBackstageServer = new RestClient(externalServersConfig.SnakeACLBackstageServer);
        }

        public async Task<List<Sponsor>> GetSponsors()
        {
            List<Sponsor> result = new List<Sponsor>();
            try
            {
                var LoginRestRequest = new RestRequest($"api/Identity/GetSponsors");
                IRestResponse restResponse = await SnakeACLBackstageServer.ExecuteGetAsync(LoginRestRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Sponsor>>(restResponse.Content) ?? new List<Sponsor>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetSponsors : " + ex.Message);
            }
            return result;
        }

        public async Task<List<Sponsor>> GetSponsorsByType(int type)
        {
            List<Sponsor> result = new List<Sponsor>();
            try
            {
                var LoginRestRequest = new RestRequest($"api/Identity/GetSponsorsByType?type={type}");
                IRestResponse restResponse = await SnakeACLBackstageServer.ExecuteGetAsync(LoginRestRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Sponsor>>(restResponse.Content) ?? new List<Sponsor>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetSponsorsByType : " + ex.Message);
            }
            return result;
        }

    }
}
