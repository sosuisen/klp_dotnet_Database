namespace Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TaskContext())
            {
                // Create
                context.ToDos.Add(new ToDo("Buy milk", DateTime.Now));
                context.ToDos.Add(new ToDo("Buy PC", new DateTime(2023, 12, 24), true));
                context.ToDos.Add(new ToDo("Buy chocolate", new DateTime(2024, 2, 14), true));
                context.SaveChanges();

                // Update
                var taskToUpdate = context.ToDos.FirstOrDefault(t => t.Name == "Buy milk");
                if (taskToUpdate != null)
                {
                    taskToUpdate.Completed = true;
                    context.SaveChanges();
                }

                // Delete
                var taskToDelete = context.ToDos.FirstOrDefault(t => t.Name == "Buy chocolate");
                if (taskToDelete != null)
                {
                    context.ToDos.Remove(taskToDelete);
                    context.SaveChanges();
                }

                // Read
                var date = new DateTime(2024, 1, 1);
                var tasks2 = context.ToDos.Where(t => t.Deadline > date)
                    .Select(t => $"Name: {t.Name}, Deadline: {t.Deadline}, Completed: {t.Completed}");
                foreach (var item in tasks2)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}