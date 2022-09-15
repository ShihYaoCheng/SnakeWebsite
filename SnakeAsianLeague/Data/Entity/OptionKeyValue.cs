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
            OptionKeyValue rd = new OptionKeyValue("1", "Advanced", "web_i18n_12");
            List.Add(rd);
            rd = new OptionKeyValue("2", "Rare", "web_i18n_13");
            List.Add(rd);
            rd = new OptionKeyValue("3", "Epic", "web_i18n_14");
            List.Add(rd);
            rd = new OptionKeyValue("4", "Legend", "web_i18n_15");
            List.Add(rd);
            rd = new OptionKeyValue("5", "Abyss", "web_i18n_16");
            List.Add(rd);
            rd = new OptionKeyValue("6", "Mythic ", "web_i18n_17");
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
            OptionKeyValue rd = new OptionKeyValue("a", "Earth", "web_i18n_19");
            List.Add(rd);
            rd = new OptionKeyValue("b", "Water", "web_i18n_20");
            List.Add(rd);
            rd = new OptionKeyValue("c", "Fire", "web_i18n_21");
            List.Add(rd);
            rd = new OptionKeyValue("d", "Wind", "web_i18n_22");
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
            OptionKeyValue rd = new OptionKeyValue("1", "Tank", "web_i18n_32");
            List.Add(rd);
            rd = new OptionKeyValue("2", "Protector", "web_i18n_33");
            List.Add(rd);
            rd = new OptionKeyValue("3", "Survival master", "web_i18n_34");
            List.Add(rd);
            rd = new OptionKeyValue("4", "Fighter", "web_i18n_35");
            List.Add(rd);
            rd = new OptionKeyValue("5", "Ranger", "web_i18n_36");
            List.Add(rd);
            rd = new OptionKeyValue("6", "Archer", "web_i18n_37");
            List.Add(rd);
            rd = new OptionKeyValue("7", "Assassin", "web_i18n_38");
            List.Add(rd);
            rd = new OptionKeyValue("8", "Support", "web_i18n_39");
            List.Add(rd);
            rd = new OptionKeyValue("9", "Heal", "web_i18n_40");
            List.Add(rd);
            rd = new OptionKeyValue("10", "Control ", "web_i18n_41");
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
