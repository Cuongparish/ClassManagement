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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int lopId { get; set; }
        public int giaoVienId { get; set; }
    }
}