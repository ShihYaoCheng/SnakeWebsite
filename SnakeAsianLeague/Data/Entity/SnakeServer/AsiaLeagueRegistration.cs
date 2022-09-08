using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.SnakeServer
{
    public class AsiaLeagueRegistration
    {
        ///<summary> 毫無用處的pk </summary>
        public int RegistrationId { get; set; }
        ///<summary> UserId </summary>
        public uint UserId { get; set; }
        ///<summary> 亞洲聯賽賽季Id(個人、團隊 x 全季、中季、星光季) </summary>
        public int AsiaLeagueSeasonId { get; set; }
        ///<summary> 購買報名時的訂單SerialNum </summary>
        public int? OrderSerialNum { get; set; }
        ///<summary> 第幾季 </summary>
        public int SeasonNum { get; set; }

    }


    ///<summary> 亞洲聯賽季別的列舉 </summary>
    public enum AsiaLeagueSeason1Enum
    {
        ///<summary> 個人全季 </summary>
        IndAllSeason,
        ///<summary> 個人季中 </summary>
        IndMiddleSeason,
        ///<summary> 個人星光季 </summary>
        IndStarlightSeason,
        ///<summary> 個人公益 </summary>
        IndFree,
        ///<summary> 隊伍全季 </summary>
        GuildAllSeason,
        ///<summary> 隊伍季中 </summary>
        GuildMiddleSeason,
        ///<summary> 隊伍星光季 </summary>
        GuildStarlightSeason,
        ///<summary> 團體公益 </summary>
        GuildFree,
    }

}
