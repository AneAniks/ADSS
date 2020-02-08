using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentLogger.Models;
using StudentLogger.Repository;
using StudentLogger.Services;

namespace StudentLogger.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        //public StudentService(IUnitOfWork unitOfWork)
        //{
        //    this._unitOfWork = unitOfWork;
        //}

        public async Task<IEnumerable<Students>> GetStudents()
        {
            return await _unitOfWork.Students.GetStudents();
        }

        public async Task<Students> GetStudentById(int id)
        {
            return await _unitOfWork.Students.GetStudentById(id);
        }

        public async Task<Students> NewStudent(Students newStudent)
        {
            await _unitOfWork.Students
                .AddAsync(newStudent);

            return newStudent;
        }

        public async Task UpdateStudent(Students studentUpdate, Students student)
        {
            studentUpdate.FullName = student.FullName;

            await _unitOfWork.CommitAsync();
        }
        public async Task DeleteStudent(Students student)
        {
            _unitOfWork.Students.Remove(student);

            await _unitOfWork.CommitAsync();
        }
    }
}
