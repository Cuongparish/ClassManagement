using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    [Table("LopHoc")]
    public class LopHoc
    {
        [Key]
        public int id { get; set; }
        public string tenLop { get; set; } = string.Empty;
        public string chuDe { get; set; } = string.Empty;
        public string phong { get; set; } = string.Empty;
        public string maLop { get; set; } = string.Empty;
        public bool state { get; set; } = false;
        // public List<CotDiem> CotDiems { get; set; } = new List<CotDiem>();
    }
}