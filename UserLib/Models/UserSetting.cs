namespace UserLib.Models;

public class UserSetting
{
    public int Id { get; set; }
    public required User User { get; set; }
    public int UserId { get; set; }
    
    // Exposed as a TimeZoneInfo object inside C#
    public TimeZoneInfo PreferredTimeZone { get; set; } = TimeZoneInfo.Utc;
}

