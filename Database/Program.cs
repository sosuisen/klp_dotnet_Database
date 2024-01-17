using System.Threading.Tasks;

namespace Database {
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
                context.SaveChanges();

                // Update
                var taskToUpdate = context.Tasks.FirstOrDefault(t => t.Name == "Buy milk");
                if (taskToUpdate != null)
                {
                    taskToUpdate.Completed = true;
                    context.SaveChanges();
                }

                // Delete
                var taskToDelete = context.Tasks.FirstOrDefault(t => t.Name == "Buy chocolate");
                if (taskToDelete != null)
                {
                    context.Tasks.Remove(taskToDelete);
                    context.SaveChanges();
                }

                // Read
                var tasks = context.Tasks.Select(t => $"Name: {t.Name}, Deadline: {t.Deadline}, Completed: {t.Completed}");
                foreach (var item in tasks)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}