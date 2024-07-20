using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Data;
using server.Interfaces;
using server.Models;

namespace server.Repository
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDBContext _context;
        public GradeRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<CotDiem> CreateAsync(CotDiem gradeModel)
        {
            //create grade

            return gradeModel;
        }
    }
}