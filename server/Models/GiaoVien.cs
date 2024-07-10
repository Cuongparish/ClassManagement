using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    [Table("GiaoVien")]
    public class GiaoVien
    {
        [Key]
        public int id { get; set; }

        public int userId { get; set; }
        // public List<User> users { get; set; } = new List<User>();
        public User? user { get; set; }
    }
}