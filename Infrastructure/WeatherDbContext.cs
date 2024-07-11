using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherForecastApi.Domain;

namespace WeatherForecastApi.Infrastructure;

public class WeatherDbContext : DbContext
{
    public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options) { }

    public DbSet<WeatherHistory> WeatherHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
            v => v.ToUniversalTime(),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        modelBuilder.Entity<WeatherHistory>()
            .Property(e => e.Date)
            .HasConversion(dateTimeConverter);

        base.OnModelCreating(modelBuilder);
    }
}

