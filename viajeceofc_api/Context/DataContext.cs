using viajeceofc_api.Models;
using Microsoft.EntityFrameworkCore;

namespace viajeceofc_api.Context
{
    public class DataContext : DbContext
        {
            public DataContext(DbContextOptions<DataContext> options) : base(options) { }
            public DbSet<Viajantes> Viajantes { get; set; }
            public DbSet<Destinos> Destinos { get; set; }
            public DbSet<Compras> Compras { get; set; }
        }
}