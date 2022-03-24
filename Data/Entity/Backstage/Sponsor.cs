using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.Backstage
{
    public class Sponsor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint SponsorId { get; set; }


        [StringLength(100, ErrorMessage = "SponsorName too long")]
        public string SponsorName { get; set; }


        public int Type { get; set; }

        public int Sort { get; set; }



        /// <summary>
        /// 贊助商連結
        /// </summary>
        [Required(ErrorMessage = "請填寫贊助商連結")]
        public string SponsorUri { get; set; }


        /// <summary>
        /// 海報
        /// </summary>
        [Required(ErrorMessage = "請上傳海報")]
        public byte[] Img { get; set; }


        public string ImgUrl { get; set; }


        public int SponsorStatus { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }
    }
}
