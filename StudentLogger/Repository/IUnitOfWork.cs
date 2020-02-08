using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentLogger.Repository
{
    interface IUnitOfWork : IDisposable
    {
        IStudentRepsitory Students { get; }

        ICourseRepository Courses { get; }

        IActivitiesRepository Activities { get; }

        Task<int> CommitAsync();
    }
}
