using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using models = app_api.Models;

namespace app_api.Database
{
    public class TimeTrackerDatabaseContext : DbContext
    {
        public TimeTrackerDatabaseContext(DbContextOptions<TimeTrackerDatabaseContext> options) : base(options)
        {

        }
        public DbSet<models.User> Users { get; set; }
        public DbSet<models.Project> Projects { get; set; }
        public DbSet<models.ProjectDepartment> ProjectDepartments { get; set; }
        public DbSet<models.Company> Companies { get; set; }
        public DbSet<models.Department> Departments { get; set; }
        public DbSet<models.Employee> Employees { get; set; }
        public DbSet<models.ReconciledProjectDepartment> ReconciledProjectDepartments { get; set; }

        public DbSet<models.TimeBlock> TimeBlocks { get; set; }

    }


}
