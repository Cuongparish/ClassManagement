using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Teacher
{
    public class CreateTeacherClassRequestDto
    {
        public int lopId { get; set; }
        public int giaoVienId { get; set; }
    }
}