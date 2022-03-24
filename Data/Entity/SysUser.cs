using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity
{
    public class SysUser
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public int Authority { get; set; }
        public string PW { get; set; }

        public DateTime CreateDate { get; set; }
        public short Enable { get; set; }


    }
}
