// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using server.Data;
// using server.Dtos.Class;
// using server.Interfaces;
// using server.Mappers;

// namespace server.Controllers
// {
//     [Route("api/class")]
//     [ApiController]
//     public class ClassController : ControllerBase
//     {

//         private readonly ApplicationDBContext _context;
//         private readonly IClassRepository _classRepo;
//         private readonly ITeacherRepository _teacherRepo;
//         // , ITokenService tokenService, SignInManager<AppUser> signInManager
//         public ClassController(ApplicationDBContext context, IClassRepository classRepo, ITeacherRepository teacherRepo)
//         {
//             _classRepo = classRepo;
//             _teacherRepo = teacherRepo;
//             _context = context;
//         }

//         [HttpPost]
//         public async Task<IActionResult> Create([FromBody] CreateClassRequestDto classDto)
//         {
//             //create class
//             var classModel = classDto.ToClassFromCreateDTO();
//             await _classRepo.CreateAsync(classModel);

//             //check exists teacher in table GiaoVien
//             var id=1;
//             var existingTeacher = await _teacherRepo.IsExistsAsync(id);
//             return existingTeacher;
//         }

//     }
// }