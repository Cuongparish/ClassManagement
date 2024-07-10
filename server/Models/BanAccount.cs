using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    [Table("BanAccount")]
    public class BanAccount
    {
        [Key]
        public int userId { get; set; }
        public DateTime thoiGianBan { get; set; }
        public DateTime thoiHanKhoa { get; set; }

    }
}