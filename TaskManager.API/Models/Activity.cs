namespace TaskManager.API.Models
{
    public class Activity
    {
        public Activity(string name, string detail)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Detail = detail;
            CreatedDate = DateTime.Now;
            ConclusionDate = null;
            IsCompleted = false;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Detail { get; private set; }
        public bool IsCompleted { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? ConclusionDate { get; private set; }

        public void UpdateActivity(string? name, string? detail, bool? isCompleted = false)
        {
            if (name != null) Name = name;
            if (detail != null) Detail = detail;
            IsCompleted = isCompleted ?? false;
            ConclusionDate = IsCompleted ? DateTime.Now : null;
        }

    }
}
