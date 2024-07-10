using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    [Table("NoiDungTraoDoi")]
    public class NoiDungTraoDoi
    {
        [Key]
        public int id { get; set; }

        public int phucKhaoId { get; set; }
        // public PhucKhao? phucKhao { get; set; }
        // public List<PhucKhao> PhucKhaos { get; set; } = new List<PhucKhao>();

        public int userId { get; set; }
        // public User? user { get; set; }
        // public List<User> Users { get; set; } = new List<User>();
        public string noiDung { get; set; } = string.Empty;
        public DateTime thoiGian { get; set; }
    }
}