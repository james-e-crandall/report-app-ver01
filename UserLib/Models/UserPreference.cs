using System.ComponentModel.DataAnnotations.Schema;

namespace UserLib.Models;

public class UserPreference
{
    public int Id { get; set; }
    public required User User { get; set; }
    public int UserId { get; set; }

    // This string property is saved directly to the database column
    public string TimeZoneId { get; set; } = "UTC";

    // This property is ignored by EF Core but used in your C# application logic
    [NotMapped]
    public TimeZoneInfo TimeZone
    {
        get => TimeZoneInfo.FindSystemTimeZoneById(TimeZoneId);
        set => TimeZoneId = value.Id;
    }
}
