using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Entity.SnakeServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Services.SnakeServerService
{
    public class GuildMemberService
    {
        private readonly RestClient ServerClient;
        private ExternalServers externalServersConfig;
        private RestRequest restRequest;

        public GuildMemberService(IOptions<ExternalServers> myConfiguration)
        {
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.UserServer);
            //restRequest = new RestRequest($"GuildMember");

        }

        public async Task<List<GuildMember>> GetGuildMembersByGuildId(int guildId)
        {
            restRequest = new RestRequest($"GuildMember");
            restRequest.Parameters.Clear();
            restRequest.AddParameter("GuildId", guildId);

            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(restRequest);

            List<GuildMember> members = new List<GuildMember>();
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                members = JsonConvert.DeserializeObject<List<GuildMember>>(restResponse.Content);
            }

            return members;
        }

        public async Task<GuildMember> GetGuildMembersByUserId(uint userId)
        {
            restRequest = new RestRequest($"GuildMember/{userId}");
            
            //restRequest.AddParameter("UserId", userId);

            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(restRequest);

            GuildMember member = new GuildMember();
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                member = JsonConvert.DeserializeObject<GuildMember>(restResponse.Content);
            }

            return member;
        }

        public async Task<Guild> GetGuildByGuildId(int guildId)
        {
            restRequest = new RestRequest($"Guild/{guildId}");


            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(restRequest);

            Guild guild = new Guild();
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                guild = JsonConvert.DeserializeObject<Guild>(restResponse.Content);
            }

            return guild;
        }

    }
}
