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

namespace StudentLogger.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        //private readonly StudentLoggerContext _context;

        //public CoursesController(StudentLoggerContext context)
        //{
        //    _context = context;
        //}
        private readonly ICourseRepository _course;

        public CoursesController(ICourseRepository course)
        {
            _course = course;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<IEnumerable<Courses>> GetCourses()
        {
            return await _course.GetCourses();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Courses>> GetCourses(int id)
        {
            var courses = await _course.GetCourseById(id);

            if (courses == null)
            {
                return NotFound();
            }

            return courses;
        }

        //private bool CoursesExists(int id)
        //{
        //    return _context.Courses.Any(e => e.CourseId == id);
        //}
    }
}
