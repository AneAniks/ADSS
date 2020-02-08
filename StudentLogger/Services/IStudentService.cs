using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentLogger.Models;

namespace StudentLogger.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Students>> GetStudents();
        Task<Students> GetStudentById(int id);
        Task<Students> NewStudent(Students newStudent);
        Task UpdateStudent(Students studentUpdate, Students student);
        Task DeleteStudent(Students student);
    }
}
