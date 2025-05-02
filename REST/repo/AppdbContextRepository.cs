using Microsoft.EntityFrameworkCore;
using REST.model;

namespace REST.repo
{
    public class AppdbContextRepository : DbContext
    {
        public AppdbContextRepository(DbContextOptions<AppdbContextRepository> options)
             : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<department> Departments { get; set; }

    }
}
