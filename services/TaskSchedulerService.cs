using TaskScheduler.Models;
using System.Text.Json;

namespace TaskScheduler.Services;

public class TaskSchedulerService
{
    private List<TaskItem> tasks = new();
    private int nextId = 1;
    private readonly string filePath = "tasks.json";

    public TaskSchedulerService()
    {
        LoadTasks();
        if (tasks.Any())
            nextId = tasks.Max(t => t.Id) + 1;
    }

    public void AddTask(string desc, DateTime time, RecurrenceType recurrence)
    {
        tasks.Add(new TaskItem
        {
            Id = nextId++,
            Description = desc,
            ScheduledTime = time,
            Recurrence = recurrence
        });
        SaveTasks();
    }

    public void DeleteTask(int id)
    {
        tasks.RemoveAll(t => t.Id == id);
        SaveTasks();
    }

    public void EditTask(int id, string newDesc, DateTime newTime, RecurrenceType newRecurrence)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            task.Description = newDesc;
            task.ScheduledTime = newTime;
            task.Recurrence = newRecurrence;
            SaveTasks();
        }
    }

    public void ListTasks()
    {
        if (!tasks.Any())
        {
            Console.WriteLine("No tasks scheduled.");
            return;
        }
        foreach (var task in tasks)
            Console.WriteLine(task);
    }

    public List<TaskItem> GetTasks() => tasks;

    private void SaveTasks()
    {
        var json = JsonSerializer.Serialize(tasks);
        File.WriteAllText(filePath, json);
    }

    private void LoadTasks()
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            var loadedTasks = JsonSerializer.Deserialize<List<TaskItem>>(json);
            if (loadedTasks != null)
                tasks = loadedTasks;
        }
    }
}
