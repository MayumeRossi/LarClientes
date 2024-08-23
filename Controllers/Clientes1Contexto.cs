using Microsoft.EntityFrameworkCore;

namespace LarClientes.Models
{
    public class Clientes1Contexto : DbContext
    {
        public Clientes1Contexto(DbContextOptions<Clientes1Contexto> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TipoCliente> TipoClientes { get; set; }
    }
}
