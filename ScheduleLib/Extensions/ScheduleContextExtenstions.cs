using Microsoft.EntityFrameworkCore;
using ScheduleLib.Data;
using ScheduleLib.Models;

namespace UserLib.Extensions;

public static class UserContextExtenstions
{
    extension(ScheduleContext context)
    {
        public List<Appointment> GetAppointments() =>
            context.Appointments
            .Where(_x => _x.IsActive)
            .ToList();

        // public List<Appointment> GetAppointments(DateTimeOffset dateTimeOffset) =>
        //     context.Appointments
        //     .Where(_x => EF.Functions.AtTimeZone(_x.EventTimeUtc, _x.TimeZoneId).Hour < 12)
        //     .ToList();
            
        public List<Appointment> GetAppointments(DateTimeOffset dateTimeOffset) =>
            context.Appointments
            .Where(_x => _x.EventTimeUtc >= dateTimeOffset)
            .ToList();

    }

}