using System.Data.Entity;

namespace Pruebas.Domain.Models
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<Common.Models.Producto> Productos { get; set; }
        public DbSet<Common.Models.Categoria> Categoria { get; set; }
        public DbSet<Common.Models.Usuarios> Usuarios { get; set; }
        public DbSet<Common.Models.UserType> UserType { get; set; }
    }
}
