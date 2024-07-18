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
            //create teacher
            await _context.GiaoViens.AddAsync(teacherModel);
            await _context.SaveChangesAsync();

            return teacherModel;
        }

        public async Task<GiaoVien?> IsExistsAsync(int userId)
        {
            var teacher = await _context.GiaoViens.FirstOrDefaultAsync(i => i.userId == userId);
            if (teacher == null)
            {
                return null;
            }
            return teacher;
        }

        public async Task<GiaoVien?> GetGiaoVienIdAsync(int userId)
        {
            var result = await _context.GiaoViens.FirstOrDefaultAsync(s => s.userId == userId);
            return result;
        }

        public async Task<List<GiaoVien?>> GetUserIdAsync(int[] giaoVienIds)
        {
            var users = await _context.GiaoViens
            .Where(s => giaoVienIds.Contains(s.id))
            .ToListAsync();
            return users.Cast<GiaoVien?>().ToList();
        }

        public async Task<GiaoVienLopHoc> CreateAsync(GiaoVienLopHoc giaoVienLopHocModel)
        {
            await _context.GiaoVienLopHocs.AddAsync(giaoVienLopHocModel);
            await _context.SaveChangesAsync();

            return giaoVienLopHocModel;
        }

        public async Task<List<GiaoVienLopHoc>> GetLopIdAsync(int giaoVienId)
        {
            var result = _context.GiaoVienLopHocs.AsQueryable();
            result = result.Where(s => s.giaoVienId == giaoVienId);
            return await result.ToListAsync();
        }

        public async Task<List<GiaoVienLopHoc>> GetAllGiaoVienIdAsync(int lopId)
        {
            var result = _context.GiaoVienLopHocs.AsQueryable();
            result = result.Where(s => s.lopId == lopId);
            return await result.ToListAsync();
        }

    }
}