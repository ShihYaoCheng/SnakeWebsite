namespace SnakeAsianLeague.Data.Entity
{
    public class NFTData
    {

        public string Number { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public double USD { get; set; }

        public string ImgPath { get; set; }

        public string Rare { get; set; }

        public string Class { get; set; }

        public string Profession { get; set; }

        public string Country { get; set; }

        public DateTime EndTime { get; set; }

        public string CalDays { get; set; }

        public bool IsOpen { get; set; }
    }
}
