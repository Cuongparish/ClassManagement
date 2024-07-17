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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int lopId { get; set; }
        public int hocSinhId { get; set; }
    }
}