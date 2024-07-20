using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            var random = new Random();
            string chars = "123456789asdlkjqwepoizxcnbg";
            var result = new char[6];
            for (int i = 0; i < 6; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }

            classModel.maLop = new string(result);
            await _context.LopHocs.AddAsync(classModel);
            await _context.SaveChangesAsync();

            return classModel;
        }

        public async Task<List<LopHoc?>> GetByIdAsync(int[] ids)
        {
            var lopHocs = await _context.LopHocs
            .Where(s => ids.Contains(s.id))
            .ToListAsync();
            return lopHocs.Cast<LopHoc?>().ToList();
        }

        public async Task<LopHoc?> GetByIdAsync(int id)
        {
            return await _context.LopHocs.FirstOrDefaultAsync(i => i.id == id);
        }

        public async Task<LopHoc?> GetByMaLopAsync(string maLop)
        {
            return await _context.LopHocs.FirstOrDefaultAsync(i => i.maLop == maLop);
        }
    }
}