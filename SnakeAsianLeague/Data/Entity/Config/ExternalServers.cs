using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.Config
{
    public class ExternalServers
    {
        public Uri UserServer { get; set; }
        public Uri TableServer { get; set; }

        public Uri BackstageApiServer { get; set; }

        public Uri NftWebApi { get; set; }
    }
}
