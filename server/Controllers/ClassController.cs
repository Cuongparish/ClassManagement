using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Dtos.Class;
using server.Dtos.Student;
using server.Dtos.Teacher;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Service;

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
        private readonly IUserRepository _userRepo;
        private readonly ITokenService _tokenService;
        public ClassController(ApplicationDBContext context, ITokenService tokenService, IUserRepository userRepo, IClassRepository classRepo, ITeacherRepository teacherRepo, IStudentRepository studentRepo)
        {
            _classRepo = classRepo;
            _teacherRepo = teacherRepo;
            _studentRepo = studentRepo;
            _userRepo = userRepo;
            _tokenService = tokenService;
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

        [HttpGet("all/{userId:int}")]
        public async Task<IActionResult> GetClassByUserId([FromRoute] int userId)
        {
            try
            {
                //get giaoVienId
                var teacher = await _teacherRepo.GetGiaoVienIdAsync(userId);
                //get hocSinhId
                var student = await _studentRepo.GetHocSinhIdAsync(userId);

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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetClassById([FromRoute] int id)
        {
            try
            {
                var classes_detail = await _classRepo.GetByIdAsync(id);
                return Ok(classes_detail);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet("/member/{lopId:int}")]
        public async Task<IActionResult> GetClassByLopId([FromRoute] int lopId)
        {
            try
            {
                // get id teacher
                var teacher = await _teacherRepo.GetAllGiaoVienIdAsync(lopId);
                var teacherIds = teacher.Select(t => t.giaoVienId).ToArray();
                // get id user
                var user1 = await _teacherRepo.GetUserIdAsync(teacherIds);
                var userIds1 = user1.Select(t => t.userId).ToArray();
                // get infor user in class (teacher)
                var user_infor1 = await _userRepo.GetByUserIdAsync(userIds1);
                // get id student
                var student = await _studentRepo.GetAllHocSinhIdAsync(lopId);
                var studentIds = student.Select(t => t.hocSinhId).ToArray();
                // get id user
                var user2 = await _studentRepo.GetUserIdAsync(studentIds);
                var userIds2 = user2.Select(t => t.userId).ToArray();
                // get infor user in class (student)
                var user_infor2 = await _userRepo.GetByUserIdAsync(userIds2);

                var result = new
                {
                    teacher = user_infor1,
                    student = user_infor2
                };
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        // [HttpGet("{maLop}")]
        [Authorize]
        // public async Task<IActionResult> GetClassById([FromRoute] string maLop, [FromQuery] string role)
        // public async Task<IActionResult> addUserinClass([FromBody] dynamic data)
        // {
        //     try
        //     {
        //         //get userId
        //         var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last().ToString();

        //         var principal = _tokenService.DecodeToken(token);
        //         if (principal == null)
        //         {
        //             return BadRequest("Claims not found");
        //         }
        //         var emailClaim = principal.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
        //         var user = await _userRepo.GetByUsernameAsync(emailClaim);

        //         // get lopId
        //         var classes = await _classRepo.GetByMaLopAsync(data.maLop);

        //         if (data.role == "gv")
        //         {
        //             //check exists teacher in table GiaoVien
        //             var existingTeacher = await _teacherRepo.IsExistsAsync(user.id);

        //             //not exists
        //             if (existingTeacher == null)
        //             {
        //                 //add into table GiaoVien
        //                 var teacher = new CreateTeacherRequestDto
        //                 {
        //                     userId = user.id,
        //                 };
        //                 var teacherModel = teacher.ToTeacherFromCreateDTO();
        //                 var resultTeacher = await _teacherRepo.CreateAsync(teacherModel);

        //                 //add into table GiaoVienLopHoc
        //                 var teacherClass = new CreateTeacherClassRequestDto
        //                 {
        //                     lopId = classes.id,
        //                     giaoVienId = resultTeacher.id,
        //                 };
        //                 var teacherClassModel = teacherClass.ToTeacherClassFromCreateDTO();
        //                 await _teacherRepo.CreateAsync(teacherClassModel);
        //             }
        //             //exists
        //             //add into table GiaoVienLopHoc
        //             var teacherClass1 = new CreateTeacherClassRequestDto
        //             {
        //                 lopId = classes.id,
        //                 giaoVienId = existingTeacher.id,
        //             };
        //             var teacherClassModel1 = teacherClass1.ToTeacherClassFromCreateDTO();
        //             await _teacherRepo.CreateAsync(teacherClassModel1);

        //         }

        //         if (data.role == "hs")
        //         {
        //             var student = await _studentRepo.GetHocSinhIdAsync(user.id);
        //             if (student == null)
        //             {
        //                 //add into table HocSinh
        //                 var student1 = new CreateStudentRequestDto
        //                 {
        //                     userId = user.id,
        //                 };
        //                 var studentModel = student1.ToStudentFromCreateDTO();
        //                 await _studentRepo.CreateAsync(studentModel);
        //             }
        //             var result_student = await _studentRepo.GetHocSinhIdAsync(user.id);
        //             //add into table HocSinhLopHoc
        //             var studentClass1 = new CreateStudentClassRequestDto
        //             {
        //                 lopId = classes.id,
        //                 hocSinhId = result_student.id,
        //             };
        //             var studentClassModel1 = studentClass1.ToStudentClassFromCreateDTO();
        //             await _studentRepo.CreateAsync(studentClassModel1);
        //         }
        //         return Ok(data.role);
        //     }
        //     catch (Exception e)
        //     {
        //         return StatusCode(500, e);
        //     }
        // }

        [HttpPost]
        // [HttpGet("{maLop}")]
        [Authorize]
        // public async Task<IActionResult> GetClassById([FromRoute] string maLop, [FromQuery] string role)
        public async Task<IActionResult> addUserinClass([FromBody] dynamic data)
        {
            try
            {
                //get userId
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last().ToString();

                var principal = _tokenService.DecodeToken(token);
                if (principal == null)
                {
                    return BadRequest("Claims not found");
                }
                var emailClaim = principal.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
                var user = await _userRepo.GetByUsernameAsync(emailClaim);

                // get lopId
                var classes = await _classRepo.GetByMaLopAsync(data.maLop);

                if (data.role == "gv")
                {
                    //check exists teacher in table GiaoVien
                    var existingTeacher = await _teacherRepo.IsExistsAsync(user.id);

                    //not exists
                    if (existingTeacher == null)
                    {
                        //add into table GiaoVien
                        var teacher = new CreateTeacherRequestDto
                        {
                            userId = user.id,
                        };
                        var teacherModel = teacher.ToTeacherFromCreateDTO();
                        var resultTeacher = await _teacherRepo.CreateAsync(teacherModel);

                        //add into table GiaoVienLopHoc
                        var teacherClass = new CreateTeacherClassRequestDto
                        {
                            lopId = classes.id,
                            giaoVienId = resultTeacher.id,
                        };
                        var teacherClassModel = teacherClass.ToTeacherClassFromCreateDTO();
                        await _teacherRepo.CreateAsync(teacherClassModel);
                    }
                    //exists
                    //add into table GiaoVienLopHoc
                    var teacherClass1 = new CreateTeacherClassRequestDto
                    {
                        lopId = classes.id,
                        giaoVienId = existingTeacher.id,
                    };
                    var teacherClassModel1 = teacherClass1.ToTeacherClassFromCreateDTO();
                    await _teacherRepo.CreateAsync(teacherClassModel1);

                }

                if (data.role == "hs")
                {
                    var student = await _studentRepo.GetHocSinhIdAsync(user.id);
                    if (student == null)
                    {
                        //add into table HocSinh
                        var student1 = new CreateStudentRequestDto
                        {
                            userId = user.id,
                        };
                        var studentModel = student1.ToStudentFromCreateDTO();
                        await _studentRepo.CreateAsync(studentModel);
                    }
                    var result_student = await _studentRepo.GetHocSinhIdAsync(user.id);
                    //add into table HocSinhLopHoc
                    var studentClass1 = new CreateStudentClassRequestDto
                    {
                        lopId = classes.id,
                        hocSinhId = result_student.id,
                    };
                    var studentClassModel1 = studentClass1.ToStudentClassFromCreateDTO();
                    await _studentRepo.CreateAsync(studentClassModel1);
                }
                return Ok(data.role);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


    }
}