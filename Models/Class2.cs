using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace LarClientes.Models
{
    public static class InicializaBD
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LarClientesContext(
                serviceProvider.GetRequiredService<DbContextOptions<LarClientesContext>>()))
            {
                // Verifica se o banco de dados existe e o cria se necessário
                context.Database.EnsureCreated();

                // Verifica se já existem registros na tabela TipoCliente
                if (context.TiposCliente.Any() || context.Clientes.Any())
                {
                    return;   // O banco de dados já foi inicializado
                }

                // Adicionando alguns tipos de cliente padrão
                var tipoFisico = new TipoCliente
                {
                    Nome = "Pessoa Física",
                    Categoria = "Individual"
                };

                var tipoJuridico = new TipoCliente
                {
                    Nome = "Pessoa Jurídica",
                    Categoria = "Empresa"
                };

                context.TiposCliente.AddRange(tipoFisico, tipoJuridico);

                // Adicionando alguns clientes de exemplo
                context.Clientes.AddRange(
                    new Cliente
                    {
                        Nome = "João da Silva",
                        CpfCnpj = "123.456.789-00",
                        TipoClienteId = tipoFisico.ID,
                        Categoria = tipoFisico.Categoria,
                        DataCadastro = DateTime.UtcNow
                    },
                    new Cliente
                    {
                        Nome = "Maria Oliveira",
                        CpfCnpj = "987.654.321-00",
                        TipoClienteId = tipoFisico.ID,
                        Categoria = tipoFisico.Categoria,
                        DataCadastro = DateTime.UtcNow
                    },
                    new Cliente
                    {
                        Nome = "Empresa XYZ Ltda.",
                        CpfCnpj = "12.345.678/0001-00",
                        TipoClienteId = tipoJuridico.ID,
                        Categoria = tipoJuridico.Categoria,
                        DataCadastro = DateTime.UtcNow
                    },
                    new Cliente
                    {
                        Nome = "Supermercado ABC S/A",
                        CpfCnpj = "98.765.432/0001-00",
                        TipoClienteId = tipoJuridico.ID,
                        Categoria = tipoJuridico.Categoria,
                        DataCadastro = DateTime.UtcNow
                    }
                );

                // Salva as mudanças no banco de dados
                context.SaveChanges();
            }
        }
    }
}
