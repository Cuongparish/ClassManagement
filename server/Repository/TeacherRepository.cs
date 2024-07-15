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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDBContext _context;
        public TeacherRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<GiaoVien> CreateAsync(GiaoVien teacherModel)
        {
            //create class
            await _context.GiaoViens.AddAsync(teacherModel);
            await _context.SaveChangesAsync();

            return teacherModel;
        }

        // public async Task<GiaoVien> IsExistsAsync(GiaoVien teacherModel)
        // {
        //     //create class
        //     await _context.GiaoViens.AddAsync(teacherModel);
        //     await _context.SaveChangesAsync();

        //     return teacherModel;
        // }

        public async Task<GiaoVien?> IsExistsAsync(int userId)
        {
            var teacher = await _context.GiaoViens.FirstOrDefaultAsync(i => i.userId == userId);
            if (teacher == null)
            {
                return null;
            }
            return teacher;
        }

        public async Task<GiaoVienLopHoc> CreateAsync(GiaoVienLopHoc giaoVienLopHocModel)
        {
            await _context.GiaoVienLopHocs.AddAsync(giaoVienLopHocModel);
            await _context.SaveChangesAsync();

            return giaoVienLopHocModel;
        }


    }
}