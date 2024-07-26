using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dtos.Grade;
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

        public async Task<CotDiem?> GetbyLopIdAsync(int lopId)
        {
            //get grade
            var grade = await _context.CotDiems.FirstOrDefaultAsync(i => i.lopId == lopId);
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

        public async Task<CotDiem> DelAsync(int lopId)
        {
            //delete grade
            try
            {
                var gradeModel = await _context.CotDiems.FirstOrDefaultAsync(x => x.lopId == lopId);

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

        public async Task<CotDiem?> UpdateAsync(int lopId, UpdateGradeRequestDto gradeDto)
        {
            //update grade
            try
            {
                var grade = await _context.CotDiems.FirstOrDefaultAsync(x => x.lopId == lopId);

                if (grade == null)
                {
                    return null;
                }

                grade.tenCotDiem = gradeDto.tenCotDiem;
                grade.phanTramDiem = gradeDto.phanTramDiem;
                grade.khoa = gradeDto.khoa;
                grade.acpPhucKhao = gradeDto.acpPhucKhao;

                await _context.SaveChangesAsync();
                return await _context.CotDiems.FirstOrDefaultAsync(x => x.lopId == lopId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}