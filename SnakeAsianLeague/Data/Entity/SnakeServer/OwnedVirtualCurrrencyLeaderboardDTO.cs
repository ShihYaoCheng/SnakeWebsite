namespace SnakeAsianLeague.Data.Entity.SnakeServer
{
    public class OwnedVirtualCurrrencyLeaderboardDTO
    {
        public OwnedLeaderboardSingleData SelfLeaderboard { get; set; }
        public List<OwnedLeaderboardSingleData>  OtherLeaderboardToSRC { get; set; }
        public List<OwnedLeaderboardSingleData> OtherLeaderboardToERNC { get; set; }

    }

    public class OwnedLeaderboardSingleData {
        public UserSocialDTO userSocial { get; set; }

        public decimal SRC { get; set; }

        public decimal ERNC { get; set; }
    }

    public class UserSocialDTO
    {

        public uint UserID { get; set; }

        public string Name { get; set; }
        public int Level { get; set; }
        public int Avatar { get; set; }

        public string SerialNumber { get; set; }

        public int UnitLevel { get; set; }

        public uint AirshipID { get; set; }

        public uint AirshipLevel { get; set; }

        public int PlayerGuildID { get; set; }

        public string SelfIntroduction { get; set; }

        public OnlineStates OnlineStates { get; set; }

        public DateTime? OnlineTime { get; set; }
        
        
        public DateTime? OfflineTime { get; set; }
    }
    public enum OnlineStates
    {
        // 離線
        Offline =0 ,
        // 上線
        Online = 1 ,
        // 戰鬥中
        Fighting = 2 ,

    }
}
