using financas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace financas.Infrastructure.Data;

/// <summary>
/// Representa o contexto de banco de dados da aplicação.
/// É responsável por gerenciar a conexão com o banco e o mapeamento
/// das entidades para suas respectivas tabelas utilizando o Entity Framework Core.
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Inicializa uma nova instância do contexto da aplicação.
    /// </summary>
    /// <param name="options">
    /// Opções de configuração do Entity Framework Core, como
    /// provedor de banco de dados e string de conexão.
    /// </param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Representa a tabela de pessoas no banco de dados.
    /// </summary>
    public DbSet<Person> Persons => Set<Person>();

    /// <summary>
    /// Representa a tabela de transações financeiras no banco de dados.
    /// </summary>
    public DbSet<Transaction> Transactions => Set<Transaction>();
}