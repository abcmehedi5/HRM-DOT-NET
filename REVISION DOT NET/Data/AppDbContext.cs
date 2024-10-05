using Microsoft.EntityFrameworkCore;
using REVISION_DOT_NET.Model;
using REVISION_DOT_NET.Model.Domain.Blogs;
using REVISION_DOT_NET.Model.Domain.Category;
using REVISION_DOT_NET.Model.Domain.Jobs;

namespace REVISION_DOT_NET.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<LeaveModel> Leaves { get; set; }
        public DbSet<BlogModel> Blogs { get; set; }
        public DbSet<JobModel> Jobs { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-many relationship between CategoryModel and JobModel
            modelBuilder.Entity<JobModel>()
                .HasOne(j => j.Category)  // JobModel has one Category
                .WithMany(c => c.Jobs)    // CategoryModel has many Jobs
                .HasForeignKey(j => j.categoryId);  // Use category_id as foreign key

            base.OnModelCreating(modelBuilder);
        }
    }
}
