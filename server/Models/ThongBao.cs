using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    [Table("ThongBao")]
    public class ThongBao
    {
        [Key]
        public int id { get; set; }

        public int lopId { get; set; }
        // public LopHoc? LopHoc { get; set; }
        public string noiDung { get; set; } = string.Empty;
        public DateTime thoiGian { get; set; }
        public int userId { get; set; }
        // public User? user { get; set; }
        public int phucKhaoId { get; set; }
        // public PhucKhao? phucKhao { get; set; }
    }
}