using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos.Grade;
using server.Models;

namespace server.Mappers
{
    public static class GradeMapper
    {
        public static GradeDto ToGradeDto(this CotDiem gradeModel)
        {
            return new GradeDto
            {

                lopId = gradeModel.lopId,
                tenCotDiem = gradeModel.tenCotDiem,
                phanTramDiem = gradeModel.phanTramDiem,
                khoa = gradeModel.khoa,
                acpPhucKhao = gradeModel.acpPhucKhao
            };
        }

        public static CotDiem ToGradeFromCreateDTO(this CreateGradeRequestDto gradeDto)
        {
            return new CotDiem
            {
                lopId = gradeDto.lopId,
                tenCotDiem = gradeDto.tenCotDiem,
                phanTramDiem = gradeDto.phanTramDiem,
                khoa = gradeDto.khoa,
                acpPhucKhao = gradeDto.acpPhucKhao
            };
        }
    }
}