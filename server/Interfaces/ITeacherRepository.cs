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
        Task<bool> IsExistsAsync(int userId);
    }
}