using Microsoft.EntityFrameworkCore;
using REVISION_DOT_NET.Model;
using REVISION_DOT_NET.Model.Domain.Blogs;

namespace REVISION_DOT_NET.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<LeaveModel> Leaves { get; set; }
        public DbSet<BlogModel> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the one-to-many relationship between Employee and Leave
            modelBuilder.Entity<EmployeeModel>()
                .HasMany(e => e.Leaves) // Each Employee has many Leaves
                .WithOne(l => l.Employee) // Each Leave has one Employee
                .HasForeignKey(l => l.EmployeeId) // Foreign key in LeaveModel pointing to EmployeeModel
                .OnDelete(DeleteBehavior.Cascade); // Optional: cascade delete behavior

            // Optionally, you can further configure the LeaveModel properties
            modelBuilder.Entity<LeaveModel>()
                .Property(l => l.LeaveName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
