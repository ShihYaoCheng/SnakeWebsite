using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.SnakeServer
{
    public class GuildMember
    {
        ///<summary> 玩家id </summary>
        public uint UserId { get; set; }
        ///<summary> 隊伍id </summary>
        public int GuildId { get; set; }
        ///<summary> 勝場 </summary>
        public int Wins { get; set; }
        ///<summary> 敗場 </summary>
        public int Losses { get; set; }
        ///<summary> 擊殺數 </summary>
        public int Kills { get; set; }
        ///<summary> 死亡數 </summary>
        public int Deaths { get; set; }
        ///<summary> 助攻數 </summary>
        public int Assists { get; set; }
        ///<summary> 分配到的隊伍票 </summary>
        public int AdmissionTickets { get; set; }
        ///<summary> 是否參加決賽 </summary>
        public int Participate { get; set; }
        ///<summary> 加入的時間 </summary>
        public DateTime JoinTime { get; set; }
        ///<summary> 最後打團體賽的時間 </summary>
        public DateTime LastFightDateTime { get; set; }

        /// <summary>
        /// 玩家暱稱
        /// </summary>
        public string Name { get; set; }

        public GuildMember()
        {
            Wins = 0;
            Losses = 0;
            AdmissionTickets = 0;
            Participate = 0;
            LastFightDateTime = DateTime.UtcNow.AddHours(-1);
        }
    }
}
