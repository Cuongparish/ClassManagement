using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos.Grade;
using server.Dtos.GradeDetail;
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
        public static GradeDetailDto ToGradeDetailDto(this BangDiemThanhPhan gradeDetailModel)
        {
            return new GradeDetailDto
            {

                lopId = gradeDetailModel.lopId,
                cotDiemId = gradeDetailModel.cotDiemId,
                hocSinhId = gradeDetailModel.hocSinhId,
                diem = gradeDetailModel.diem,
            };
        }

        public static BangDiemThanhPhan ToGradeDetailFromCreateDTO(this CreateGradeDetailRequestDto gradeDetailDto)
        {
            return new BangDiemThanhPhan
            {
                lopId = gradeDetailDto.lopId,
                cotDiemId = gradeDetailDto.cotDiemId,
                hocSinhId = gradeDetailDto.hocSinhId,
                diem = gradeDetailDto.diem,
            };
        }
    }
}