using Microsoft.Extensions.Configuration;
using SnakeAsianLeague.Data.Entity.Backstage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Services.Backstage
{
    public class ProfileService
    {
        private readonly IDataAccess _db;
        private readonly IConfiguration _config;

        public ProfileService(IDataAccess db , IConfiguration config)
        {
            _db = db;
            _config = config;
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

    }
}
