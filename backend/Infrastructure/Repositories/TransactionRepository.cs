using financas.Domain.Entities;
using financas.Infrastructure.Data;
using financas.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace financas.Infrastructure.Repositories;

/// <summary>
/// Implementação do repositório responsável pelas operações de acesso
/// aos dados da entidade <see cref="Transaction"/>.
/// Utiliza o Entity Framework Core para persistência e consulta dos dados.
/// </summary>
public class TransactionRepository : ITransactionRepository
{
    /// <summary>
    /// Contexto de acesso ao banco de dados.
    /// </summary>
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Inicializa uma nova instância do repositório de transações.
    /// </summary>
    /// <param name="context">
    /// Contexto do Entity Framework utilizado para acesso ao banco de dados.
    /// </param>
    public TransactionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Persiste uma nova transação no banco de dados.
    /// </summary>
    /// <param name="transaction">
    /// Transação que será cadastrada.
    /// </param>
    /// <returns>
    /// Retorna a transação criada.
    /// </returns>
    public async Task<Transaction> CreateAsync(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        return transaction;
    }

    /// <summary>
    /// Obtém uma transação pelo seu identificador.
    /// A entidade <see cref="Person"/> relacionada é carregada
    /// juntamente com a transação.
    /// </summary>
    /// <param name="id">
    /// Identificador único da transação.
    /// </param>
    /// <returns>
    /// A transação encontrada ou <c>null</c> caso ela não exista.
    /// </returns>
    public async Task<Transaction?> GetByIdAsync(Guid id)
    {
        return await _context.Transactions
            .Include(t => t.Person)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    /// <summary>
    /// Obtém todas as transações cadastradas.
    /// As respectivas pessoas associadas são carregadas
    /// juntamente com cada transação.
    /// </summary>
    /// <returns>
    /// Uma coleção contendo todas as transações.
    /// </returns>
    public async Task<IEnumerable<Transaction>> GetAllAsync()
    {
        return await _context.Transactions
            .Include(t => t.Person)
            .ToListAsync();
    }
}