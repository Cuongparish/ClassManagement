using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Dtos.Class;
using server.Dtos.Teacher;
using server.Interfaces;
using server.Mappers;

namespace server.Controllers
{
    [Route("api/class")]
    [ApiController]
    public class ClassController : ControllerBase
    {

        private readonly ApplicationDBContext _context;
        private readonly IClassRepository _classRepo;
        private readonly ITeacherRepository _teacherRepo;
        public ClassController(ApplicationDBContext context, IClassRepository classRepo, ITeacherRepository teacherRepo)
        {
            _classRepo = classRepo;
            _teacherRepo = teacherRepo;
            _context = context;
        }

        [HttpPost]
        [Route("{userId:int}")]
        public async Task<IActionResult> Create([FromBody] CreateClassRequestDto classDto, [FromRoute] int userId)
        {
            try
            {
                //create class
                var classModel = classDto.ToClassFromCreateDTO();
                await _classRepo.CreateAsync(classModel);

                //check exists teacher in table GiaoVien
                var existingTeacher = await _teacherRepo.IsExistsAsync(userId);
                //not exists
                if (existingTeacher == null)
                {
                    //add into table GiaoVien
                    var teacher = new CreateTeacherRequestDto
                    {
                        userId = userId,
                    };
                    var teacherModel = teacher.ToTeacherFromCreateDTO();
                    var resultTeacher = await _teacherRepo.CreateAsync(teacherModel);

                    //add into table GiaoVienLopHoc
                    var teacherClass = new CreateTeacherClassRequestDto
                    {
                        lopId = classModel.id,
                        giaoVienId = resultTeacher.id,
                    };
                    var teacherClassModel = teacherClass.ToTeacherClassFromCreateDTO();
                    await _teacherRepo.CreateAsync(teacherClassModel);
                }
                //exists
                //add into table GiaoVienLopHoc
                var teacherClass1 = new CreateTeacherClassRequestDto
                {
                    lopId = classModel.id,
                    giaoVienId = existingTeacher.id,
                };
                var teacherClassModel1 = teacherClass1.ToTeacherClassFromCreateDTO();
                await _teacherRepo.CreateAsync(teacherClassModel1);

                return Ok(classModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> Get([FromRoute] int userId)
        {
            try
            {
                // var classOfTeacher = new List<ClassDto> { };
                //get giaoVienId
                var teacher = await _teacherRepo.GetGiaoVienIdAsync(userId);
                // // not exists
                // if (teacher == null)
                // {
                //     classOfTeacher = null;
                // }
                // else
                // {

                // }
                //get lopId
                var lop = await _teacherRepo.GetLopIdAsync(teacher.id);
                var lopIds = lop.Select(t => t.lopId).ToArray();
                //getall class of teacher
                var classOfTeacher = await _classRepo.GetByIdAsync(lopIds);
                var result = new
                {
                    Teacher = teacher,
                    Lop = lop,
                    Classes = classOfTeacher
                };

                //get hocSinhId
                //get lopId
                //getall class of student
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

    }
}