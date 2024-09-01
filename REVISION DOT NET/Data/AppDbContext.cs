using Microsoft.EntityFrameworkCore;
using REVISION_DOT_NET.Model;

namespace REVISION_DOT_NET.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<EmployeeModel> Employees { get; set; }

    }
}
