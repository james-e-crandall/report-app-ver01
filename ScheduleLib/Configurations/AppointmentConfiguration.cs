using Microsoft.EntityFrameworkCore;
using ScheduleLib.Models;

namespace ScheduleLib.Configurations;

//https://learn.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{

    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Appointment> builder)
    {

    }
}