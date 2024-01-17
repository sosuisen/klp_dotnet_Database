using Microsoft.EntityFrameworkCore.Storage;

namespace Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Database.TaskContext())
            {
                // Create
                context.Tasks.Add(new Task("Buy milk", DateTime.Now));
                context.Tasks.Add(new Task("Buy PC", new DateTime(2023, 12, 24), true));
                context.Tasks.Add(new Task("Buy chocolate", new DateTime(2024, 2, 14), true));
                context.Tasks.Add(new Task("Clean the kitchen", DateTime.Now.AddDays(1), true));
                context.SaveChanges();

                // Update
                var taskToUpdate = context.Tasks.FirstOrDefault(t => t.Name == "Buy chocolate");
                if (taskToUpdate != null)
                {
                    taskToUpdate.Deadline = new DateTime(2024, 1, 1);
                    context.SaveChanges();
                }

                // Delete
                var date = new DateTime(2024, 1, 15);
                var taskToDelete = context.Tasks.Where(t => t.Deadline < date).Select(t => t);
                if (taskToDelete != null)
                {
                    foreach (var task in taskToDelete)
                    {
                        context.Tasks.Remove(task);
                    }
                    context.SaveChanges();
                }

                // Read
                var tasks = context.Tasks.Where(t => t.Completed == false).Select(t => $"Name: {t.Name}, Deadline: {t.Deadline}, Completed: {t.Completed}");
                foreach (var item in tasks)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}