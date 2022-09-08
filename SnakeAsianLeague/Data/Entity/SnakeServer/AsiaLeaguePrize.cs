using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.SnakeServer
{
    public class AsiaLeaguePrize
    {
        ///<summary> 沒用 </summary>
        public int ID;
        ///<summary> 沒用 </summary>
        public bool IsOpen;
        ///<summary> 日期 </summary>
        public bool IsGuild;
        ///<summary> 決賽類型(日0、周1、月2、季3) </summary>
        public int Type;
        ///<summary> 名次 </summary>
        public int Place;
        ///<summary> 獎金 </summary>
        public int Prize;

        public string Cash;

        public string Gifts;
    }
}
