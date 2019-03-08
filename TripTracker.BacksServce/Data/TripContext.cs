using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using TripTracker.BacksServce.Models;

namespace TripTracker.BacksServce.Data
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options) : base(options) { }

        public DbSet<Trip> Trips { get; set; }

        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var serviseScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviseScope.ServiceProvider.GetService<TripContext>();

                context.Database.EnsureCreated();

                if (context.Trips.Any()) return;

                context.Trips.AddRange(new Trip[]
                    {
                        new Trip
                        {
                            Id = 1,
                            Name = "MVP Summit",
                            StartDate = new DateTime(2018, 3, 5),
                            EndtDate = new DateTime(2018, 3, 8)
                        },
                        new Trip
                        {
                            Id = 2,
                            Name = "DevIntersection Orlando 2018",
                            StartDate = new DateTime(2018, 3, 25),
                            EndtDate = new DateTime(2018, 3, 27)
                        },
                        new Trip
                        {
                            Id = 3,
                            Name = "Build 2018",
                            StartDate = new DateTime(2018, 5, 7),
                            EndtDate = new DateTime(2018, 5, 9)
                        }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
