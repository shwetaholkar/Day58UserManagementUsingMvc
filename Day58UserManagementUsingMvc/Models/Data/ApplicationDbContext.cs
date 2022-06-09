using Microsoft.EntityFrameworkCore;

namespace Day58UserManagementUsingMvc.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-ERGIE03\MSSQLSERVER01;Initial Catalog=UserManagement;Integrated Security=True");
        }
    }                               
}
