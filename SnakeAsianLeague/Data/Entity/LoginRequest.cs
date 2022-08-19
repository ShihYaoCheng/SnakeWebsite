using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity
{
    public class LoginRequest
    {
        public string phone { get; set; }
        public string password { get; set; }
    }
}
