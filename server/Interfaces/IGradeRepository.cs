using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Interfaces
{
    public interface IGradeRepository
    {
        public async Task<CotDiem> GetbyLopIdAsync(CotDiem gradeModel);

        Task<CotDiem> CreateAsync(CotDiem gradeModel);


        Task<CotDiem> DelAsync(CotDiem gradeModel);


        Task<CotDiem> UpdateAsync(CotDiem gradeModel);

    }
}