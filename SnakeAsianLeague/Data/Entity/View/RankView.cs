using SnakeAsianLeague.Data.Entity.SnakeServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.View
{
    public class RankView
    {
        /// <summary>
        /// 隊伍或個人
        /// </summary>
        public Boolean IsGuild { get; set; }

        /// <summary>
        /// 第幾站
        /// </summary>
        public int Station { get; set; }

        /// <summary>
        /// 冠軍賽種類
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 冠軍賽標題
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 比賽日期
        /// </summary>
        public DateTime MatchDate { get; set; }

        /// <summary>
        /// 冠軍賽獲獎清單
        /// </summary>
        public List<AsiaLeaguePlaceView> Places { get; set; }

        /// <summary>
        /// 資格賽積分排名
        /// </summary>
        public List<QualifyingCompetitionRecordView> Records { get; set; }

        /// <summary>
        /// 資格賽日期
        /// </summary>
        public List<DateTime> QualifyingDates { get; set; }

    }
}
