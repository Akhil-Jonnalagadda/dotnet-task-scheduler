using TaskScheduler.Models;
using TaskScheduler.Services;
using TaskScheduler.Helpers;
//
var service = new TaskSchedulerService();
Console.WriteLine("📅 Task Scheduler with Reminders");

var timer = new System.Timers.Timer(5000);
timer.Elapsed += (sender, e) => ReminderChecker.CheckReminders(service.GetTasks());
timer.Start();

while (true)
{
    Console.WriteLine("\n1. Add Task\n2. View Tasks\n3. Edit Task\n4. Delete Task\n5. Exit");
    Console.Write("Select option: ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.Write("Enter task description: ");
            var desc = Console.ReadLine();

            Console.Write("Enter date and time (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out var time))
            {
                Console.WriteLine("Invalid date format.");
                continue;
            }

            Console.Write("Recurrence (None/Daily/Weekly): ");
            var recInput = Console.ReadLine();
            var recurrence = Enum.TryParse<RecurrenceType>(recInput, true, out var recType) ? recType : RecurrenceType.None;

            service.AddTask(desc, time, recurrence);
            Console.WriteLine("✅ Task added.");
            break;

        case "2":
            service.ListTasks();
            break;

        case "3":
            Console.Write("Enter task ID to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int editId)) continue;
            Console.Write("New description: ");
            var newDesc = Console.ReadLine();
            Console.Write("New date and time (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out var newTime)) continue;
            Console.Write("New recurrence (None/Daily/Weekly): ");
            var newRecInput = Console.ReadLine();
            var newRec = Enum.TryParse<RecurrenceType>(newRecInput, true, out var newRecType) ? newRecType : RecurrenceType.None;
            service.EditTask(editId, newDesc, newTime, newRec);
            Console.WriteLine("✅ Task updated.");
            break;

        case "4":
            Console.Write("Enter task ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int delId)) continue;
            service.DeleteTask(delId);
            Console.WriteLine("🗑️ Task deleted.");
            break;

        case "5":
            timer.Stop();
            return;

        default:
            Console.WriteLine("❌ Invalid option.");
            break;
    }
}
