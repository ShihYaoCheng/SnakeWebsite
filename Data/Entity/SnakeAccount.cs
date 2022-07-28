using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity
{
    public class SnakeAccount
    {
        public uint userID { get; set; }
        public string name { get; set; }

        public string phone { get; set; }

        public string walletAddress { get; set; }

        /// <summary>
        /// 帳戶騎士幣
        /// </summary>
        public double nftCurrency1 { get; set; }


        public bool IsLogin
        {
            get
            {
                return (userID != default || name != default);
            }
        }


    }
}
