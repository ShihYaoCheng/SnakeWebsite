using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.SnakeServer
{
    ///<summary> 資格賽的紀錄 </summary>
    public class QualifyingCompetitionRecord
    {
        ///<summary> 毫無用處的pk </summary>
        public int QualifyingCompetitionRecordId { get; set; }
        ///<summary> 是否是團隊 </summary>
        public bool IsGuild { get; set; }
        ///<summary> 目標個體的Id(是團隊指的就是GuildId，個人的話就是指UserId) </summary>
        public int IdentityId { get; set; }
        ///<summary> 紀錄時間 </summary>
        public DateTime Date { get; set; }
        ///<summary> 勝場 </summary>
        public int Wins { get; set; }
        ///<summary> 敗場 </summary>
        public int Losses { get; set; }
        ///<summary> 擊殺 </summary>
        public int Kills { get; set; }
        ///<summary> 死亡 </summary>
        public int Deaths { get; set; }
        ///<summary> 助攻 </summary>
        public int Assists { get; set; }
        ///<summary> 站數 </summary>
        public int Station { get; set; }
        ///<summary> 季數 </summary>
        public int SeasonNum { get; set; }

        ///<summary> 玩家暱稱 </summary>
        public string IdentityName { get; set; }

        public string GuildAbbrevation { get; set; }

        /// <summary>
        /// 資格賽名次
        /// </summary>
        public int Rank { get; set; }



        public QualifyingCompetitionRecord()
        {
            Wins = 0;
            Losses = 0;
            Kills = 0;
            Deaths = 0;
            Assists = 0;
        }
    }
}
