namespace SnakeAsianLeague.Data.Entity
{
    public class RiderList
    {

        public List<RiderUnit> leaseUnits { get; set; }

        public List<RiderUnit> selfUnits { get; set; }

        public string fight { get; set; }
    }


    public class RiderUnit
    {
        public string serialNumber { get; set; }
        public string ppsr { get; set; }

        public int level { get; set; }

        public int exp { get; set; }

        public double rent { get; set; }

        public string name { get; set; }

        public string winningPercentage { get; set; }

        public int appearancesCount { get; set; }

        public bool isLove { get; set; }

        public bool isNFT { get; set; }


    }
}
