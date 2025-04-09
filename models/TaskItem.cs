namespace TaskScheduler.Models;

public enum RecurrenceType { None, Daily, Weekly }

public class TaskItem
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime ScheduledTime { get; set; }
    public RecurrenceType Recurrence { get; set; }
    public bool Notified { get; set; } = false;
}
