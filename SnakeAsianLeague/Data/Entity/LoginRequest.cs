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
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
    }

    
}
