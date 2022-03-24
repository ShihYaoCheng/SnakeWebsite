using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.View
{
    public class AwardNoticeView
    {
        /// <summary>
        /// 領獎狀態
        /// </summary>
        public int AwardStatus { get; set; }
        ///<summary> 第幾季 </summary>
        public int SeasonNum { get; set; }

        ///<summary> 名次 </summary>
        public int Place { get; set; }

        ///<summary> 是否是團體賽 </summary>
        public bool IsGuild { get; set; }

        ///<summary> 第幾站 </summary>
        public int Station { get; set; }

        /// <summary>
        /// 領獎通知標題
        /// </summary>
        public string Title { get; set; }


        ///<summary> 獎品細項 </summary>
        public string PrizeContent { get; set; }

        ///<summary> 領獎編號 </summary>
        public string PrizeCode { get; set; }

        /// <summary>
        /// 比賽日期
        /// </summary>
        public DateTime MatchDate { get; set; }



    }
}
