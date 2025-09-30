using AutoOglasi.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoOglasi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Automobil> Automobili => Set<Automobil>();
    }
}
