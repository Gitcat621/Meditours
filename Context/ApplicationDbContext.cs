using Meditours.Models;
using Microsoft.EntityFrameworkCore;

namespace Meditours.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<usuario> usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<Metodo_pago> Metodo_pago { get; set; }
        public DbSet<Camioneta> Camioneta { get; set; }
        public DbSet<itinerario> itinerario { get; set; }
    }
}
