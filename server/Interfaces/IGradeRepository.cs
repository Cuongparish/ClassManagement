using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos.Grade;
using server.Models;

namespace server.Interfaces
{
    public interface IGradeRepository
    {
        Task<List<CotDiem?>> GetbyLopIdAsync(int lopId);
        Task<CotDiem> CreateAsync(CotDiem gradeModel);
        Task<CotDiem> DelAsync(int id);
        Task<CotDiem?> UpdateAsync(UpdateGradeRequestDto gradeDto);
        Task<List<CotDiem>> GradeComponentAsync(int lopId);
        Task<List<BangDiemThanhPhan>> GradeDetailAsync(int lopId, int[] hocSinhIds);

    }
}