using EventsApi.DataAccess.EntityConfiguration;
using EventsApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace EventsApi.DataAccess.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<EventEntity> Events { get; set; }

        public DataContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
           
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfiguration());

            modelBuilder.Entity<EventEntity>().HasData(
                new EventEntity { Id = 1, Name = "Nature", Description = "Talk about animals.", Plan = "1. Start; 2. Talk; 3. End;", Organizer = "Samuliou Stsiapan", Speaker = "Byarozkin Hleb", EventTime = System.DateTime.Now, EventPlace = "Mogilev" },
                new EventEntity { Id =2, Name = "Sport", Description = "Talk about sport.", Plan = "1. Start; 2. Talk; 3. End;", Organizer = "Lionel Messi", Speaker = "Cristiano Ronaldo", EventTime = System.DateTime.Today, EventPlace = "Minsk" }
            );
        }
    }
}
