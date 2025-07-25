﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Contracts;
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
        //private readonly IDataAccess _db;
        //private readonly IConfiguration _config;

        private readonly static KeyValuePair<string, string> RequestKey = new KeyValuePair<string, string>("Backend-Auth-Handler", "gmregk343grgeggw[fk55234w46wfwef46gpwekf[43-i@@!#!@#@");
        
        private ExternalServers externalServersConfig;
        private readonly RestClient ServerClient;
        private readonly RestClient BackstageServer;
        private IAuthManagement _AuthManagement;

        public ProfileService( IOptions<ExternalServers> myConfiguration, HttpClient httpClient, IAuthManagement authManagement)
        {
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.UserServer);
            BackstageServer = new RestClient(externalServersConfig.BackstageApiServer);
            _AuthManagement = authManagement;
            //Console.WriteLine(externalServersConfig.BackstageApiServer);
        }

        public async Task<List<Profile>> GetProfiles() 
        {

            List<Profile> result = new List<Profile>();
            try
            {
                var LoginRestRequest = new RestRequest($"Identity/GetProfiles");
                IRestResponse restResponse = await BackstageServer.ExecuteGetAsync(LoginRestRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Profile>>(restResponse.Content) ?? new List<Profile>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetProfiles : " + ex.Message);
            }
            return result;

            //string sql = "select * from Profile";

            //return _db.LoadData<Profile, dynamic>(sql, new { }, _config.GetConnectionString("dev"));
        }

        public async Task<Profile> GetOneProfileByUserId(uint userId)
        {
            Profile result = new Profile();          
            try
            {
                var LoginRestRequest = new RestRequest($"Identity/GetOneProfileByUserId?userId={userId}");
                IRestResponse restResponse = await BackstageServer.ExecuteGetAsync(LoginRestRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<Profile>(restResponse.Content) ?? new Profile();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetOneProfileByUserId : " + ex.Message);
            }
            return result;
        }

        public async Task<bool> InsertProfile(Profile profile)
        {

            bool result = false;
            try
            {
                string jsonData = JsonSerializer.Serialize(profile);
                var request = new RestRequest($"Identity/InsertProfile", Method.POST);
                request.AddJsonBody(jsonData);
                IRestResponse restResponse = await BackstageServer.ExecuteAsync(request);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("InsertProfile : " + ex.Message);
            }

            return result;

            //string sql = @"insert into Profile (UserId, UserName, Phone, RealName, BeInterviewed , OpenAwardInfo , IdeaOfSnake, Recommendation ,Link , Gender , DateOfBirth, Email, City, SelfIntroduction)
            //            values (@UserId, @UserName, @Phone, @RealName,@BeInterviewed , @OpenAwardInfo , @IdeaOfSnake, @Recommendation, @Link , @Gender, @DateOfBirth, @Email, @City, @SelfIntroduction);";

            //return _db.SaveData<Profile>(sql, profile, _config.GetConnectionString("dev"));
        }

        public async Task<bool> UpdateProfile(Profile profile)
        {
            bool result = false;
            try
            {
                string jsonData = JsonSerializer.Serialize(profile);
                var request = new RestRequest($"Identity/UpdateProfile", Method.POST);
                request.AddJsonBody(jsonData);
                IRestResponse restResponse = await BackstageServer.ExecuteAsync(request);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateProfile : " + ex.Message);
            }

            return result;


            //string sql = @"update Profile 
            //            set UserName = @UserName, Phone = @Phone, RealName = @RealName
            //                , BeInterviewed = @BeInterviewed, OpenAwardInfo = @OpenAwardInfo, IdeaOfSnake = @IdeaOfSnake, Recommendation = @Recommendation, Link = @Link
            //                , Gender = @Gender, DateOfBirth = @DateOfBirth , Email = @Email, City = @City , SelfIntroduction = @SelfIntroduction
            //            where UserId = @UserId;";

            //return _db.SaveData<Profile>(sql, profile, _config.GetConnectionString("dev"));
        }



        /// <summary>
        /// 抓取帳號有擁有 NFT騎士 數量
        /// </summary>
        /// <param name="UserID">使用者ID</param>
        /// <returns></returns>
        public async Task<int> Get_NFT_Rider_Count(string UserID)
        {
            int result = 0;
            string URL = "/Unit/CheckForBackEnd";
            var request = new RestRequest(URL, Method.GET);
            request.AddQueryParameter("UserID", UserID);
            request.AddHeader("Authorization", $"Bearer {_AuthManagement.GetUserAccessTokenInCookie()}");

            try
            {
                IRestResponse restResponse = await ServerClient.ExecuteAsync(request);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    RiderList lists = JsonSerializer.Deserialize<RiderList>(restResponse.Content) ?? new RiderList();

                    //自有
                    //List<RiderUnit> result = lists.selfUnits.Where(m => m.isNFT == true).ToList() ?? new List<RiderUnit>();

                    //租任
                    //List<RiderUnit> result = lists.leaseUnits.Where(m => m.isNFT == true).ToList() ?? new List<RiderUnit>();

                    //自有
                    result = lists.selfUnits.Where(m => m.isNFT == true).ToList().Count;
                    
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return result;

        }





    }
}
