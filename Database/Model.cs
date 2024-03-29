using Microsoft.EntityFrameworkCore;

namespace Database
{

    public class TaskContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=testdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }

    public class Task(string name, DateTime deadline, bool completed = false)
    {
        public int Id { get; set; }
        public string Name { get; set; } = name;
        public DateTime Deadline { get; set; } = deadline;
        public bool Completed { get; set; } = completed;
    }
}
