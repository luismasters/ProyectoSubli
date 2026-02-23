using Microsoft.EntityFrameworkCore;
using ProyectoSubli.Models; // <-- Esta línea es la que conecta ambos archivos

namespace ProyectoSubli.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CategoriaNegocio> Categorias { get; set; }
        public DbSet<RecursoVideo> Videos { get; set; }
        public DbSet<RecursoImagen> Imagenes { get; set; }
        public DbSet<NotaObservacion> Notas { get; set; }
    }
}