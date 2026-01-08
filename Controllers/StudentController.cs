using Microsoft.AspNetCore.Mvc;
using DotnetAssignment.Data;
using DotnetAssignment.Models;

namespace DotnetAssignment.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;

            // ใส่ข้อมูลตัวอย่าง (seed data)
            if (!_context.Students.Any())
            {
                _context.Students.AddRange(
                    new Student
                    {
                        Id = 1,
                        StudentCode = "ST001",
                        FullName = "Punnatat Ngirnngam",
                        Age = 20,
                        Major = "Computer Engineering",
                        GPA = 3.25
                    },
                    new Student
                    {
                        Id = 2,
                        StudentCode = "ST002",
                        FullName = "Sung Jin Woo",
                        Age = 21,
                        Major = "Information Technology",
                        GPA = 3.60
                    }
                );

                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }
    }
}
