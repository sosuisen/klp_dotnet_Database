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