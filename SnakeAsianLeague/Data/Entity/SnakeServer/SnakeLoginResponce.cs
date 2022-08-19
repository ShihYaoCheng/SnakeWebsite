using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.SnakeServer
{
    public class SnakeLoginResponce
    {
        public uint userID { get; set; }
        public string userNumber { get; set; }
        public string guid { get; set; }
        public string name { get; set; }

        public string walletAddress { get; set; }

        public bool ban { get; set; }

        public string phoneID { get; set; }

        /// <summary>
        /// 帳戶騎士幣
        /// </summary>
        public double nftCurrency1 { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int vip { get; set; }



    }


}
