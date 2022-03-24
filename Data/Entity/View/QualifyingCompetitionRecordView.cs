using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.View
{
    public class QualifyingCompetitionRecordView
    {
        ///<summary> 排名 </summary>
        public int Rank { get; set; }

        ///<summary> 使用者暱稱 </summary>
        public string UserName { get; set; }

        ///<summary> 目標個體的Id(是團隊指的就是GuildId，個人的話就是指UserId) </summary>
        public int IdentityId { get; set; }

        ///<summary> 勝場 </summary>
        public int Wins { get; set; }


        public QualifyingCompetitionRecordView(int rank, string userName, int identityId, int wins) {
            this.Rank = rank;
            this.UserName = userName;
            this.IdentityId = identityId;
            this.Wins = wins;

        }

    }
}
