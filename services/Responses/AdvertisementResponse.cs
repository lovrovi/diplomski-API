using services.Enums;

namespace services.Responses;
public class AdvertisementResponse
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int Views { get; set; }
    public DateOnly CreatedAt { get; set; }
    public DateOnly UpdatedAt { get; set; }
    public AdType AdType { get; set; }
    public int UserId { get; set; }
    public int Pages { get; set; }
}
