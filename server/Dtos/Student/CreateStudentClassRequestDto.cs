using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Student
{
    public class CreateStudentClassRequestDto
    {
        public int lopId { get; set; }
        public int hocSinhId { get; set; }
    }
}