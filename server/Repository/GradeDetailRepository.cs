using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dtos.GradeDetail;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository
{
    public class GradeDetailRepository
    {
        private readonly ApplicationDBContext _context;
        public GradeDetailRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        // public async Task<List<BangDiemThanhPhan?>> GetbyLopIdAsync(int lopId)
        // {
        //     // var grade = await _context.CotDiems.Where(g => g.lopId == lopId).ToListAsync();
        //     // if (grade == null)
        //     // {
        //     //     return null;
        //     // }
        //     // return grade;
        // }

    }
}