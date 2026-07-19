namespace UserLib.Models;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required bool IsActive  { get; set; }
    public UserPreference UserPreference { get; set; } = null!;
    public int? UserPreferenceId { get; set; }
    public UserSetting UserSetting { get; set; } = null!;
    public required int? UserSettingId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}