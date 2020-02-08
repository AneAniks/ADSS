using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentLogger.Models;
using StudentLogger.Repository;

namespace StudentLogger.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        //public CourseService(IUnitOfWork unitOfWork)
        //{
        //    this._unitOfWork = unitOfWork;
        //}

        public async Task DeleteCourse(Courses course)
        {
            _unitOfWork.Courses.Remove(course);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Courses>> GetAllCourses()
        {
            return await _unitOfWork.Courses.GetCourses();
        }

        public async Task<Courses> GetCourseById(int id)
        {
            return await _unitOfWork.Courses.GetCourseById(id);
        }

        public async Task<Courses> NewCourse(Courses newCourse)
        {
            await _unitOfWork.Courses
                .AddAsync(newCourse);

            return newCourse;
        }

        public async Task UpdateCourse(Courses courseUpdate, Courses course)
        {
            courseUpdate.CourseName = course.CourseName;

            await _unitOfWork.CommitAsync();
        }
    }
}
