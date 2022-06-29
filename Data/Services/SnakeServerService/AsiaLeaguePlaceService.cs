using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Entity.SnakeServer;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Services.SnakeServerService
{
    public class AsiaLeaguePlaceService
    {
        private readonly RestClient ServerClient;
        private ExternalServers externalServersConfig;
        private RestRequest restRequest;

        private GuildMemberService guildMemberService;
        public AsiaLeaguePlaceService(IOptions<ExternalServers> myConfiguration)
        {
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.UserServer);
            restRequest = new RestRequest($"AsiaLeaguePlace");

            guildMemberService = new GuildMemberService(myConfiguration);
        }

        public async Task<List<AsiaLeaguePlace>> GetAsiaLeaguePlacesByIsGuildAndStation(AsiaLeagueSeasons Season, Boolean isGuild, int station)
        {
            restRequest.Parameters.Clear();
            restRequest.AddParameter("Station", station);
            restRequest.AddParameter("IsGuild", isGuild);
            restRequest.AddParameter("SeasonNum", (int)Season);

            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(restRequest);

            List<AsiaLeaguePlace> places = new List<AsiaLeaguePlace>();
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                //places = JsonSerializer.Deserialize<List<AsiaLeaguePlace>>(restResponse.Content);
                places = JsonConvert.DeserializeObject<List<AsiaLeaguePlace>>(restResponse.Content);
                places = places.OrderBy(p => p.Place).ToList();
            }

            return places;
        }

        public async Task<List<AsiaLeaguePlace>> GetAsiaLeaguePlacesBySeason(AsiaLeagueSeasons Season)
        {
            restRequest.Parameters.Clear();
            restRequest.AddParameter("SeasonNum", (int)Season);

            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(restRequest);

            List<AsiaLeaguePlace> places = new List<AsiaLeaguePlace>();
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                //places = JsonSerializer.Deserialize<List<AsiaLeaguePlace>>(restResponse.Content);
                places = JsonConvert.DeserializeObject<List<AsiaLeaguePlace>>(restResponse.Content);
            }

            return places;
        }

        public async Task<List<AsiaLeaguePlace>> GetAwardNoticesByUserId(AsiaLeagueSeasons Season, uint userId)
        {
            List<AsiaLeaguePlace> Notices = new List<AsiaLeaguePlace>();
            //個人
            Notices = await GetAsiaLeaguePlacesUserId(Season,false, (int)userId);


            //團體
            GuildMember guildMember = await guildMemberService.GetGuildMembersByUserId(userId);
            Guild guild = await guildMemberService.GetGuildByGuildId(guildMember.GuildId);

            if(guild.GuildLeaderUserId == userId)
            {
                List<AsiaLeaguePlace> guildNotices = await GetAsiaLeaguePlacesUserId(Season,true, guild.GuildId);
                foreach (var g in guildNotices)
                {
                    Notices.Add(g);
                }
            }
            

            return Notices;

        }

        public async Task<List<AsiaLeaguePlace>> GetAsiaLeaguePlacesUserId(AsiaLeagueSeasons Season, Boolean isGuild, int winnerId) 
        {
            restRequest.Parameters.Clear();

            restRequest.AddParameter("IsGuild", isGuild);
            restRequest.AddParameter("WinnerId", winnerId);
            restRequest.AddParameter("SeasonNum", (int)Season);

            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(restRequest);
            List<AsiaLeaguePlace> places = new List<AsiaLeaguePlace>();
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                places = JsonConvert.DeserializeObject<List<AsiaLeaguePlace>>(restResponse.Content);
                if (Season == AsiaLeagueSeasons.AsiaLeagueS1)
                {
                    places = places.FindAll(x => x.Station > 0 && x.Place <= 3 );
                }
                else
                {
                    places = places.FindAll(x => x.Station > 0);
                }
                
            }

            return places;

        }
    }
}
