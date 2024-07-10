using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    [Table("GiaoVienLopHoc")]
    public class GiaoVienLopHoc
    {
        [Key]
        public int lopId { get; set; }
        // public LopHoc? lopHoc { get; set; }
        // public List<LopHoc> LopHocs { get; set; } = new List<LopHoc>();

        public int giaoVienId { get; set; }
        // public List<GiaoVien> GiaoViens { get; set; } = new List<GiaoVien>();
        // public GiaoVien? giaoVien { get; set; }
    }
}