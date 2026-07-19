using UserLib.Data;

namespace UserLib.Models;

public class Role
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required bool IsActive  { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

}