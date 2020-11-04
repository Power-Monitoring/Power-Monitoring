using System;
using System.IO;
using Power_Monitoring.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Newtonsoft.Json.Linq;

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
        //if (!options.IsConfigured)
        //{
        //    var appconfig = JToken.Parse(
        //        File.ReadAllText(Path.Combine(Environment.CurrentDirectory,
        //            "appsettings.json")));
        //    options.UseSqlServer("Server=.;Database=monitoring;user id=root;password=gall");
        //}
        options.UseMySql("server=localhost;database=monitoring;user=root;password=gall");
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