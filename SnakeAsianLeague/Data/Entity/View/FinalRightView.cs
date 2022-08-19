using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.View
{
    public class FinalRightView
    {
        /// <summary>
        /// 隊伍或個人
        /// </summary>
        public Boolean IsGuild { get; set; }

        ///<summary> 第幾站 </summary>
        public int Station { get; set; }


        /// <summary>
        /// 冠軍賽標題
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// 比賽日期
        /// </summary>
        public DateTime MatchDate { get; set; }


        /// <summary>
        /// 開戰時間
        /// </summary>
        public string startTime { get; set; }


    }
}
