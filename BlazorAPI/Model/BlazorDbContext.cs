using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Model
{
    public class BlazorDbContext : DbContext
    {

        public BlazorDbContext(DbContextOptions<BlazorDbContext> options) : base(options)
        {

        }

        public DbSet<BlazorData> BlazorDatas { get; set; }
         public DbSet<Employee> Employees { get; set; }
    }
}
 