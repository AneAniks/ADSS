using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentLogger.Data;

namespace StudentLogger.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentLoggerContext _context;
        private StudentRepository _studentRepository;
        private CourseRepository _courseRepository;
        private ActivitiesRepository _activityRepository;

        public UnitOfWork(StudentLoggerContext context)
        {
            this._context = context;
        }

        public IStudentRepsitory Students => _studentRepository = _studentRepository ?? new StudentRepository(_context);

        public ICourseRepository Courses => _courseRepository = _courseRepository ?? new CourseRepository(_context);

        public IActivitiesRepository Activities => _activityRepository = _activityRepository ?? new ActivitiesRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
