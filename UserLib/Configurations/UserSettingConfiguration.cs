using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserLib.Models;

namespace UserLib.Configurations;

public class UserSettingConfiguration : IEntityTypeConfiguration<UserSetting>
{
    public void Configure(EntityTypeBuilder<UserSetting> builder)
    {
        builder.Property(e => e.PreferredTimeZone)
            .HasConversion(
                tz => tz.Id,                                     // Convert object to string for DB
                id => TimeZoneInfo.FindSystemTimeZoneById(id)    // Convert string back to object for C#
            );
    }
}