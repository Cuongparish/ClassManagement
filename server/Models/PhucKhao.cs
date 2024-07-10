using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    [Table("PhucKhao")]
    public class PhucKhao
    {
        [Key]
        public int phucKhaoId { get; set; }
        public DateTime thoiGian { get; set; }
        public float diemMongMuon { get; set; }
        public string noiDung { get; set; } = string.Empty;
        public float cotDiemId { get; set; }
        // public CotDiem? cotDiem { get; set; }
        // public List<CotDiem> CotDiems { get; set; } = new List<CotDiem>();
        public int lopId { get; set; }
        // public LopHoc? LopHoc { get; set; }
    }
}