using Microsoft.EntityFrameworkCore;
using ErasTourAPI.Models;

namespace ErasTourAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Album1989> Albums1989 { get; set; }
}