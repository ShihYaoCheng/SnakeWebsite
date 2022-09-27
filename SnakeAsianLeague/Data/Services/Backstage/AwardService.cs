using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Entity.Backstage;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Entity.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Services.Backstage
{
    public class AwardService
    {
        private ExternalServers externalServersConfig;
        private readonly RestClient BackstageServer;

        public AwardService(IOptions<ExternalServers> myConfiguration)
        {
            externalServersConfig = myConfiguration.Value;
            BackstageServer = new RestClient(externalServersConfig.BackstageServer);
        }

        public async Task<List<AwardDetail>> GetAwardDetails()
        {
            List<AwardDetail> result = new List<AwardDetail>();
            try
            {
                var LoginRestRequest = new RestRequest($"GetAwardDetails");
                IRestResponse restResponse = await BackstageServer.ExecuteGetAsync(LoginRestRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AwardDetail>>(restResponse.Content) ?? new List<AwardDetail>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetAwardDetails : " + ex.Message);
            }
            return result;
        }

        public async Task<List<AwardApplicationForm>> GetAwardApplicationForms()
        {
            List<AwardApplicationForm> result = new List<AwardApplicationForm>();
            try
            {
                var LoginRestRequest = new RestRequest($"GetAwardApplicationForms");
                IRestResponse restResponse = await BackstageServer.ExecuteGetAsync(LoginRestRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AwardApplicationForm>>(restResponse.Content) ?? new List<AwardApplicationForm>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetAwardApplicationForms : " + ex.Message);
            }
            return result;
        }


        public async Task<int> GetOneAwardDetailStatus(int seasonNum, bool isGuild, int station, int place, uint userId)
        {
            int result = new int();
            try
            {
                var LoginRestRequest = new RestRequest($"GetOneAwardDetailStatus?seasonNum={seasonNum}&isGuild={isGuild}&station={station}&place={place}&userId={userId}");
                IRestResponse restResponse = await BackstageServer.ExecuteGetAsync(LoginRestRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(restResponse.Content) ?? "0";
                    result = Convert.ToInt32(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetOnePrize : " + ex.Message);
            }
            return result;





            ////int isGuildInt = isGuild ? 1 : 0;
            //string sql = "select AwardStatus from AwardDetail where SeasonNum = " + seasonNum
            //    + " and IsGuild =" + isGuild + " and Station = " + station + " and Place = " + place
            //     + " and UserId = " + userId +" ;"
            //    ;
            //List<int> rp = await _db.LoadData<int, dynamic>(sql, new { }, MysqlConnectionString);
            //if (rp.Count == 1)
            //{
            //    return rp[0];
            //}
            //else
            //{
            //    return 0;
            //}
        }

        public async Task<AwardApplicationForm> GetOneAwardApplicationForm(int seasonNum, uint userId)
        {


            AwardApplicationForm result = new AwardApplicationForm();
            List<AwardApplicationForm> resultList = new List<AwardApplicationForm>();
            try
            {
                var LoginRestRequest = new RestRequest($"GetOneAwardDetailStatus?seasonNum={seasonNum}&userId={userId}");
                IRestResponse restResponse = await BackstageServer.ExecuteGetAsync(LoginRestRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    resultList = JsonSerializer.Deserialize<List<AwardApplicationForm>>(restResponse.Content) ?? new List<AwardApplicationForm>();
                    if (resultList.Count == 1)
                    {
                        result = resultList[0];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetOnePrize : " + ex.Message);
            }
            return result;


            ////int isGuildInt = isGuild ? 1 : 0;
            //string sql = "select * from AwardApplicationForm where SeasonNum = " + seasonNum
            //     + " and UserId = " + userId + " ;"
            //    ;
            //List<AwardApplicationForm> rp = await _db.LoadData<AwardApplicationForm, dynamic>(sql, new { }, MysqlConnectionString);
            //if (rp.Count == 1)
            //{
            //    return rp[0];
            //}
            //else
            //{
            //    return null;
            //}
        }

        public async Task<bool> InsertAward(AwardApplicationForm FormData, List<AwardNoticeView> AwardNoticeViews)
        {

            bool result = false;
            try
            {

                AwardNoticeViewData data = new AwardNoticeViewData();
                data.FormData = FormData;
                data.AwardNoticeViews = AwardNoticeViews;

                string jsonData = JsonSerializer.Serialize(data);
                var request = new RestRequest($"UpdateAward", Method.POST);
                request.AddJsonBody(jsonData);
                IRestResponse restResponse = await BackstageServer.ExecuteAsync(request);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateAward : " + ex.Message);
            }

            return result;


            //foreach(var view in AwardNoticeViews)
            //{
            //    AwardDetail award = new AwardDetail();
            //    award.SeasonNum = view.SeasonNum;
            //    award.IsGuild = view.IsGuild;
            //    award.Station = view.Station;
            //    award.Place = view.Place;
            //    award.UserId = data.UserId;
            //    award.AwardStatus = 1;

            //    InsertAwardDetail(award);
            //}

            //data.CreateTime = DateTime.Now;
            //string sql = @"insert into AwardApplicationForm (SeasonNum, UserId, UserName, Phone
            //        , RealName, ContactNumber, Email, Address, ApplyStatus, CreateTime)
            //    values (@SeasonNum, @UserId, @UserName, @Phone
            //        , @RealName, @ContactNumber, @Email , @Address, @ApplyStatus, @CreateTime);";

            //return _db.SaveData<AwardApplicationForm>(sql, data, MysqlConnectionString);

        }

        public async Task<bool> UpdateAward(AwardApplicationForm awardInfo)
        {
            bool result = false;
            try
            {
                string jsonData = JsonSerializer.Serialize(awardInfo);
                var request = new RestRequest($"UpdateAward", Method.POST);
                request.AddJsonBody(jsonData);
                IRestResponse restResponse = await BackstageServer.ExecuteAsync(request);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateAward : " + ex.Message);
            }

            return result;
        }

        public async Task<bool> InsertAwardDetail(AwardDetail awardDetail)
        {
            bool result = false;
            try
            {
                string jsonData = JsonSerializer.Serialize(awardDetail);
                var request = new RestRequest($"InsertAwardDetail", Method.POST);
                request.AddJsonBody(jsonData);
                IRestResponse restResponse = await BackstageServer.ExecuteAsync(request);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("InsertAwardDetail : " + ex.Message);
            }

            return result;
        }

    }
}
