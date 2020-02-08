using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentLogger.Data;
using StudentLogger.Models;

namespace StudentLogger.Repository
{
    public class StudentRepository : Repository<Students>, IStudentRepsitory
    {

        private readonly StudentLoggerContext _context;
        public StudentRepository(StudentLoggerContext context)
          : base(context)
        { }


        //public StudentRepository(StudentLoggerContext context)
        //{
        //    _context = context;
        //}

        public async Task<IEnumerable<Students>> GetStudents()
        {
            // return await StudentLoggerContext.Students.Include(a => a.FullName).ToListAsync();
            return await _context.Students.ToListAsync();
        }

        public async Task<Students> GetStudentById(int id)
        {
            //return await StudentLoggerContext.Students.SingleOrDefaultAsync(a => a.StudentId == id);
            return await _context.Students.SingleOrDefaultAsync(a => a.StudentId == id);
        }

        //private StudentLoggerContext StudentLoggerContext
        //{
        //    get { return Context as StudentLoggerContext; }
        //}
    }
}
