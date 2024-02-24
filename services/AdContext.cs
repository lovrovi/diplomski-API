using Microsoft.EntityFrameworkCore;
using services.Models;

namespace services;
public class AdContext : DbContext
{
    public AdContext(DbContextOptions options) : base(options) { }
    public DbSet<Advertisement> Advertisements { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
}
