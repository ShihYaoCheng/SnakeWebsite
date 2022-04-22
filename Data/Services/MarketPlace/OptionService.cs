using SnakeAsianLeague.Data.Entity;

namespace SnakeAsianLeague.Data.Services.MarketPlace
{
    public class OptionService
    {
        public List<string> RareList = new List<string>() { "N", "R", "SR", "SSR", "UR", "UUR" };

        public List<string> ClassList = new List<string>() { "Land", "Water", "Wind", "Fire" };

        public List<string> ProfessionList = new List<string>() { "Archer", "Necromancer", "Cleric", "Bard", "Magician", "Assassin", "Gunner", "Gladiator", "Dragoon" };

        public List<string> CountryList = new List<string>() { "Archer", "Necromancer", "Cleric", "Bard", "Magician", "Assassin" };

        List<NFTData> datas;
        public async Task<List<string>> GetRareList()
        {
            return RareList;
        }

        public async Task<List<string>> GetClassList()
        {
            return ClassList;
        }

        public async Task<List<string>> GetProfessionList()
        {
            return ProfessionList;
        }

        public async Task<List<string>> GetCountryList()
        {
            return CountryList;
        }





        public async Task<List<NFTData>> GetNFTDataList()
        {
            datas = new List<NFTData>();


            Random myObject = new Random();



            for (int i = 0; i < 10; i++)
            {

                int value = myObject.Next(1, 1000);
                int RareInt = value % RareList.Count();
                int ClassInt = value % ClassList.Count();
                int ProfessionInt = value % RareList.Count();
                int CountryInt = value % RareList.Count();

                NFTData data = new NFTData();
                data.Number = value;
                data.Name = value.ToString() + "-" + ProfessionList[ProfessionInt].ToString();
                data.Price = myObject.Next(value, value * 10);
                data.USD = myObject.Next(value, value * 10) * 30;
                data.ImgPath = "/images/MarketPlace/ERNC.png";
                data.Rare = RareList[RareInt].ToString();
                data.Class = ClassList[ClassInt].ToString();
                data.Profession = ProfessionList[ProfessionInt].ToString();
                data.Country = CountryList[CountryInt].ToString();
                data.EndTime = DateTime.Now.AddDays(value);
                datas.Add(data);
            }

            datas = datas.OrderBy(m => m.Number).ToList();
            return datas;
        }

        public async Task<List<NFTData>> NFTDataListOrderby(string OrderByString)
        {
            if (OrderByString == "Highest Earned" || OrderByString == "Sort")
            {
                datas = datas.OrderBy(m => m.Number).ToList();
            }
            if (OrderByString == "Lowest Earned")
            {
                datas = datas.OrderByDescending(m => m.Number).ToList();
            }
            if (OrderByString == "Highest Price")
            {
                datas = datas.OrderBy(m => m.Price).ToList();
            }
            if (OrderByString == "Lowest Price")
            {
                datas = datas.OrderByDescending(m => m.Price).ToList();
            }
            if (OrderByString == "Newest")
            {
                datas = datas.OrderBy(m => m.EndTime).ToList();
            }
            if (OrderByString == "Oldest")
            {
                datas = datas.OrderByDescending(m => m.EndTime).ToList();
            }
            return datas;
        }
    }
}
