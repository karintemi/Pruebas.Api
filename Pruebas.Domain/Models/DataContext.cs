using System.Data.Entity;

namespace Pruebas.Domain.Models
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<Common.Models.Producto> Productos { get; set; }
        public DbSet<Common.Models.Categoria> Categorias { get; set; }
        public DbSet<Common.Models.Usuario> Usuarios { get; set; }
        public DbSet<Common.Models.UserType> UserTypes { get; set; }
    }
}
