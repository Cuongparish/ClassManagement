using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Dtos.Class;
using server.Dtos.Grade;
using server.Interfaces;
using server.Mappers;

namespace server.Controllers
{
    [Route("api/grade")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IClassRepository _classRepo;
        private readonly ITeacherRepository _teacherRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly IUserRepository _userRepo;
        private readonly IGradeRepository _gradeRepo;
        public GradeController(ApplicationDBContext context, IUserRepository userRepo, IGradeRepository gradeRepo, IClassRepository classRepo, ITeacherRepository teacherRepo, IStudentRepository studentRepo)
        {
            _classRepo = classRepo;
            _teacherRepo = teacherRepo;
            _studentRepo = studentRepo;
            _userRepo = userRepo;
            _gradeRepo = gradeRepo;
            _context = context;
        }

        // hiển thị ds thành phần điểm + tổng % điểm 
        [HttpGet("listPercentScore/{lopId:int}")]
        [Authorize]
        public async Task<IActionResult> getPercentScore_inClass([FromRoute] int lopId)
        {
            try
            {
                var grade = await _gradeRepo.GetbyLopIdAsync(lopId);
                float sum = 0;
                for (int i = 0; i < grade.Count; i++)
                {
                    sum += grade[i].phanTramDiem;
                    // console.log(rows[i].PhanTramDiem);
                }

                var result = new
                {
                    list_grade = grade,
                    total = sum
                };
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // thêm thành phần điểm
        [HttpPost("addPercentScore")]
        [Authorize]
        public async Task<IActionResult> addPercentScore_inClass([FromBody] CreateGradeRequestDto gradeDto)
        {
            try
            {
                var gradeModel = gradeDto.ToGradeFromCreateDTO();
                var grade = await _gradeRepo.CreateAsync(gradeModel);
                return Ok(grade.ToGradeDto());
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // xóa thành phần điểm
        [HttpGet("delPercentScore/{id:int}")]
        [Authorize]
        public async Task<IActionResult> delPercentScore_inClass([FromRoute] int id)
        {
            try
            {
                var grade = await _gradeRepo.DelAsync(id);
                return Ok(grade.ToGradeDto());
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        //sửa thành phần điểm
        [HttpPut("updatePercentScore")]
        [Authorize]
        public async Task<IActionResult> updatePercentScore_inClass([FromBody] UpdateGradeRequestDto updateGrade)
        {
            try
            {
                var grade = await _gradeRepo.UpdateAsync(updateGrade);
                return Ok(grade.ToGradeDto());
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}