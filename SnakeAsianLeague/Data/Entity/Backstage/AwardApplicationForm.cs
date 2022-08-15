using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnakeAsianLeague.Data.Entity.Backstage
{
    public class AwardApplicationForm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint AwardApplicationFormId { get; set; }

        ///<summary> 第幾季 </summary>
        [Required]
        public int SeasonNum { get; set; }



        ///<summary> UserId </summary>
        [Required]
        public uint UserId { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "UserName too long")]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Phone too long")]
        public string Phone { get; set; }

        /// <summary>
        /// 本名
        /// </summary>
        [Required(ErrorMessage = "請填寫姓名")]
        [StringLength(20, ErrorMessage = "RealName too long")]
        public string RealName { get; set; }

        [Required(ErrorMessage = "請填寫聯絡電話")]
        [StringLength(20, ErrorMessage = "ContactNumber too long")]
        public string ContactNumber { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Email too long")]
        public string Email { get; set; }

        [Required(ErrorMessage = "請填寫地址")]
        [StringLength(100, ErrorMessage = "Address too long")]
        public string Address { get; set; }

        /// <summary>
        ///  0 未申請 ,1 申請開放 ,2.申請關閉
        /// </summary>
        [Required]
        public int ApplyStatus { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }
    }
}
