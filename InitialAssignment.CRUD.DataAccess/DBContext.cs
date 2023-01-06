using InitialAssignment.CRUD.Entities;
using Microsoft.EntityFrameworkCore;


namespace InitialAssignment.CRUD.DataAccess
{
    public class DBContext : DbContext
    {
        public DbSet<Book>? Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=VINNY\\SQLEXPRESS;Initial Catalog=InitialAssignment;Integrated Security=True");
        }
    }
}
