using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.SnakeServer
{
    public class Guild
    {
        ///<summary> 隊伍ID </summary> 
        public int GuildId { get; set; }
        ///<summary> 隊伍名稱 </summary>
        public string GuildName { get; set; }
        ///<summary> 隊伍等級 </summary>
        public int GuildLvl { get; set; }
        ///<summary> 隊伍經驗值 </summary>
        public long GuildExp { get; set; }
        ///<summary> 隊伍審核模式 </summary>
        public int GuildAuditMode { get; set; }
        ///<summary> 隊伍隊長UserId </summary>
        public uint GuildLeaderUserId { get; set; }
        ///<summary> 隊伍決賽資格 </summary>
        public int GuildFinalQualification { get; set; }
        ///<summary> 隊伍排名 </summary>
        public int GuildRank { get; set; }
        /////<summary> 隊伍勝場數 </summary>
        //public int GuildWins { get; set; }
        /////<summary> 隊伍敗場數 </summary>
        //public int GuildLosses { get; set; }
        ///<summary> 隊伍擁有隊伍票 </summary>
        public int GuildAdmissionTicket { get; set; }
        ///<summary> 隊伍申請入隊玩家們的ID </summary>
        public string GuildApplicationIds { get; set; }
        ///<summary> 隊伍邀請入隊玩家們的ID </summary>
        public string GuildInvitationIds { get; set; }
        ///<summary> 隊伍創隊時間 </summary>
        public DateTime GuildCreateTime { get; set; }
        ///<summary> 隊伍英文縮寫(據說是三個字) </summary>
        public string GuildAbbreviation { get; set; }
        ///<summary> 隊伍目前人數 </summary>
        public uint GuildMemberCounts { get; set; }
    }
}
