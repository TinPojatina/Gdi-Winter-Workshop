using Workshop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Workshop.Infrastructure
{
    public class WorkshopInfrastructureDbContext : DbContext
    {
        public WorkshopInfrastructureDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Sensor> Sensors{ get; set; }

        public DbSet<SensorType> SensorTypes{ get; set; }

        public DbSet<DataValue> DataValues{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SensorType>().HasData(
             new SensorType
             {
                 Id = 1,
                 Name = "Temperature",
             });

            modelBuilder.Entity<SensorType>().HasData(
             new SensorType
             {
                 Id = 2,
                 Name = "Humidity",
             });

            modelBuilder.Entity<SensorType>().HasData(
             new SensorType
             {
                 Id = 3,
                 Name = "Light",
             });

            modelBuilder.Entity<SensorType>().HasData(
             new SensorType
             {
                 Id = 4,
                 Name = "Audio",
             });
        }
    }
}