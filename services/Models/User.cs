using Microsoft.Extensions.Hosting;

namespace services.Models;
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedOn { get; set; }
    public ICollection<Advertisement> Advertisements { get; } = new List<Advertisement>();
}
