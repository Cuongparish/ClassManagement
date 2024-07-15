using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.User
{
    public class UserDto
    {
        public int id { get; set; }
        public string? email { get; set; } = string.Empty;
        public string? pw { get; set; } = string.Empty;
        public string? fullName { get; set; } = string.Empty;
        public DateTime? dob { get; set; }
        public string? sex { get; set; } = string.Empty;
        public string? phone { get; set; }
    }
}