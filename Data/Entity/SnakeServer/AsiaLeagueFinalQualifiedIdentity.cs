using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnakeAsianLeague.Data.Entity.SnakeServer
{
    public class AsiaLeagueFinalQualifiedIdentity
    {
        ///<summary> 無用的ID </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        ///<summary> 該實體的Id </summary>
        public int IdentityId { get; set; }
        ///<summary> 名次 </summary>
        public int Rank { get; set; }
        ///<summary> 是否是隊伍 </summary>
        public bool IsGuild { get; set; }
        ///<summary> 站數 </summary>
        public int Station { get; set; }
        ///<summary> 季數 </summary>
        public int SeasonNum { get; set; }
    }
}
