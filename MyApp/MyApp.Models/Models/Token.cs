using System.ComponentModel.DataAnnotations;

namespace MyApp.Models.Models;

public class Token
{
    [Key]
    public Guid Id { get; set; } = new();
    public string? Value { get; set; }
    public DateTime ExpireDate { get; set; }
}