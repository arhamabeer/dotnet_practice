

namespace dotnet_mvc.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> _dbOptions) : base(_dbOptions)
        {   
        }

        public DbSet<Employee> _dbEmployee { get; set; }
    }
}
