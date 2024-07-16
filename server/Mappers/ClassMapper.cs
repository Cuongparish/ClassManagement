using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos.Class;
using server.Models;

namespace server.Mappers
{
    public static class ClassMapper
    {
        public static ClassDto ToClassDto(this LopHoc classModel)
        {
            return new ClassDto
            {
                tenLop = classModel.tenLop,
                chuDe = classModel.chuDe,
                phong = classModel.phong,
                maLop = classModel.maLop,
                state = classModel.state
            };
        }

        public static LopHoc ToClassFromCreateDTO(this CreateClassRequestDto classDto)
        {
            return new LopHoc
            {
                tenLop = classDto.tenLop,
                chuDe = classDto.chuDe,
                phong = classDto.phong,
                state = classDto.state
            };
        }
    }
}