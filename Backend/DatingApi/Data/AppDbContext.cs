using DatingApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; }
}
