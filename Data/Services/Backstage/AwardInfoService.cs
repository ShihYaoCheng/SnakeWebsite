using Microsoft.Extensions.Configuration;
using SnakeAsianLeague.Data.Entity.Backstage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Services.Backstage
{
    public class AwardInfoService
    {
        private readonly IDataAccess _db;
        private readonly IConfiguration _config;

        public AwardInfoService(IDataAccess db, IConfiguration config) 
        {
            _db = db;
            _config = config;
        }

        public Task<List<AwardInfo>> GetAwardInfos()
        {
            string sql = "select * from AwardInfo";

            return _db.LoadData<AwardInfo, dynamic>(sql, new { }, _config.GetConnectionString("dev"));
        }

        public async Task<AwardInfo> GetOneAwardInfo(uint userId, string prizeCode, int place, bool isGuild, int station)
        {
            //int isGuildInt = isGuild ? 1 : 0;
            string sql = "select * from AwardInfo where UserId = " + userId 
                + " and PrizeCode = '" + prizeCode + "' and Place = " + place
                + " and IsGuild =" + isGuild + " and Station = " + station;
            List<AwardInfo> rp = await _db.LoadData<AwardInfo, dynamic>(sql, new { }, _config.GetConnectionString("dev"));
            if (rp.Count == 1)
            {
                return rp[0];
            }
            else
            {
                return null;
            }
        }

        public async Task<int> GetOneAwardInfoStatus(uint userId, string prizeCode, int place, bool isGuild, int station)
        {
            
            string sql = "select AwardStatus from AwardInfo where UserId = " + userId
                + " and PrizeCode = '" + prizeCode + "' and Place = " + place
                + " and IsGuild =" + isGuild + " and Station = " + station;
            List<int> rp = await _db.LoadData<int, dynamic>(sql, new { }, _config.GetConnectionString("dev"));
            if (rp.Count == 1)
            {
                return rp[0];
            }
            else
            {
                return 0;
            }
        }

        public Task InsertAwardInfo(AwardInfo awardInfo)
        {
            awardInfo.CreateTime = DateTime.Now;
            string sql = @"insert into AwardInfo (UserId, UserName, Phone, Place, IsGuild, Station, PrizeCode, PrizeContent
                    , RealName, ContactNumber, Email, Address, IdNumber , BankCode, BankAccount 
                    , Img1Name, Img1, Img2Name, Img2, BankName, BankImg, AwardStatus, CreateTime)
                    values (@UserId, @UserName, @Phone, @Place, @IsGuild, @Station, @PrizeCode, @PrizeContent
                    , @RealName, @ContactNumber, @Email , @Address, @IdNumber , @BankCode, @BankAccount
                    , @Img1Name, @Img1, @Img2Name, @Img2, @BankName, @BankImg, @AwardStatus, @CreateTime);";

            return _db.SaveData<AwardInfo>(sql, awardInfo, _config.GetConnectionString("dev"));
        }

        public Task UpdateAwardInfo(AwardInfo awardInfo)
        {
            string sql = @"update AwardInfo 
                        set RealName = @RealName, ContactNumber = @ContactNumber, Email = @Email, Address = @Address 
                        , IdNumber = @IdNumber , BankCode = @BankCode, BankAccount = @BankAccount , AwardStatus = @AwardStatus 
                        , Img1Name = @Img1Name, Img1 = @Img1 , Img2Name = @Img2Name, Img2 = @Img2, BankName = @BankName, BankImg = @BankImg 
                        where UserId = @UserId and PrizeCode = @PrizeCode and Place = @Place and IsGuild = @IsGuild and Station = @Station ;";
            
            return _db.SaveData<AwardInfo>(sql, awardInfo, _config.GetConnectionString("dev"));
        }

    }
}
