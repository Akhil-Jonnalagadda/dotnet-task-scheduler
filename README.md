
# 📅 .NET Task Scheduler with Reminders

This is a simple yet powerful Task Scheduler Console App built in **C# and .NET 8**. It supports:

- Adding, editing, deleting tasks
- Recurring tasks (daily, weekly)
- Desktop and email reminders
- JSON file persistence (tasks saved across runs)

---

## 🚀 Features

- 📝 Add tasks with custom date and time
- 🔁 Support for recurring tasks
- 🧠 Background reminder checker (every 5 seconds)
- 💾 Auto-save/load tasks to/from `tasks.json`
- 📨 Email reminders via SMTP

---
## 📦 How to Run

1. Clone the repo:
   ```bash
   https://github.com/Akhil-Jonnalagadda/dotnet-task-scheduler.git
   cd dotnet-task-scheduler
   

2. Run the app:
   ```bash
   dotnet run
   ```

---

## 🛠️ Configuration

### ✉️ Email Reminder (Gmail SMTP)

Edit this in `Helpers/ReminderChecker.cs`:

```csharp
mail.From = new MailAddress("youremail@gmail.com");
smtp.Credentials = new NetworkCredential("youremail@gmail.com", "yourapppassword");
```

> ⚠️ Use [App Passwords](https://support.google.com/accounts/answer/185833?hl=en) instead of your real password.

---

## 🛠️ Built With

- [.NET 8](https://dotnet.microsoft.com/en-us/download)
- C#
- Console UI
- JSON File Handling
- SMTP (System.Net.Mail)

---

## ✨ Future Improvements

- Desktop Toast Notifications (Windows)
- Google Calendar API integration
- GUI version with WinForms/WPF
- Auth system with user accounts

---
