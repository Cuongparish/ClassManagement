using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos.Student;
using server.Models;

namespace server.Mappers
{
    public static class StudentMapper
    {
        public static StudentDto ToStudentDto(this HocSinh studentModel)
        {
            return new StudentDto
            {
                userId = studentModel.userId,
                id = studentModel.id,
                studentId = studentModel.studentId
            };
        }

        public static HocSinh ToStudentFromCreateDTO(this CreateStudentRequestDto studentDto)
        {
            return new HocSinh
            {
                userId = studentDto.userId,
                studentId = studentDto.studentId
            };
        }

        public static StudentClassDto ToStudentClassDto(this HocSinhLopHoc studentClassModel)
        {
            return new StudentClassDto
            {
                lopId = studentClassModel.lopId,
                hocSinhId = studentClassModel.hocSinhId,
            };
        }

        public static HocSinhLopHoc ToStudentClassFromCreateDTO(this CreateStudentClassRequestDto studentClassDto)
        {
            return new HocSinhLopHoc
            {
                lopId = studentClassDto.lopId,
                hocSinhId = studentClassDto.hocSinhId,
            };
        }
    }
}