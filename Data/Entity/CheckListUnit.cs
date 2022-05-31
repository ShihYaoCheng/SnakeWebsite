namespace SnakeAsianLeague.Data.Entity
{
    public class CheckListUnit
    {
        public List<CheckList_RiderUnit> leaseUnits { get; set; }

        public List<CheckList_RiderUnit> selfUnits { get; set; }

        public string fight { get; set; }
    }

    public class CheckList_RiderUnit
    {
        public string serialNumber { get; set; }

        public string ppsr { get; set; }

        public int Level { get; set; }

        public int exp { get; set; }

        public double rent { get; set; }

        public string name { get; set; }

        public string winningPercentage { get; set; }

        public string appearancesCount { get; set; }

        public string isLove { get; set; }

        public string isNFT { get; set; }
    }
}
