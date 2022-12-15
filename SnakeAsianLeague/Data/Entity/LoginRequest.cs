using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Entity
{
    public class LoginRequest
    {
        //[Required]
        //public string countryCode { get; set; }
        //[Required]
        public string phone { get; set; }
        [Required]
        public string password { get; set; }
    }

    
}
