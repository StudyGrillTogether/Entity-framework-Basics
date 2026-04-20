using Microsoft.AspNetCore.Mvc;
using StudentManagementEF.Data;
using StudentManagementEF.Models;


namespace StudentManagementEF.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class StudentsController:ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (string.IsNullOrEmpty(student.Name))
            {
                return BadRequest("Name is required");
            }
            _context.Students.Add(student);
            _context.SaveChanges();

            return Ok(student);
        }

        [HttpGet]
        public IActionResult GetStudent()
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }
    }
}
