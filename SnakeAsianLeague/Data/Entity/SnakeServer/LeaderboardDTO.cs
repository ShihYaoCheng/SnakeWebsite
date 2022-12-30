namespace SnakeAsianLeague.Data.Entity.SnakeServer
{
    public class LeaderboardDTO
    {
        /// <summary> 標題 </summary>
        public string Title { get; set; }

        /// <summary> 開始時間 </summary>
        public DateTime StartTime { get; set; }

        /// <summary> 結束時間 </summary>
        public DateTime EndTime { get; set; }

        /// <summary> 自己的 </summary>
        public LeaderboardSingleData SelfLeaderboard { get; set; }
        /// <summary> 全部 </summary>
        public List<LeaderboardSingleData> TotalLeaderboard { get; set; }

    }
    public class LeaderboardSingleData
    {
        /// <summary> 排行 </summary>
        public int Ranking { get; set; }

        /// <summary> 玩家社群資料 </summary>
        public PlayerSimpleInformationDTO UserSocial { get; set; }

        /// <summary> 數量 </summary>
        public decimal Count { get; set; }
    }
    public class PlayerSimpleInformationDTO
    {
        /// <summary>流水號(目前是用在邀請，其餘皆為0)</summary>   
        public uint Index { get; set; }
        /// <summary>玩家ID</summary>
        public uint UserID { get; set; }

        /// <summary>會員的遊戲名稱</summary>
        public string Name { get; set; }

        /// <summary>等級</summary>
        public ushort Level { get; set; }

        /// <summary>選擇的頭像</summary>
        public ushort Avatar { get; set; }

        /// <summary>出戰單位(出戰騎士)的編號</summary>
        public string Unit { get; set; }

        /// <summary>單位等級</summary>
        public ushort UnitLevel { get; set; }

        /// <summary>出戰飛艇的編號</summary>
        public uint Airship { get; set; }

        /// <summary>飛艇等級</summary>
        public ushort AirshipLevel { get; set; }

        /// <summary> 上線狀態 </summary>
        public OnlineStates OnlineStates { get; set; }

        /// <summary> 最後上線時間 </summary>
        public DateTime LastOnlineTime { get; set; }

        /// <summary> 備註 </summary>
        public string Remark { get; set; }

    }
}
