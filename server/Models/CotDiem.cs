using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    [Table("CotDiem")]
    public class CotDiem
    {
        [Key]
        public int id { get; set; }

        public int lopId { get; set; }

        // public LopHoc? LopHoc { get; set; }
        // public List<LopHoc> LopHocs { get; set; } = new List<LopHoc>();
        public string tenCotDiem { get; set; } = string.Empty;
        public float phanTramDiem { get; set; }
        public int khoa { get; set; }
        public bool acpPhucKhao { get; set; }

        // public List<BangDiemThanhPhan> BangDiemThanhPhans { get; set; } = new List<BangDiemThanhPhan>();


    }
}