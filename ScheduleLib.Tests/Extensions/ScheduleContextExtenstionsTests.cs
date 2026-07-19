using Microsoft.EntityFrameworkCore;
using Xunit;
using UserLib.Extensions;
using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using ScheduleLib.Data;
using ScheduleLib.Models;

public class ScheduleContextExtenstionsTests
{
    [Fact]
    public async Task GetAppointments_ReturnsOnlyActiveAppointmentsBefore()
    {
        // 1. Arrange: Configure an isolated In-Memory database instance
        var options = new DbContextOptionsBuilder<ScheduleContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique name prevents data leaks between tests
            .Options;

        // // Seed the in-memory database with test data
        using (var context = new ScheduleContext(options))
        {
            var id = 0;
            //DateTime wallTime = new DateTime(2026, 10, 25, 14, 30, 0); 
            DateTime wallTime = DateTime.UtcNow;
            foreach(var tz in TimeZoneInfo.GetSystemTimeZones())
            {
                context.Appointments.AddRange(
                    new Appointment { Id = ++id, IsActive = true, EventTimeUtc =  new DateTimeOffset(wallTime, tz.GetUtcOffset(wallTime))},
                    new Appointment { Id = ++id, IsActive = false, EventTimeUtc = new DateTimeOffset(wallTime, tz.GetUtcOffset(wallTime)) }
                ); 
            }
            await context.SaveChangesAsync();

            // Current local time
            DateTimeOffset localTime = DateTimeOffset.Now;

            // Current UTC time
            DateTimeOffset utcTime = DateTimeOffset.UtcNow;

            var apptsAll = context.GetAppointments();

            Assert.Single(apptsAll);
        }
    }

    [Fact]
    public async Task GetAppointments_ReturnsOnlyllAppointmentsBefore()
    {
        // 1. Arrange: Configure an isolated In-Memory database instance
        var options = new DbContextOptionsBuilder<ScheduleContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique name prevents data leaks between tests
            .Options;

        // // Seed the in-memory database with test data
        using (var context = new ScheduleContext(options))
        {
            var id = 0;
            DateTime wallTime = DateTime.UtcNow;
            foreach(var tz in TimeZoneInfo.GetSystemTimeZones())
            {
                context.Appointments.AddRange(
                    new Appointment { Id = ++id, IsActive = true, EventTimeUtc =  new DateTimeOffset(wallTime, tz.GetUtcOffset(wallTime))},
                    new Appointment { Id = ++id, IsActive = false, EventTimeUtc = new DateTimeOffset(wallTime, tz.GetUtcOffset(wallTime)) }
                ); 
            }

            await context.SaveChangesAsync();

            // Current UTC time
            DateTimeOffset utcTime = DateTimeOffset.UtcNow.AddDays(1);

            var apptsLatest = context.GetAppointments(utcTime);

            // How to fix violations
            // Use Assert.Empty, Assert.NotEmpty, or Assert.Single instead.

            Assert.Single(apptsLatest);
        }
    }

}
