using Microsoft.EntityFrameworkCore;
using ErasTourAPI.Models;
using Microsoft.EntityFrameworkCore;
using ErasTourAPI.Models;

namespace ErasTourAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Reputation> Reputations { get; set; } = null!;
    public DbSet<Album1989> Albums1989 { get; set; }
}