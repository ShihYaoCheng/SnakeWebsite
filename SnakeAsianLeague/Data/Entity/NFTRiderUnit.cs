namespace SnakeAsianLeague.Data.Entity
{
    /// <summary>
    /// api /NFT/Unit 取得角色詳細By編號
    /// </summary>
    public class NFTRiderUnit
    {

        public string serialNumber { get; set; }

        public string name { get; set; }

        public double size { get; set; }

        public List<RiderUnit_Castings> castings { get; set; }

        public RiderUnit_Knight knight { get; set; }

        public RiderUnit_Snake snake { get; set; }

        public RiderUnit_Weapon weapon { get; set; }

        public RiderUnit_Pet pet { get; set; }

    }


    //public class RiderUnita
    //{
    //    public string serialNumber { get; set; }

    //    public string ppsr { get; set; }

    //    public int Level { get; set; }

    //    public int exp { get; set; }

    //    public double rent { get; set; }

    //    public string name { get; set; }

    //    public string winningPercentage { get; set; }

    //    public string appearancesCount { get; set; }

    //    public string isLove { get; set; }

    //    public string isNFT { get; set; }
    //}

    public class RiderUnit_Castings
    {
        /// <summary>
        /// TokenID 同PPSR
        /// </summary>
        public string TokenID { get; set; }
        /// <summary>
        /// NFT 合約地址
        /// </summary>
        public string nftAddress { get; set; }
        /// <summary>
        /// NFT 擁有者
        /// </summary>
        public string owner { get; set; }


        /// <summary>
        /// 遊戲端是否顯示
        /// </summary>
        public bool isAvailableInGame { get; set; }



        public int receiveCurrency { get; set; }

    }



    public class RiderUnit_Knight
    {
        public string serialNumber { get; set; }
        public string name { get; set; }

        public double hp { get; set; }

        public double atk { get; set; }

        public int occupationID { get; set; }

        public string skill { get; set; }
    }


    public class RiderUnit_Snake
    {
        public string serialNumber { get; set; }
        public string name { get; set; }

        public double hp { get; set; }

        public double atk { get; set; }

        public double agl { get; set; }

        public double con { get; set; }

        public double ms { get; set; }

        public string skill { get; set; }
    }

    public class RiderUnit_Weapon
    {
        public string serialNumber { get; set; }
        public string name { get; set; }

        public double autoATKRange { get; set; }

        public double atkRange { get; set; }

        public double @as { get; set; }

        public string attrEffect { get; set; }

        public double attrEffectValue { get; set; }

        public string skill { get; set; }
    }
    public class RiderUnit_Pet
    {
        public string serialNumber { get; set; }
        public string name { get; set; }
        public double hp { get; set; }
        public double atk { get; set; }
        public double agl { get; set; }
        public double @as { get; set; }
        public double ms { get; set; }
        public double con { get; set; }
        public double crit { get; set; }
        public string attrEffect { get; set; }

        public double attrEffectValue { get; set; }
        //"attrEffectValue": 0,
        public string skill { get; set; }
    }
}
