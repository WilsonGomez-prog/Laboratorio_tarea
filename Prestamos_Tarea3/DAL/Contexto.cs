using Microsoft.EntityFrameworkCore;
using Prestamos_Tarea3.Entidades;

namespace Prestamos_Tarea3.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Persona> persona { get; set; }
        public DbSet<Prestamo> prestamo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(@"Data Source=DATA\Prestamos.db");
        }
    }
}