using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Data;
using server.Interfaces;
using server.Models;

namespace server.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly ApplicationDBContext _context;
        public ClassRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<LopHoc> CreateAsync(LopHoc classModel)
        {
            //create class
            await _context.LopHocs.AddAsync(classModel);
            await _context.SaveChangesAsync();

            return classModel;
        }
    }
}