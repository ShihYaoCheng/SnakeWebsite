namespace SnakeAsianLeague.Data.Entity
{
    public class OptionKeyValue
    {
        public OptionKeyValue()
        {

        }

        public OptionKeyValue(string Key, string Value, string Datai18n)
        {
            this.Key = Key;
            this.Value = Value;
            this.Datai18n = Datai18n;
        }


        /// <summary>
        /// 
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Datai18n { get; set; }


        /// <summary>
        /// 取得預設稀有度
        /// </summary>
        /// <returns></returns>
        public List<OptionKeyValue> Get_Default_Rarity()
        {
            List<OptionKeyValue> List = new List<OptionKeyValue>();
            OptionKeyValue rd = new OptionKeyValue("1", "Advanced", "Filter.Advanced");
            List.Add(rd);
            rd = new OptionKeyValue("2", "Rarity", "Filter.Rarity");
            List.Add(rd);
            rd = new OptionKeyValue("3", "Epic", "Filter.Epic");
            List.Add(rd);
            rd = new OptionKeyValue("4", "Legend", "Filter.Legend");
            List.Add(rd);
            rd = new OptionKeyValue("5", "Abyss", "Filter.Abyss");
            List.Add(rd);
            rd = new OptionKeyValue("6", "Mythic ", "Filter.Mythic");
            List.Add(rd);
            return List;
        }

        /// <summary>
        /// 取得預設屬性
        /// </summary>
        /// <returns></returns>
        public List<OptionKeyValue> Get_Default_Elements()
        {
            List<OptionKeyValue> List = new List<OptionKeyValue>();
            OptionKeyValue rd = new OptionKeyValue("a", "Earth", "Filter.Earth");
            List.Add(rd);
            rd = new OptionKeyValue("b", "Water", "Filter.Water");
            List.Add(rd);
            rd = new OptionKeyValue("c", "Fire", "Filter.Fire");
            List.Add(rd);
            rd = new OptionKeyValue("d", "Wind", "Filter.Wind");
            List.Add(rd);
            //rd = new OptionKeyValue("e", "Light", "web_i18n_23");
            //List.Add(rd);
            //rd = new OptionKeyValue("f", "Dark", "web_i18n_24");
            //List.Add(rd);
            //rd = new OptionKeyValue("g", "Life", "web_i18n_25");
            //List.Add(rd);
            //rd = new OptionKeyValue("h", "Death", "web_i18n_26");
            //List.Add(rd);
            //rd = new OptionKeyValue("i", "Create", "web_i18n_27");
            //List.Add(rd);
            //rd = new OptionKeyValue("j", "Destroy ", "web_i18n_28");
            //List.Add(rd);
            //rd = new OptionKeyValue("k", "Time ", "web_i18n_29");
            //List.Add(rd);
            //rd = new OptionKeyValue("l", "Space ", "web_i18n_30");
            //List.Add(rd);
            return List;
        }

        /// <summary>
        /// 取得預設職業專精
        /// </summary>
        /// <returns></returns>
        public List<OptionKeyValue> Get_Default_Class()
        {
            List<OptionKeyValue> List = new List<OptionKeyValue>();
            OptionKeyValue rd = new OptionKeyValue("1", "Tank", "Filter.Tank");
            List.Add(rd);
            rd = new OptionKeyValue("2", "Protector", "Filter.Protector");
            List.Add(rd);
            rd = new OptionKeyValue("3", "Survival master", "Filter.Survival master");
            List.Add(rd);
            rd = new OptionKeyValue("4", "Fighter", "Filter.Fighter");
            List.Add(rd);
            rd = new OptionKeyValue("5", "Ranger", "Filter.Ranger");
            List.Add(rd);
            rd = new OptionKeyValue("6", "Archer", "Filter.Archer");
            List.Add(rd);
            rd = new OptionKeyValue("7", "Assassin", "Filter.Assassin");
            List.Add(rd);
            rd = new OptionKeyValue("8", "Support", "Filter.Support");
            List.Add(rd);
            rd = new OptionKeyValue("9", "Heal", "Filter.Heal");
            List.Add(rd);
            rd = new OptionKeyValue("10", "Control ", "Filter.Control");
            List.Add(rd);
            return List;
        }

        /// <summary>
        /// 取得預設國家
        /// </summary>
        /// <returns></returns>
        public List<OptionKeyValue> Get_Default_Country()
        {
            List<OptionKeyValue> List = new List<OptionKeyValue>();
            OptionKeyValue rd = new OptionKeyValue("1", "Archer", "");
            List.Add(rd);
            rd = new OptionKeyValue("2", "Necromancer", "");
            List.Add(rd);
            rd = new OptionKeyValue("3", "Cleric", "");
            List.Add(rd);
            rd = new OptionKeyValue("4", "Bard", "");
            List.Add(rd);
            rd = new OptionKeyValue("5", "Magician", "");
            List.Add(rd);
            rd = new OptionKeyValue("6", "Assassin", "");
            return List;
        }
    }


    public class OptionNameValue
    {
        public OptionNameValue()
        {

        }

        public OptionNameValue(string Name, int Value)
        {
            this.name = Name;
            this.value = Value;
        }


        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double value { get; set; }
      
    }
}
