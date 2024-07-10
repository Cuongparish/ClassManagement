using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    [Table("BangDiemThanhPhan")]

    public class BangDiemThanhPhan
    {
        [Key]
        public int hocSinhId { get; set; }
        public int cotDiemId { get; set; }
        // public CotDiem? CotDiem { get; set; }
        public int lopId { get; set; }
        // public List<User> Users { get; set; } = new List<User>();
        public float diem { get; set; }
        // public List<HocSinh> HocSinhs { get; set; } = new List<HocSinh>();
    }
}