using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Entity.SnakeServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;


namespace SnakeAsianLeague.Data.Services.SnakeServerService
{
    public class QualifyingCompetitionRecordService
    {
        private readonly RestClient ServerClient;
        private ExternalServers externalServersConfig;
        private RestRequest restRequest;

        private GuildMemberService guildMemberService;

        public QualifyingCompetitionRecordService(IOptions<ExternalServers> myConfiguration)
        {
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.UserServer);
            // restRequest = new RestRequest($"QualifyingCompetitionRecord/StationStandings");

            guildMemberService = new GuildMemberService(myConfiguration);
        }

        public async Task<List<QualifyingCompetitionRecord>> GetQualifyingCompetitionRecordsByIsGuildAndStation(Boolean isGuild, int station) 
        {
            restRequest = new RestRequest($"QualifyingCompetitionRecord/StationStandings");
            //restRequest.Parameters.Clear();
            restRequest.AddParameter("IsGuild", isGuild);
            restRequest.AddParameter("Station", station);
            restRequest.AddParameter("SeasonNum", 1);
            restRequest.AddParameter("RankTop", 30);

            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(restRequest);

            List<QualifyingCompetitionRecord> records = new List<QualifyingCompetitionRecord>();
            if (restResponse.StatusCode == HttpStatusCode.OK) 
            {
                records = JsonSerializer.Deserialize<List<QualifyingCompetitionRecord>>(restResponse.Content);
                //records = records.OrderByDescending(x => x.Wins).ToList();
            }

            return records;
        }

        public async Task<List<QualifyingCompetitionRecord>> GetFinalRightsByUserId( uint userID)
        {
            List<QualifyingCompetitionRecord> FinalRights = new List<QualifyingCompetitionRecord>();
            
            //個人
            FinalRights = await GetFinalRightsByIsGuildAndIdentityIdAsync(false, (int)userID);
            


            //團體
            GuildMember guildMember = await guildMemberService.GetGuildMembersByUserId(userID);
            List<QualifyingCompetitionRecord> guildFinalRights = await GetFinalRightsByIsGuildAndIdentityIdAsync(true, guildMember.GuildId);
            foreach (var g in guildFinalRights)
            {
                FinalRights.Add(g);
            }

            return FinalRights;
        }

        public async Task<List<QualifyingCompetitionRecord>> GetFinalRightsByIsGuildAndIdentityIdAsync(Boolean isGuild, int identityId)
        {
            restRequest = new RestRequest($"QualifyingCompetitionRecord");
            //restRequest.Parameters.Clear();
            restRequest.AddParameter("IsGuild", isGuild);
            restRequest.AddParameter("IdentityId", identityId);

            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(restRequest);

            List<QualifyingCompetitionRecord> records = new List<QualifyingCompetitionRecord>();
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                records = JsonSerializer.Deserialize<List<QualifyingCompetitionRecord>>(restResponse.Content);
                records = records.FindAll(x => x.Rank <= 4 && x.Station >0 );

            }

            return records;
        }


    }
}
