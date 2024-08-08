using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.GradeDetail
{
    public class GradeDetailDto
    {
        public int hocSinhId { get; set; }
        public int cotDiemId { get; set; }
        public int lopId { get; set; }
        public float diem { get; set; }

    }
}