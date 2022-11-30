using Meditours.Models;
using Microsoft.EntityFrameworkCore;

namespace Meditours.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Camionetas> Camionetas { get; set; }
        public DbSet<Destinos> Destinos { get; set; }
        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<Itinerarios> Itinerarios { get; set; }
        public DbSet<Paquetes> Paquetes { get; set; }
    }
}
