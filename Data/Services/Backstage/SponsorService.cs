using Microsoft.Extensions.Configuration;
using SnakeAsianLeague.Data.Entity.Backstage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Services.Backstage
{
    public class SponsorService
    {
        private readonly IDataAccess _db;
        private readonly IConfiguration _config;

        public SponsorService(IDataAccess db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public Task<List<Sponsor>> GetSponsors()
        {
            string sql = "select * from Sponsor where SponsorStatus = 1 ;";

            return _db.LoadData<Sponsor, dynamic>(sql, new { }, _config.GetConnectionString("dev"));
        }

        public Task<List<Sponsor>> GetSponsorsByType(int type)
        {
            string sql = "select * from Sponsor where SponsorStatus = 1 and Type = " + type
                + " order by Sort ;";

            return _db.LoadData<Sponsor, dynamic>(sql, new { }, _config.GetConnectionString("dev"));
        }

    }
}
