using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; } = string.Empty;
        public string pw { get; set; } = string.Empty;
        public string fullName { get; set; } = string.Empty;
        public DateTime dob { get; set; }
        public string sex { get; set; } = string.Empty;
        public int phone { get; set; }
    }
}