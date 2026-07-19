using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScheduleLib.Models;


namespace ScheduleLib.Data;

public class ScheduleContext : DbContext
{

    public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)
    {
    }
    public DbSet<Appointment> Appointments { get; set; }

    public DbSet<ScheduleCron> ScheduleCrons { get; set; }
    public DbSet<ScheduleInterval> ScheduleIntervals { get; set; }
    public DbSet<ScheduleOneAWeek> ScheduleOneAWeeks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScheduleContext).Assembly);

        // Define a converter that handles saving and retrieving
        // var utcConverter = new ValueConverter<DateTime, DateTime>(
        //     toDb => toDb.ToUniversalTime(), // Coerces to UTC on save
        //     fromDb => DateTime.SpecifyKind(fromDb, DateTimeKind.Utc) // Forces UTC flag on read
        // );

        // Apply the converter globally to every DateTime property in your database
        // foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        // {
        //     foreach (var property in entityType.GetProperties())
        //     {
        //         if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
        //         {
        //             property.SetValueConverter(utcConverter);
        //         }
        //     }
        // }


    }


}