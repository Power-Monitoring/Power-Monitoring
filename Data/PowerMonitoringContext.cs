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
  }
}