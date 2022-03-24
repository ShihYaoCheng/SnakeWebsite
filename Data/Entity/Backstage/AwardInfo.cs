using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.Backstage
{
    public class AwardInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint AwardInfoId { get; set; }


        ///<summary> UserId </summary>
        [Required]
        public uint UserId { get; set; }


        [Required]
        [StringLength(30, ErrorMessage = "UserName too long")]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Phone too long")]
        public string Phone { get; set; }


        ///<summary> 名次 </summary>
        [Required]
        public int Place { get; set; }


        ///<summary> 是否是團體賽 </summary>
        [Required]
        public bool IsGuild { get; set; }


        ///<summary> 第幾站 </summary>
        [Required]
        public int Station { get; set; }


        /// <summary>
        /// 獲獎編號
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "PrizeCode too long")]
        public string PrizeCode { get; set; }

        /// <summary>
        /// 獎品細項
        /// </summary>
        [Required]
        [StringLength(200, ErrorMessage = "PrizeContent too long")]
        public string PrizeContent { get; set; }


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
        [StringLength(50, ErrorMessage = "Address too long")]
        public string Address { get; set; }

        [Required(ErrorMessage = "請填寫身分證字號")]
        [StringLength(12, ErrorMessage = "IdNumber too long")]
        public string IdNumber { get; set; }

        [Required(ErrorMessage = "請填寫銀行代碼")]
        [StringLength(5, ErrorMessage = "BankCode too long")]
        public string BankCode { get; set; }

        [Required(ErrorMessage = "請填寫銀行帳號")]
        [StringLength(30, ErrorMessage = "BankAccount too long")]
        public string BankAccount { get; set; }

        [Required(ErrorMessage = "請上傳身分證正反面")]
        [StringLength(50, ErrorMessage = "Img1Name too long")]
        public string Img1Name { get; set; }

        /// <summary>
        /// 身分證正反面
        /// </summary>
        public byte[] Img1 { get; set; }

        public string Img1Url { get; set; }

        [Required(ErrorMessage = "請上傳身分證正反面")]
        [StringLength(50, ErrorMessage = "Img1Name too long")]
        public string Img2Name { get; set; }
        public byte[] Img2 { get; set; }

        public string Img2Url { get; set; }

        [Required(ErrorMessage = "請上傳銀行存簿正面")]
        public string BankName { get; set; }
        public byte[] BankImg { get; set; }

        public string BankImgUrl { get; set; }

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
