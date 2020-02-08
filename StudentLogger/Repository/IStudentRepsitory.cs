using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentLogger.Models;

namespace StudentLogger.Repository
{
    public interface IStudentRepsitory : IRepository<Students>
    {
        Task<IEnumerable<Students>> GetStudents();
        Task<Students> GetStudentById(int id);
    }
}
