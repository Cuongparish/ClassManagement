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
        private readonly IStudentRepository _studentRepo;
        public ClassController(ApplicationDBContext context, IClassRepository classRepo, ITeacherRepository teacherRepo, IStudentRepository studentRepo)
        {
            _classRepo = classRepo;
            _teacherRepo = teacherRepo;
            _studentRepo = studentRepo;
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

        // [HttpGet("{userId:int}")]
        // public async Task<IActionResult> Get([FromRoute] int userId)
        // {
        //     try
        //     {
        //         var result = new { };
        //         //get giaoVienId
        //         var teacher = await _teacherRepo.GetGiaoVienIdAsync(userId);
        //         //get hocSinhId
        //         var student = await _studentRepo.GetHocSinhIdAsync(userId);
        //         // not exists
        //         if (teacher == null)
        //         {
        //             //get lopId
        //             var lop_student = await _studentRepo.GetLopIdAsync(student.id);
        //             var lopIds_student = lop_student.Select(t => t.lopId).ToArray();
        //             //getall class of teacher
        //             var classOfStudent = await _classRepo.GetByIdAsync(lopIds_student);
        //             var result_student = new
        //             {
        //                 Classes_Student = classOfStudent
        //             };
        //             return Ok(result_student);
        //         }

        //         if (student == null)
        //         {
        //             //get lopId
        //             var lop = await _teacherRepo.GetLopIdAsync(teacher.id);
        //             var lopIds = lop.Select(t => t.lopId).ToArray();
        //             //getall class of teacher
        //             var classOfTeacher = await _classRepo.GetByIdAsync(lopIds);
        //             var result_teacher = new
        //             {
        //                 Classes_Teacher = classOfTeacher
        //             };
        //             return Ok(result_teacher);
        //         }

        //         var lop_student = await _studentRepo.GetLopIdAsync(student.id);
        //         var lopIds_student = lop_student.Select(t => t.lopId).ToArray();
        //         //getall class of teacher
        //         var classOfStudent = await _classRepo.GetByIdAsync(lopIds_student);

        //         var lop = await _teacherRepo.GetLopIdAsync(teacher.id);
        //         var lopIds = lop.Select(t => t.lopId).ToArray();
        //         //getall class of teacher
        //         var classOfTeacher = await _classRepo.GetByIdAsync(lopIds);

        //         var result = new
        //         {
        //             Classes_Teacher = classOfTeacher,
        //             Classes_Student = classOfStudent
        //         };

        //         return Ok(result);
        //     }
        //     catch (Exception e)
        //     {
        //         return StatusCode(500, e);
        //     }
        // }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> Get([FromRoute] int userId)
        {
            try
            {
                //get giaoVienId
                var teacher = await _teacherRepo.GetGiaoVienIdAsync(userId);
                //get hocSinhId
                var student = await _studentRepo.GetHocSinhIdAsync(userId);

                // not exists
                if (teacher == null && student != null)
                {
                    //get lopId
                    var lop_student_list = await _studentRepo.GetLopIdAsync(student.id);
                    var lopIds_student = lop_student_list.Select(t => t.lopId).ToArray();
                    //get all classes of student
                    var classOfStudent = await _classRepo.GetByIdAsync(lopIds_student);
                    var result_student = new
                    {
                        Classes_Student = classOfStudent
                    };
                    return Ok(result_student);
                }

                if (student == null && teacher != null)
                {
                    //get lopId
                    var lop_teacher_list = await _teacherRepo.GetLopIdAsync(teacher.id);
                    var lopIds_teacher = lop_teacher_list.Select(t => t.lopId).ToArray();
                    //get all classes of teacher
                    var classOfTeacher = await _classRepo.GetByIdAsync(lopIds_teacher);
                    var result_teacher = new
                    {
                        Classes_Teacher = classOfTeacher
                    };
                    return Ok(result_teacher);
                }

                if (teacher != null && student != null)
                {
                    var lop_student_list = await _studentRepo.GetLopIdAsync(student.id);
                    var lopIds_student = lop_student_list.Select(t => t.lopId).ToArray();
                    //get all classes of student
                    var classOfStudent = await _classRepo.GetByIdAsync(lopIds_student);

                    var lop_teacher_list = await _teacherRepo.GetLopIdAsync(teacher.id);
                    var lopIds_teacher = lop_teacher_list.Select(t => t.lopId).ToArray();
                    //get all classes of teacher
                    var classOfTeacher = await _classRepo.GetByIdAsync(lopIds_teacher);

                    var result = new
                    {
                        Classes_Teacher = classOfTeacher,
                        Classes_Student = classOfStudent
                    };

                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


    }
}