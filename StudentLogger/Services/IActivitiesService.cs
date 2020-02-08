using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentLogger.Models;

namespace StudentLogger.Services
{
    public interface IActivitiesService
    {
        Task<Activities> GetActivitiesByType(int id);
        Task<Activities> GetByStudent(int id);
        Task<Activities> GetByCourse(int id);
        Task<Activities> NewActivity(Activities newActivity);
        Task UpdateActivity(Activities activityUpdate, Activities activity);
        Task DeleteActivity(Activities activity);

    }
}
