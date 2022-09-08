using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Entity.SnakeServer;
using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Services.SnakeServerService
{
    public class AsiaLeagueScheduleService
    {
        private readonly RestClient ServerClient;
        private ExternalServers externalServersConfig;
        //private RestRequest restRequest;
        public static List<AsiaLeagueSchedule> Schedules = new List<AsiaLeagueSchedule>();

        private readonly RestRequest ApiGetS1Schedule = new RestRequest("Table/Unity/AsiaLeagueS1Schedule", Method.GET);
        private readonly RestRequest ApiGetS2Schedule = new RestRequest("Table/Unity/AsiaLeagueS2Schedule", Method.GET);
        private readonly RestRequest ApiGetS3Schedule = new RestRequest("Table/Unity/AsiaLeagueS3Schedule", Method.GET);

        private SnakeTableService snakeTableService;

        public AsiaLeagueScheduleService(IOptions<ExternalServers> myConfiguration)
        {
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.TableServer);

            snakeTableService = new SnakeTableService(myConfiguration);


        }

        public async Task<List<AsiaLeagueSchedule>> GetAsiaLeagueSchedulesAsync(AsiaLeagueSeasons season) 
        {
            //var request = new RestRequest();
            //switch (season) 
            //{
            //    case AsiaLeagueSeasons.AsiaLeagueS1:
            //        request = new RestRequest(ApiGetS1Schedule.Resource, ApiGetS1Schedule.Method);
            //        break;

            //    case AsiaLeagueSeasons.Xmas2021:
            //        request = new RestRequest(ApiGetS2Schedule.Resource, ApiGetS2Schedule.Method);
            //        break;

            //    case AsiaLeagueSeasons.NewYear2021:
            //        request = new RestRequest(ApiGetS3Schedule.Resource, ApiGetS3Schedule.Method);
            //        break;
            //    default:
            //        return null;
            //}

            //IRestResponse restResponse = await ServerClient.ExecuteGetAsync(request);

            //if (restResponse.StatusCode == HttpStatusCode.OK)
            //{
            //    var jsonResult = JsonConvert.DeserializeObject(restResponse.Content).ToString();
            //    Schedules = JsonConvert.DeserializeObject<List<AsiaLeagueSchedule>>(jsonResult);
            //}

            //return Schedules;

            string sheetName;
            switch (season)
            {
                case AsiaLeagueSeasons.AsiaLeagueS1:
                    sheetName = "AsiaLeagueS1Schedule";
                    break;

                case AsiaLeagueSeasons.Xmas2021:
                    sheetName = "AsiaLeagueS2Schedule";
                    break;

                case AsiaLeagueSeasons.NewYear2021:
                    sheetName = "AsiaLeagueS3Schedule";
                    break;
                case AsiaLeagueSeasons.AsiaLeagueS3:
                    sheetName = "AsiaLeagueS7Schedule";
                    break;
                default:
                    return null;
            }

            ServerResponce resp = await snakeTableService.GetSheetFromTableServerAsync(sheetName);
            if (resp.Success)
            {
                var jsonResult = JsonConvert.DeserializeObject(resp.Content).ToString();
                Schedules = JsonConvert.DeserializeObject<List<AsiaLeagueSchedule>>(jsonResult);
                return Schedules;
                
            }
            else
            {
                return null;
            }


        }


        public AsiaLeagueSchedule GetOneSchedulesByDate(DateTime queryDate) 
        {
            AsiaLeagueSchedule asiaLeagueSchedule = Schedules.Find(x => x.Date.Date == queryDate.Date);
            return asiaLeagueSchedule;
        }

        public AsiaLeagueSchedule GetOneScheduleByIsGuildAndStation(Boolean isGuild, int station)
        {
            AsiaLeagueSchedule schedule = new AsiaLeagueSchedule();
            if (isGuild == false) ///個人
            {
                schedule = Schedules.Find(x => x.IndStation == station && x.IndFinalType != -1);
            }
            else ///團體
            {
                schedule = Schedules.Find(x => x.GuildStation == station && x.GuildFinalType != -1);
            }

            return schedule;
        }

        public List<AsiaLeagueSchedule> GetSchedulesByIsGuild(Boolean isGuild)
        {
            List<AsiaLeagueSchedule> schedules = new List<AsiaLeagueSchedule>();
            if (isGuild == false) ///個人
            {
                schedules = Schedules.FindAll(x => x.IndFinalType != -1);
            }
            else ///團體
            {
                schedules = Schedules.FindAll(x => x.GuildFinalType != -1);
            }
            return schedules;
        }

        public List<DateTime> GetQualifyingDates(Boolean isGuild, int station) 
        {
            List<AsiaLeagueSchedule> schedules = new List<AsiaLeagueSchedule>();
            if (isGuild == false) ///個人
            {
                schedules = Schedules.FindAll(x => x.IndStation == station && x.IndFinalType == -1 && !string.IsNullOrEmpty(x.IndividualSchedule) );
            }
            else ///團體
            {
                schedules = Schedules.FindAll(x => x.GuildStation == station && x.GuildFinalType == -1 && !string.IsNullOrEmpty(x.GuildSchedule));
            }

            List<DateTime> dates = new List<DateTime>();
            foreach (var s in schedules) 
            {
                dates.Add(s.Date.Date);

            }
            return dates;
        }
    }
}
