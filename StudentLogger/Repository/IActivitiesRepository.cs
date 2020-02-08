using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentLogger.Models;

namespace StudentLogger.Repository
{
    public interface IActivitiesRepository : IRepository<Activities>
    {
        Task<IEnumerable<Activities>> GetActivities();
        Task<Activities> GetActivitiesByType(int id);
        Task<Activities> GetByCourse(int id);
        Task<Activities> GetByStudent(int id);
    }
}
