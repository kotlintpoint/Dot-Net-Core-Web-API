﻿using GetriWebApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GetriWebApi.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        //private readonly ApplicationDbContext _context;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Activity> Activities { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var activitySeeder = new ActivitySeeder();
        //    var mockActivities = activitySeeder.GenerateMockData();

        //    modelBuilder.Entity<Activity>().HasData(
        //        mockActivities
        //    );
        //}
    }
}
