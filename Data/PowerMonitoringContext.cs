using Power_Monitoring.Models;
using Microsoft.EntityFrameworkCore;

namespace Power_Monitoring.Data
{
  public class PowerMonitoringContext : DbContext
  {
    public PowerMonitoringContext(DbContextOptions<PowerMonitoringContext> options) : base(options)
    {
        
    }

    public DbSet<User> FavoriteBands { get; set; }

    #region OnConfiguring
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // In order to be able to create migrations and update database:
        if (!options.IsConfigured)
        {
            options.UseSqlServer("YourLocalConnectionStringShouldBeHere");
        }
        base.OnConfiguring(options);
    }
    #endregion

    #region Model Creating

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Your Model Crerating Stuff
    }

    #endregion Model Creating
    }
}