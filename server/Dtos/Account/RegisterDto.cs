using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public string fullName { get; set; } = string.Empty;
        public DateTime dob { get; set; }
        public string sex { get; set; } = string.Empty;
        public string phone { get; set; }
    }
}