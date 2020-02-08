using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentLogger.Models;

namespace StudentLogger.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Courses>> GetAllCourses();
        Task<Courses> GetCourseById(int id);
        Task<Courses> NewCourse(Courses newCourse);
        Task UpdateCourse(Courses courseUpdate, Courses course);
        Task DeleteCourse(Courses course);
    }
}
