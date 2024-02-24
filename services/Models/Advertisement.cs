using services.Enums;

namespace services.Models;
public class Advertisement
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int Views { get; set; }
    public DateOnly CreatedAt { get; set; }
    public DateOnly UpdatedAt { get; set; }
    public AdType AdType { get; set; }
    public int UserId { get; set; } = 1;
    public User User { get; set; } = null!;
}
