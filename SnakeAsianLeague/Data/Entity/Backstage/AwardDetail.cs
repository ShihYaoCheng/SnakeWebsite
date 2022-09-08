using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnakeAsianLeague.Data.Entity.Backstage
{
    public class AwardDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint AwardDetailId { get; set; }

        ///<summary> 第幾季 </summary>
        [Required]
        public int SeasonNum { get; set; }

        ///<summary> 是否是團體賽 </summary>
        [Required]
        public bool IsGuild { get; set; }


        ///<summary> 第幾站 </summary>
        [Required]
        public int Station { get; set; }

        ///<summary> 名次 </summary>
        [Required]
        public int Place { get; set; }

        ///<summary> UserId </summary>
        [Required]
        public uint UserId { get; set; }



        /// <summary>
        ///  0 未申請 ,1 已申請 ,2.審核中, 3審核成功 ,4 審核失敗 , 5已領取
        /// </summary>
        [Required]
        public int AwardStatus { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }
    }
}
