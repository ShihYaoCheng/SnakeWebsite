using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.SnakeServer
{
    public class AsiaLeagueSchedule
    {
        ///<summary> 沒用的ID </summary>
        public int ID { get; set; }

        ///<summary> 沒用的是否公開flag </summary>
        public bool IsOpen { get; set; }

        ///<summary> 日期 </summary>
        public DateTime Date { get; set; }

        ///<summary> 個人賽賽程文字 </summary>
        public string IndividualSchedule { get; set; }

        ///<summary> 團體賽賽程文字 </summary>
        public string GuildSchedule { get; set; }

        // 2021-8-13新增
        ///<summary> 個人賽站數 </summary>
        public int IndStation { get; set; }

        ///<summary> 團體賽站數 </summary>
        public int GuildStation { get; set; }

        // 2021-8-13新增
        ///<summary> 這天是不是沒事 </summary>
        public bool NotEmpty { get; set; }

        ///<summary> 是否是個人賽發票日 </summary>
        public int IndATIssue { get; set; }

        ///<summary> 是否是團體賽發票日 </summary>
        public int GuildATIssue { get; set; }

        ///<summary> 個人賽的賽別(無-1、白銀個人0、月2、季3、公益4) </summary>
        public int IndGameType { get; set; }

        ///<summary> 團體賽的賽別(無-1、白銀團體1、月2、季3、公益4) </summary>
        public int GuildGameType { get; set; }

        ///<summary> 個人決賽的類型(-1無、0日、2月、3季) </summary>
        public int IndFinalType { get; set; }

        ///<summary> 團體決賽的類型(-1無、1周、2月、3季) </summary>
        public int GuildFinalType { get; set; }

        // 2021-8-13新增 
        ///<summary> 個人決賽，由資格賽第一名打第四名的時間 </summary>
        public string IndFinal1V4Time { get; set; }

        ///<summary> 個人決賽，由資格賽第二名打第三名的時間 </summary>
        public string IndFinal2V3Time { get; set; }

        ///<summary> 個人決賽的季軍賽時間 </summary>
        public string IndFinalThirdPlaceTime { get; set; }

        ///<summary> 個人決賽的冠軍賽時間 </summary>
        public string IndFinalFirstPlaceTime { get; set; }

        ///<summary> 團體決賽，由資格賽第一名打第四名的時間 </summary>
        public string GuildFinal1V4Time { get; set; }

        ///<summary> 團體決賽，由資格賽第二名打第三名的時間 </summary>
        public string GuildFinal2V3Time { get; set; }

        ///<summary> 團體決賽的季軍賽時間 </summary>
        public string GuildFinalThirdPlaceTime { get; set; }

        ///<summary> 團體決賽的冠軍賽時間 </summary>
        public string GuildFinalFirstPlaceTime { get; set; }

        // 2021-8-13新增

        //2022-06-28 S7 更改為統一時間欄位
        ///<summary> 個人決賽時間 </summary>
        public string IndFinalTime { get; set; }

        ///<summary> 團體決賽時間 </summary>
        public string GuildFinalTime { get; set; }
    }
}
