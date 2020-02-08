using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentLogger.Data;
using StudentLogger.Models;
using StudentLogger.Repository;
using StudentLogger.Services;

namespace StudentLogger.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //private readonly StudentLoggerContext _context;
        private readonly IStudentRepsitory _student;
        private readonly IStudentService _studentService;

        public StudentsController(IStudentRepsitory student, IStudentService studentService)
        {
            _student = student;
            _studentService = studentService;
        }

        //public StudentsController(StudentLoggerContext context)
        //{
        //    _context = context;
        //}

        // GET: api/Students
        [HttpGet]
        public async Task<IEnumerable<Students>> GetStudents()
        {
            // return await _context.Students.ToListAsync();
            return await _student.GetStudents();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Students>> GetStudentsById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var students = await _student.GetStudentById((int)id);

            if (students == null)
            {
                return NotFound();
            }

            return students;
        }
        // PUT: api/Students1/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutStudents(Students updateS, Students students)
        //{
        //    //if (id != students.StudentId)
        //    //{
        //    //    return BadRequest();
        //    //}

        //    var updateStudent = await _studentService.UpdateStudent(students);
        //    return updateStudent;

            //_context.Entry(students).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!StudentsExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        //}

        // POST: api/Students1
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Students>> PostStudents(Students students)
        {
            if (students == null)
            {
                return BadRequest();
            }

            var newStudent = await _studentService.NewStudent(students);

            return Ok(newStudent);

            //_context.Students.Add(students);
            //await _context.SaveChangesAsync();

           // return CreatedAtAction("GetStudents", new { id = students.StudentId }, students);
        }

        //// DELETE: api/Students1/5
        //[HttpDelete("{id}")]
        //public async Task<Students> DeleteStudents(Students student)
        //{
        //    //if (student == null)
        //    //{
        //    //    return BadRequest();
        //    //}
        //    var deleteStudent = await _studentService.DeleteStudent(student);

        //    //var students = await _context.Students.FindAsync(id);
        //    //if (students == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //_context.Students.Remove(students);
        //    //await _context.SaveChangesAsync();

        //    return deleteStudent;
        //}


        //private bool StudentsExists(int id)
        //{
        //    return _context.Students.Any(e => e.StudentId == id);
        //}
    }
}
