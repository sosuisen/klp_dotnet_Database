using Microsoft.EntityFrameworkCore;

namespace Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Database.ToDoContext())
            {
                // Create
                context.ToDos.Add(new ToDo("Buy milk", DateTime.Now));
                context.ToDos.Add(new ToDo("Buy PC", new DateTime(2023, 12, 24), true));
                context.ToDos.Add(new ToDo("Buy chocolate", new DateTime(2024, 2, 14), true));
                context.ToDos.Add(new ToDo("Clean the kitchen", DateTime.Now.AddDays(1), true));
                context.SaveChanges();

                // Update
                context.ToDos.Where(t => t.Name == "Buy chocolate")
                   .ExecuteUpdate(setters => setters.SetProperty(t => t.Deadline, new DateTime(2024, 1, 1)));

                // Delete
                var date = new DateTime(2024, 1, 15);
                context.ToDos.Where(t => t.Deadline < date).Select(t => t).ExecuteDelete();

                // Read
                var tasks = context.ToDos.Where(t => t.Completed == false).Select(t => $"Name: {t.Name}, Deadline: {t.Deadline}, Completed: {t.Completed}");
                foreach (var item in tasks)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}