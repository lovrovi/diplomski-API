using services.Enums;

namespace services.Requests;
public class AdvertisementPostRequest
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public AdType AdType { get; set; }
}
