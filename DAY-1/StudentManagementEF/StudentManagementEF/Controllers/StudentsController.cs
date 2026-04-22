using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementEF.Data;
using StudentManagementEF.Models;


namespace StudentManagementEF.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class StudentsController : ControllerBase
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
        public async Task<IActionResult> GetStudents()//task<IactionResult> is an async return type
        {
            var students = await _context.Students.ToListAsync();//await is async execution and tolist async is non blocking
            return Ok(students);
            //We use ToListAsync() to perform non-blocking database operations,
            //allowing the application to handle other requests while waiting for data.
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _context.Students.FindAsync(id); //fetch by primary key
            if(student == null)
            {
                return NotFound(); //returns 404 
            }

            return Ok(student);//returns 200 with data
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id,Student updatedStudent)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            student.Name= updatedStudent.Name;
            student.Age= updatedStudent.Age;
            student.Email= updatedStudent.Email;

            await _context.SaveChangesAsync();
            return Ok(student);
            //We don’t use Update() because EF already tracks the fetched entity and
            //automatically detects changes, so calling Update() is unnecessary.
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if(student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok("Deleted Succesfully");
            //We fetch the student to ensure it exists and to get a tracked entity that EF can mark as Deleted.


        }
    }
}
