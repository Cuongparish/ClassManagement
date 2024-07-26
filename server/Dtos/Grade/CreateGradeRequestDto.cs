using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Grade
{
    public class CreateGradeRequestDto
    {
        public string tenCotDiem { get; set; } = string.Empty;
        public float phanTramDiem { get; set; }
        public int khoa { get; set; }
        public bool acpPhucKhao { get; set; }
    }
}