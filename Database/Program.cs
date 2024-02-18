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
                context.SaveChanges();
            }
        }
    }
}