using TaskScheduler.Models;
using System.Net.Mail;

namespace TaskScheduler.Helpers;

public class ReminderChecker
{
    public static void CheckReminders(List<TaskItem> tasks)
    {
        foreach (var task in tasks)
        {
            if (!task.Notified && DateTime.Now >= task.ScheduledTime)
            {
                Console.WriteLine($"\n🔔 Reminder: {task.Description} (Scheduled for {task.ScheduledTime})");
                SendEmailReminder(task.Description, task.ScheduledTime);

                task.Notified = true;

                if (task.Recurrence == RecurrenceType.Daily)
                    task.ScheduledTime = task.ScheduledTime.AddDays(1);
                else if (task.Recurrence == RecurrenceType.Weekly)
                    task.ScheduledTime = task.ScheduledTime.AddDays(7);

                task.Notified = false;
            }
        }
    }

    private static void SendEmailReminder(string description, DateTime time)
    {
        try
        {
            MailMessage mail = new();
            mail.From = new MailAddress("akhiljonnalagadda86@gmail.com");
            mail.To.Add("receiveremail@gmail.com");
            mail.Subject = "Task Reminder";
            mail.Body = $"Reminder: {description} scheduled at {time}";

            SmtpClient smtp = new("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential("akhiljonnalagadda86@gmail.com", "yourpassword"),
                EnableSsl = true
            };

            smtp.Send(mail);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Email failed: {ex.Message}");
        }
    }
}