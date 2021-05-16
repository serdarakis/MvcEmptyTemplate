using Microsoft.EntityFrameworkCore;
using MvcEmptyTemplate.Domain.DbModels;

namespace MvcEmptyTemplate.Infrastructure.Data
{
    public class MvcEmptyTemplateContext : DbContext
    {
        public MvcEmptyTemplateContext() : base()
        {
            Database.EnsureCreated();
        }

        public DbSet<WeatherForecast> WeatherForecast { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=WeatherForecast;Integrated Security=True");
        }
    }
}
