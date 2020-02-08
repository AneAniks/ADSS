using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentLogger.Data;
using StudentLogger.Models;

namespace StudentLogger.Repository
{
    public class ActivitiesRepository : Repository<Activities>, IActivitiesRepository
    {
        private readonly StudentLoggerContext _context;
        public ActivitiesRepository(StudentLoggerContext context)
          : base(context)
        { }


        //public ActivitiesRepository(StudentLoggerContext context)
        //{
        //    _context = context;
        //}
        public async Task<IEnumerable<Activities>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        public async Task<Activities> GetActivitiesByType(int id)
        {
            return await _context.Activities.SingleOrDefaultAsync(a => a.ActivityId == id);
        }

        public async Task<Activities> GetByCourse(int id)
        {
            return await _context.Activities.SingleOrDefaultAsync(a => a.CourseId == id);
        }

        public async Task<Activities> GetByStudent(int id)
        {
            return await _context.Activities.SingleOrDefaultAsync(a => a.StudentId == id);
        }
    }
}
