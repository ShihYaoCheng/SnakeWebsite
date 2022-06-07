using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Entity;
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
    public class ProfileService
    {
        private readonly IDataAccess _db;
        private readonly IConfiguration _config;

        private readonly static KeyValuePair<string, string> RequestKey = new KeyValuePair<string, string>("Backend-Auth-Handler", "gmregk343grgeggw[fk55234w46wfwef46gpwekf[43-i@@!#!@#@");
        
        private ExternalServers externalServersConfig;
        private readonly RestClient ServerClient;

        public ProfileService(IDataAccess db , IConfiguration config, IOptions<ExternalServers> myConfiguration, HttpClient httpClient)
        {
            _db = db;
            _config = config;
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.UserServer);
        }

        public Task<List<Profile>> GetProfiles() 
        {
            string sql = "select * from Profile";

            return _db.LoadData<Profile, dynamic>(sql, new { }, _config.GetConnectionString("dev"));
        }

        public async Task<Profile> GetOneProfileByUserId(uint userId)
        {
            string sql = "select * from Profile where UserId = " + userId;
            List<Profile> rp = await _db.LoadData<Profile, dynamic>(sql, new { }, _config.GetConnectionString("dev"));
            if (rp.Count == 1)
            {
                return rp[0];
            }
            else 
            {
                return null;
            }
        }

        public Task InsertProfile(Profile profile)
        {
            string sql = @"insert into Profile (UserId, UserName, Phone, RealName, BeInterviewed , OpenAwardInfo , IdeaOfSnake, Recommendation ,Link , Gender , DateOfBirth, Email, City, SelfIntroduction)
                        values (@UserId, @UserName, @Phone, @RealName,@BeInterviewed , @OpenAwardInfo , @IdeaOfSnake, @Recommendation, @Link , @Gender, @DateOfBirth, @Email, @City, @SelfIntroduction);";

            return _db.SaveData<Profile>(sql, profile, _config.GetConnectionString("dev"));
        }

        public Task UpdateProfile(Profile profile)
        {
            string sql = @"update Profile 
                        set UserName = @UserName, Phone = @Phone, RealName = @RealName
                            , BeInterviewed = @BeInterviewed, OpenAwardInfo = @OpenAwardInfo, IdeaOfSnake = @IdeaOfSnake, Recommendation = @Recommendation, Link = @Link
                            , Gender = @Gender, DateOfBirth = @DateOfBirth , Email = @Email, City = @City , SelfIntroduction = @SelfIntroduction
                        where UserId = @UserId;";

            return _db.SaveData<Profile>(sql, profile, _config.GetConnectionString("dev"));
        }



        /// <summary>
        /// 抓取帳號有擁有 NFT騎士 數量
        /// </summary>
        /// <param name="UserID">使用者ID</param>
        /// <returns></returns>
        public async Task<int> Get_NFT_Rider_Count(string UserID)
        {
            int result = 0;
            RestRequest request = new RestRequest($"Unit/Checklist?UserID={UserID}");
            request.AddHeader("Authorization", Authenticate());

            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(request);

            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                RiderList lists = JsonSerializer.Deserialize<RiderList>(restResponse.Content) ?? new RiderList();

                //自有
                result  = lists.selfUnits.Where(m => m.isNFT == true).ToList().Count;

                //租任
                //result = lists.leaseUnits.Where(m => m.isNFT == true).ToList().Count;
                return result;
            }
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string Authenticate()
        {
            string auth = "Unity:Yx2fy5tFfDHAfU7Az";
            auth = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
            auth = "Basic " + auth;
            return auth;
        }
    }
}
