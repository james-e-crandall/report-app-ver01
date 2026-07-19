using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserLib.Models;

namespace UserLib.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(u => u.UserPreference)
            .WithOne(u => u.User)
            .HasForeignKey<UserPreference>(u => u.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(u => u.UserSetting)
            .WithOne(u => u.User)
            .HasForeignKey<UserSetting>(u => u.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}