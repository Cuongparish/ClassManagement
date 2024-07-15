using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos.Teacher;
using server.Models;

namespace server.Mappers
{
    public static class TeacherMapper
    {
        public static TeacherDto ToTeacherDto(this GiaoVien teacherModel)
        {
            return new TeacherDto
            {
                userId = teacherModel.userId,
                id = teacherModel.id,
            };
        }

        public static GiaoVien ToTeacherFromCreateDTO(this CreateTeacherRequestDto teacherDto)
        {
            return new GiaoVien
            {
                userId = teacherDto.userId,
            };
        }

        public static TeacherClassDto ToTeacherClassDto(this GiaoVienLopHoc teacherClassModel)
        {
            return new TeacherClassDto
            {
                lopId = teacherClassModel.lopId,
                giaoVienId = teacherClassModel.giaoVienId,
            };
        }

        public static GiaoVienLopHoc ToTeacherClassFromCreateDTO(this CreateTeacherClassRequestDto teacherClassDto)
        {
            return new GiaoVienLopHoc
            {
                lopId = teacherClassDto.lopId,
                giaoVienId = teacherClassDto.giaoVienId,
            };
        }
    }
}