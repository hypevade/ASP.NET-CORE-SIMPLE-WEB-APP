using Instahach.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Instahach.Domain;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Image> Images { get; set; } = null!;
    public DbSet<User?> Users { get; set; } = null!;
    public DbSet<Like> Likes { get; set; } = null!;
}
