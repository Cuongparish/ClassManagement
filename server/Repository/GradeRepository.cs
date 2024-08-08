using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dtos.Grade;
using server.Interfaces;
using server.Mappers;
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

        public async Task<List<CotDiem?>> GetbyLopIdAsync(int lopId)
        {
            //get grade
            var grade = await _context.CotDiems.Where(g => g.lopId == lopId).ToListAsync();
            if (grade == null)
            {
                return null;
            }
            return grade;
        }
        public async Task<CotDiem> CreateAsync(CotDiem gradeModel)
        {
            //create grade
            try
            {
                await _context.CotDiems.AddAsync(gradeModel);
                await _context.SaveChangesAsync();
                return gradeModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<CotDiem> DelAsync(int id)
        {
            //delete grade
            try
            {
                var gradeModel = await _context.CotDiems.FirstOrDefaultAsync(x => x.id == id);

                if (gradeModel == null)
                {
                    return null;
                }

                _context.CotDiems.Remove(gradeModel);
                await _context.SaveChangesAsync();
                return gradeModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

        public async Task<CotDiem?> UpdateAsync(UpdateGradeRequestDto gradeDto)
        {
            //update grade
            try
            {
                var grade = await _context.CotDiems.FirstOrDefaultAsync(x => x.id == gradeDto.id);

                if (grade == null)
                {
                    return null;
                }

                grade.tenCotDiem = gradeDto.tenCotDiem;
                grade.phanTramDiem = gradeDto.phanTramDiem;
                grade.khoa = gradeDto.khoa;
                grade.acpPhucKhao = gradeDto.acpPhucKhao;

                await _context.SaveChangesAsync();
                return await _context.CotDiems.FirstOrDefaultAsync(x => x.id == gradeDto.id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<CotDiem>> GradeComponentAsync(int lopId)
        {
            try
            {
                var result = _context.CotDiems.AsQueryable();
                result = result.Where(s => s.lopId == lopId);
                return await result.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

        public async Task<List<BangDiemThanhPhan>> GradeDetailAsync(int lopId, int[] hocSinhIds)
        {
            try
            {
                var result = await _context.BangDiemThanhPhans
                .Where(s => hocSinhIds.Contains(s.hocSinhId) && s.lopId == lopId)
                .ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}