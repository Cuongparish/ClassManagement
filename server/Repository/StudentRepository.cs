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
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDBContext _context;
        public StudentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<HocSinh> CreateAsync(HocSinh studentModel)
        {
            //create student
            await _context.HocSinhs.AddAsync(studentModel);
            await _context.SaveChangesAsync();

            return studentModel;
        }

        public async Task<HocSinh?> IsExistsAsync(int userId)
        {
            var student = await _context.HocSinhs.FirstOrDefaultAsync(i => i.userId == userId);
            if (student == null)
            {
                return null;
            }
            return student;
        }

        public async Task<HocSinh?> GetHocSinhIdAsync(int userId)
        {
            var result = await _context.HocSinhs.FirstOrDefaultAsync(s => s.userId == userId);
            return result;
        }

        public async Task<List<HocSinh?>> GetUserIdAsync(int[] hocsinhIds)
        {
            var users = await _context.HocSinhs
            .Where(s => hocsinhIds.Contains(s.id))
            .ToListAsync();
            return users.Cast<HocSinh?>().ToList();
        }

        public async Task<HocSinhLopHoc> CreateAsync(HocSinhLopHoc hocSinhLopHocModel)
        {
            await _context.HocSinhLopHocs.AddAsync(hocSinhLopHocModel);
            await _context.SaveChangesAsync();

            return hocSinhLopHocModel;
        }

        public async Task<List<HocSinhLopHoc>> GetLopIdAsync(int hocSinhId)
        {
            var result = _context.HocSinhLopHocs.AsQueryable();
            result = result.Where(s => s.hocSinhId == hocSinhId);
            return await result.ToListAsync();
        }

        public async Task<List<HocSinhLopHoc>> GetAllHocSinhIdAsync(int lopId)
        {
            var result = _context.HocSinhLopHocs.AsQueryable();
            result = result.Where(s => s.lopId == lopId);
            return await result.ToListAsync();
        }

        public async Task<List<dynamic>> GetProfileIdAsync(int[] hocsinhIds)
        {
            var result = await (from hs in _context.HocSinhs
                                join u in _context.Users on hs.userId equals u.id
                                where hocsinhIds.Contains(hs.id)
                                select new
                                {
                                    StudentId = hs.studentId,
                                    FullName = u.fullName
                                }).ToListAsync();

            return result.Cast<dynamic>().ToList();
        }

        public async Task<HocSinh> UpdateStudentIdAsync(string fullName, int studentId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.fullName == fullName);
            var student = await _context.HocSinhs.FirstOrDefaultAsync(i => i.userId == user.id);
            student.studentId = studentId;

            await _context.SaveChangesAsync();

            return student;
        }


    }
}