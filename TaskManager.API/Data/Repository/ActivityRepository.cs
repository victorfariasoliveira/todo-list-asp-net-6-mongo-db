using MongoDB.Driver;
using TaskManager.API.Data.Configurations;
using TaskManager.API.Models;

namespace TaskManager.API.Data.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoCollection<Activity> _activitiesCollection;
        public ActivityRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _activitiesCollection = database.GetCollection<Activity>("activity");
        }
        public void Add(Activity activity)
        {
            _activitiesCollection.InsertOne(activity);
        }

        public void Update(string id, Activity activityUpdated)
        {
            _activitiesCollection.ReplaceOne(act => act.Id == id, activityUpdated);
        }

        public void Delete(string id)
        {
            _activitiesCollection.DeleteOne(act => act.Id == id);
        }

        public Activity Get(string id)
        {
            return _activitiesCollection.Find(act => act.Id == id).FirstOrDefault();
        }
         
        public List<Activity> GetAll()
        {
            return _activitiesCollection.Find(act => true).ToList();
        }
    }
}
