using Microsoft.Extensions.Configuration;
using SnakeAsianLeague.Data.Entity.Backstage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Services.Backstage
{
    public class S2PrizeService
    {
        private readonly IDataAccess _db;
        private readonly IConfiguration _config;

        public S2PrizeService(IDataAccess db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public async Task<List<S2Prize>> GetSeasonPrizes(int seasonNum)
        {
            string sql = "select * from S2Prize where S2PrizeStatus = 1 and SeasonNum = "+ seasonNum + " ;";
            List<S2Prize> Prizes = await _db.LoadData<S2Prize, dynamic>(sql, new { }, _config.GetConnectionString("dev"));

            return Prizes;
        }

        public async Task<S2Prize> GetOnePrize(int seasonNum, int station, int place)
        {
            string sql = "select S2PrizeId, SeasonNum, Station, S2PrizePlace, PrizeName, S2PrizeStatus from S2Prize "
                + " where S2PrizeStatus = 1 and SeasonNum = " + seasonNum 
                + " and Station = " + station + " and S2PrizePlace = " + place + " ; ";

            List<S2Prize> Prizes = await _db.LoadData<S2Prize, dynamic>(sql, new { }, _config.GetConnectionString("dev"));

            if (Prizes.Count ==1)
            {
                return Prizes[0];
            }
            else
            {
                return null;

            }

        }

    }
}
