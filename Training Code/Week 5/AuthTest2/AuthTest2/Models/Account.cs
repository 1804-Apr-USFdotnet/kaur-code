using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthTest2.Models
{
    public class Account
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(64, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 64 characters.")]
        public string Password { get; set; }
    }
}
