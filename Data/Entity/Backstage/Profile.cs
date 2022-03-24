using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.Backstage
{
    public class Profile
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint ProfileId { get; set; }

        ///<summary> UserId </summary>
        [Required]
        public uint UserId { get; set; }


        [Required]
        [StringLength(30, ErrorMessage = "UserName too long")]
        public string UserName { get; set; }

        [StringLength(20, ErrorMessage = "Phone too long")]
        public string Phone { get; set; }

        /// <summary>
        /// 本名
        /// </summary>
        [StringLength(20, ErrorMessage = "RealName too long")]
        public string RealName { get; set; }

        /// <summary>
        /// 您是否願意接受賽事採訪？
        /// </summary>
        public bool BeInterviewed { get; set; }

        /// <summary>
        /// 您是否願意適度公開得獎資訊？
        /// </summary>
        public bool OpenAwardInfo { get; set; }

        /// <summary>
        /// 對碰碰蛇想法
        /// </summary>
        public string IdeaOfSnake { get; set; }

        /// <summary>
        /// 對亞洲聯賽的建議
        /// </summary>
        public string Recommendation { get; set; }

        /// <summary>
        /// FB / IG連結
        /// </summary>
        [StringLength(100, ErrorMessage = "Link too long")]
        public string Link { get; set; }

        public char? Gender { get; set; }

        /// <summary>
        /// 出生年月日
        /// </summary>
        [Column(TypeName = "TIMESTAMP(6)")]
        public DateTime? DateOfBirth { get; set; }


        [StringLength(30, ErrorMessage = "Email too long")]
        public string Email { get; set; }

        [StringLength(15, ErrorMessage = "City too long")]
        public string City { get; set; }


        /// <summary>
        /// 自我介紹
        /// </summary>
        public string SelfIntroduction { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }

    }
}
