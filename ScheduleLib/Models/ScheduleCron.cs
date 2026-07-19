using ScheduleLib.Models;

namespace ScheduleLib.Data;

public class ScheduleCron
{
    public int Id { get; set; }
    public required string ReferenceId { get; set; }
    public required string CronExpression { get; set; } = "0 0 * * *";

}