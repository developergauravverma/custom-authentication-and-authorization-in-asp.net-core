using System.ComponentModel.DataAnnotations;

namespace MyApp.Models.Models;

public class Role
{
    public Role()
    {
        Users = new List<User>();
    }
    [Key]
    public Guid RoleId { get; set; } = Guid.NewGuid();
    public string RoleName { get; set; } = String.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public ICollection<User>? Users { get; set; }
}