using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Interfaces
{
    public interface ITeacherRepository
    {
        Task<GiaoVien> CreateAsync(GiaoVien teacherModel);
        Task<GiaoVien?> IsExistsAsync(int userId);
        Task<GiaoVienLopHoc> CreateAsync(GiaoVienLopHoc giaoVienLopHocModel);
        Task<List<GiaoVienLopHoc>> GetLopIdAsync(int giaoVienId);
        Task<GiaoVien?> GetGiaoVienIdAsync(int userId);
    }
}