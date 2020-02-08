using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentLogger.Models;
using StudentLogger.Repository;

namespace StudentLogger.Services
{
    public class ActivitiesService : IActivitiesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public async Task<Activities> GetActivitiesByType(int id)
        {
            return await _unitOfWork.Activities.GetActivitiesByType(id);
        }

        public async Task<Activities> GetByCourse(int id)
        {
            return await _unitOfWork.Activities.GetByCourse(id);
        }

        public async Task<Activities> GetByStudent(int id)
        {
            return await _unitOfWork.Activities.GetByStudent(id);
        }

        public async Task<Activities> NewActivity(Activities newActivity)
        {
            await _unitOfWork.Activities
               .AddAsync(newActivity);

            return newActivity;
        }

        public async Task UpdateActivity(Activities activityUpdate, Activities activity)
        {
            activityUpdate.ActivitiesType = activity.ActivitiesType;

            await _unitOfWork.CommitAsync();
        }
        public async Task DeleteActivity(Activities activity)
        {
            _unitOfWork.Activities.Remove(activity);

            await _unitOfWork.CommitAsync();
        }
    }
}
