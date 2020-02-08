using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentLogger.Models;

namespace StudentLogger.Repository
{
    public interface ICourseRepository : IRepository<Courses>
    {
        Task<IEnumerable<Courses>> GetCourses();
        Task<Courses> GetCourseById(int id);
    }
}
