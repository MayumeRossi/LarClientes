using Microsoft.EntityFrameworkCore;

namespace LarClientes.Models
{
    public class LarClientesContext : DbContext
    {
        public LarClientesContext(DbContextOptions<LarClientesContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TipoCliente> TiposCliente { get; set; }
    }
}
