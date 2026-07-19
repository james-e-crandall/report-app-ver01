namespace ScheduleLib.Models;

public class Appointment
{
    public int Id { get; set; }
    public required DateTimeOffset EventTimeUtc { get; set; }
    public required bool IsActive { get; set; } = true;
}