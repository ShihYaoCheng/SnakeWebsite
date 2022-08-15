using SnakeAsianLeague.Data.Entity.SnakeServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.View
{
    public class AsiaLeaguePlaceView
    {
        public AsiaLeaguePlace Place { get; set; }


        public List<GuildMember> Members { get; set; }

        public AsiaLeaguePlaceView(AsiaLeaguePlace place , List<GuildMember> members) 
        {
            this.Place = place;
            this.Members = members;
        }
    }
}
