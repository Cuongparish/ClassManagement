using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    [Table("HocSinh")]
    public class HocSinh
    {
        [Key]
        public int id { get; set; }

        public int userId { get; set; }
        // public List<User> Users { get; set; } = new List<User>();
        // public User? user { get; set; }
        public int studentId { get; set; }

        // public List<BangDiemThanhPhan> BangDiemThanhPhans { get; set; } = new List<BangDiemThanhPhan>();
    }
}