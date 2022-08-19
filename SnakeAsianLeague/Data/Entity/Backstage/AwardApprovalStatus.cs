using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity.Backstage
{
    public enum AwardApprovalStatus
    {

        /// <summary> 未申請 </summary>
        NotApplied,
        /// <summary> 已申請 </summary>
        Applied,
        /// <summary> 審核中 </summary>
        Approving,
        /// <summary> 審核成功 </summary>
        Success,
        /// <summary> 審核失敗 </summary>
        Fail,
        /// <summary> 已領取 </summary>
        Received

    }
}
