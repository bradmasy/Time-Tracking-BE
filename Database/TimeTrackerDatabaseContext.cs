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


    }


}
