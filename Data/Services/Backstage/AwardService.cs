using Microsoft.Extensions.Configuration;
using SnakeAsianLeague.Data.Entity.Backstage;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Entity.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Services.Backstage
{
    public class AwardService
    {
        private readonly IDataAccess _db;
        //private readonly IConfiguration _config;
        private readonly string MysqlConnectionString;

        public AwardService(IDataAccess db, IConfiguration Configuration)
        {
            _db = db;
            var config = new MySQLConfig();
            Configuration.GetSection("MySQL").Bind(config);
            MysqlConnectionString = $"Server={config.IP};Port={config.Port};database={config.DatabaseName};user id={config.User};password={config.Password}";
        }

        public Task<List<AwardDetail>> GetAwardDetails()
        {
            string sql = "select * from AwardDetail";

            return _db.LoadData<AwardDetail, dynamic>(sql, new { }, MysqlConnectionString);
        }

        public Task<List<AwardApplicationForm>> GetAwardApplicationForms()
        {
            string sql = "select * from AwardApplicationForm";

            return _db.LoadData<AwardApplicationForm, dynamic>(sql, new { }, MysqlConnectionString);
        }


        public async Task<int> GetOneAwardDetailStatus(int seasonNum, bool isGuild, int station, int place, uint userId)
        {
            //int isGuildInt = isGuild ? 1 : 0;
            string sql = "select AwardStatus from AwardDetail where SeasonNum = " + seasonNum
                + " and IsGuild =" + isGuild + " and Station = " + station + " and Place = " + place
                 + " and UserId = " + userId +" ;"
                ;
            List<int> rp = await _db.LoadData<int, dynamic>(sql, new { }, MysqlConnectionString);
            if (rp.Count == 1)
            {
                return rp[0];
            }
            else
            {
                return 0;
            }
        }

        public async Task<AwardApplicationForm> GetOneAwardApplicationForm(int seasonNum, uint userId)
        {
            //int isGuildInt = isGuild ? 1 : 0;
            string sql = "select * from AwardApplicationForm where SeasonNum = " + seasonNum
                 + " and UserId = " + userId + " ;"
                ;
            List<AwardApplicationForm> rp = await _db.LoadData<AwardApplicationForm, dynamic>(sql, new { }, MysqlConnectionString);
            if (rp.Count == 1)
            {
                return rp[0];
            }
            else
            {
                return null;
            }
        }

        public Task InsertAward(AwardApplicationForm data , List<AwardNoticeView> AwardNoticeViews)
        {
            
            foreach(var view in AwardNoticeViews)
            {
                AwardDetail award = new AwardDetail();
                award.SeasonNum = view.SeasonNum;
                award.IsGuild = view.IsGuild;
                award.Station = view.Station;
                award.Place = view.Place;
                award.UserId = data.UserId;
                award.AwardStatus = 1;

                InsertAwardDetail(award);
            }

            data.CreateTime = DateTime.Now;
            string sql = @"insert into AwardApplicationForm (SeasonNum, UserId, UserName, Phone
                    , RealName, ContactNumber, Email, Address, ApplyStatus, CreateTime)
                values (@SeasonNum, @UserId, @UserName, @Phone
                    , @RealName, @ContactNumber, @Email , @Address, @ApplyStatus, @CreateTime);";

            return _db.SaveData<AwardApplicationForm>(sql, data, MysqlConnectionString);

        }

        public Task UpdateAward(AwardApplicationForm awardInfo)
        {
            string sql = @"update AwardApplicationForm 
                        set RealName = @RealName, ContactNumber = @ContactNumber, Email = @Email, Address = @Address 
                        , ApplyStatus = @ApplyStatus 
                        where SeasonNum = @SeasonNum and UserId = @UserId ;";

            return _db.SaveData<AwardApplicationForm>(sql, awardInfo, MysqlConnectionString);
        }

        public Task InsertAwardDetail(AwardDetail awardDetail)
        {
            awardDetail.CreateTime = DateTime.Now;
            string sql = @"insert into AwardDetail (SeasonNum, IsGuild, Station, Place, UserId, AwardStatus, CreateTime)
                values (@SeasonNum, @IsGuild, @Station, @Place, @UserId, @AwardStatus, @CreateTime);";

            return _db.SaveData<AwardDetail>(sql, awardDetail, MysqlConnectionString);
        }

    }
}
