using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Account
{
    public class ChangePwDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string OldPw { get; set; }
        [Required]
        public string NewPw { get; set; }
    }
}