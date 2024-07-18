using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Interfaces
{
    public interface IClassRepository
    {
        Task<LopHoc> CreateAsync(LopHoc classModel);
        Task<List<LopHoc?>> GetByIdAsync(int[] ids);
        Task<LopHoc?> GetByIdAsync(int id);
    }
}