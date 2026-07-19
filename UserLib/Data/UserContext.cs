using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserLib.Models;


namespace UserLib.Data;

public class UserContext : DbContext
{

    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    public DbSet<UserPreference> UserPreferences { get; set; }
    public DbSet<UserSetting> UserSettings { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserContext).Assembly);

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