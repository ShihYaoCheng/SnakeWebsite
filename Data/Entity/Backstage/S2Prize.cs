using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnakeAsianLeague.Data.Entity.Backstage
{
    public class S2Prize
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint S2PrizeId { get; set; }

        ///<summary> 第幾季 </summary>
        public int SeasonNum { get; set; }

        ///<summary> 第幾站 </summary>
        public int Station { get; set; }

        ///<summary> 名次 </summary>
        public int S2PrizePlace { get; set; }


        ///<summary> 獎品名稱 </summary>
        [StringLength(100, ErrorMessage = "PrizeName too long")]
        public string? PrizeName { get; set; }

        ///<summary> 獎品圖片 </summary>
        [Required(ErrorMessage = "請上傳獎品圖片")]
        public string ImgUrl { get; set; }

        public int S2PrizeStatus { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }

    }
}
