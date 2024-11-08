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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int hocSinhId { get; set; }
        public int cotDiemId { get; set; }
        public int lopId { get; set; }
        public float diem { get; set; }
    }
}