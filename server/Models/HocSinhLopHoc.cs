using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    [Table("HocSinhLopHoc")]
    public class HocSinhLopHoc
    {
        [Key]
        public int lopId { get; set; }
        // public LopHoc? LopHoc { get; set; }
        // public List<LopHoc> LopHocs { get; set; } = new List<LopHoc>();

        public int hocSinhId { get; set; }
        // public HocSinh? hocSinh { get; set; }
        // public List<HocSinh> HocSinhs { get; set; } = new List<HocSinh>();
    }
}