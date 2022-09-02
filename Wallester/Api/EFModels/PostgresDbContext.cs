using Microsoft.EntityFrameworkCore;

namespace Wallester.Api.EFModels
{
    public class PostgresDbContext: DbContext
    {
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options): base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
