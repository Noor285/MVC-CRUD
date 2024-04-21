using Microsoft.EntityFrameworkCore;

namespace Day_3.Models
{
    public class ITIDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-H6AJIUH;Initial Catalog=ITIDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
