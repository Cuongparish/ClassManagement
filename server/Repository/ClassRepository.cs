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
    }
}