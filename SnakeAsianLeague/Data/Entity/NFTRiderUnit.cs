namespace SnakeAsianLeague.Data.Entity
{
    /// <summary>
    /// api /NFT/Unit 取得角色詳細By編號
    /// </summary>
    public class NFTRiderUnit
    {

        public string serialNumber { get; set; }

        public string name { get; set; }

        public float size { get; set; }

        public RiderUnit_Castings castings { get; set; }

        public RiderUnit_Knight? knight { get; set; }

        public RiderUnit_Snake? snake { get; set; }

        public RiderUnit_Weapon? weapon { get; set; }

        public RiderUnit_Pet? pet { get; set; }

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
        public string tokenId { get; set; }
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

        public float hp { get; set; }

        public float atk { get; set; }

        public int occupationID { get; set; }

        public string skill { get; set; }
    }


    public class RiderUnit_Snake
    {
        public string serialNumber { get; set; }
        public string name { get; set; }

        public float hp { get; set; }

        public float atk { get; set; }

        public float agl { get; set; }

        public float con { get; set; }

        public float ms { get; set; }

        public string skill { get; set; }
    }

    public class RiderUnit_Weapon
    {
        public string serialNumber { get; set; }
        public string name { get; set; }

        public float autoATKRange { get; set; }

        public float atkRange { get; set; }

        public float @as { get; set; }

        public string attrEffect { get; set; }

        public float attrEffectValue { get; set; }

        public string skill { get; set; }
    }
    public class RiderUnit_Pet
    {
        public string serialNumber { get; set; }
        public string name { get; set; }
        public float hp { get; set; }
        public float atk { get; set; }
        public float agl { get; set; }
        public float @as { get; set; }
        public float ms { get; set; }
        public float con { get; set; }
        public float crit { get; set; }
        public string attrEffect { get; set; }

        public float attrEffectValue { get; set; }
        //"attrEffectValue": 0,
        public string skill { get; set; }
    }
}
