using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentLogger.Data;
using StudentLogger.Models;

namespace StudentLogger.Repository
{
    public class CourseRepository : Repository<Courses>, ICourseRepository
    {
        public CourseRepository(StudentLoggerContext context)
         : base(context)
        { }

        public async Task<IEnumerable<Courses>> GetCourses()
        {
            return await StudentLoggerContext.Courses.Include(a => a.CourseName).ToListAsync();
        }

        public async Task<Courses> GetCourseById(int id)
        {
            return await StudentLoggerContext.Courses.SingleOrDefaultAsync(a => a.CourseId == id);
        }
        private StudentLoggerContext StudentLoggerContext
        {
            get { return Context as StudentLoggerContext; }
        }
    }
}
