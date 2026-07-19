using ScheduleLib.Models;

namespace ScheduleLib.Data;

public class ScheduleInterval
{
    public int Id { get; set; }
    public required string ReferenceId { get; set; }
    public required string TimeZoneId { get; set; }
    public required TimeOnly TimeOfDay { get; set; }
    public required DayOfWeek DayOfWeek { get; set;}
    public int RoldId { get; set; }
}

