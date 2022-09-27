using TaskManager.API.Models;

namespace TaskManager.API.Data.Repository
{
    public interface IActivityRepository
    {
        public void Add(Activity activity);
        public void Update(string id, Activity activityUpdated);
        public void Delete(string id);
        public List<Activity> GetAll();
        public Activity Get(string id);
    }
}
