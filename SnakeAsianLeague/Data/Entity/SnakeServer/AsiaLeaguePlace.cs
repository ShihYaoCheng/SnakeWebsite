using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.SnakeServer
{
    
    public class AsiaLeaguePlace
    {
        ///<summary> 毫無用處的pk </summary>
        public int PlaceId { get; set; }
        ///<summary> 第幾站 </summary>
        public int Station { get; set; }
        ///<summary> 日期 </summary>
        public DateTime Date { get; set; }
        ///<summary> 名次 </summary>
        public int Place { get; set; }
        ///<summary> winner Id，個人的話就是UserId，團體的話就是GuildId </summary>
        public int WinnerId { get; set; }
        ///<summary> 是否是團體賽 </summary>
        public bool IsGuild { get; set; }
        ///<summary> 比賽類型(日、周、月、季)，基本上用AsiaLeaguePlaceType來轉換 </summary>
        public int Type { get; set; }
        ///<summary> 領獎編號 </summary>
        public string PrizeCode { get; set; }
        ///<summary> 第幾季 </summary>
        public int SeasonNum { get; set; }

        /// <summary>
        /// 贏家遊戲暱稱, 可能是個人或隊伍
        /// </summary>
        public string WinnerName { get; set; }

        /// <summary>
        /// 團隊代號
        /// </summary>
        public string GuildAbbrevation { get; set; }


    }
}
