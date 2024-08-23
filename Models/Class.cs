using LarClientes.Models;

namespace LarClientes.Models
{
    public class Cliente
    { 
            public int ID { get; set; }
            public string Nome { get; set; }
            public string CpfCnpj { get; set; }  // Alterado para string para suportar valores como CPF e CNPJ
            public int TipoClienteId { get; set; }  // Relacionamento com TipoCliente
            
            public string Categoria { get; set; }
            public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        }
    }
            public class TipoCliente{
            public int ID { get; set; }
            public string Nome { get; set; }
            public string Categoria { get; set; }
            public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

    // Propriedade de navegação para a lista de clientes associados a este tipo de cliente
    public ICollection<Cliente> Clientes { get; set; }
}


