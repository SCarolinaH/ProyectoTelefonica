using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend
{

    public class MyDbContext : DbContext
    {
      
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Direccion> Direcciones{ get; set; }
        public DbSet<Documento> Documentos { get; set; }

        public DbSet<Auditoria> Auditorias { get; set; }

        public  MyDbContext(DbContextOptions options) : base(options)
         {
            
         }
    
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("name=Conexion");
        }
    }
}
