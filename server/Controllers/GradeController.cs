using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Interfaces;

namespace server.Controllers
{
    public class GradeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IClassRepository _classRepo;
        private readonly ITeacherRepository _teacherRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly IUserRepository _userRepo;
        public GradeController(ApplicationDBContext context, IUserRepository userRepo, IClassRepository classRepo, ITeacherRepository teacherRepo, IStudentRepository studentRepo)
        {
            _classRepo = classRepo;
            _teacherRepo = teacherRepo;
            _studentRepo = studentRepo;
            _userRepo = userRepo;
            _context = context;
        }

        [HttpGet("grade/listPercentScore/{lopId:int}")]
        public async Task<IActionResult> GetClassByUserId([FromRoute] int lopId)
        {
            try
            {

                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}