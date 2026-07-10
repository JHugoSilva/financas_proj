using financas.Domain.Entities;

namespace financas.Infrastructure.Interfaces;

/// <summary>
/// Define as operações de acesso aos dados da entidade
/// <see cref="Transaction"/>.
/// Segue o padrão Repository, abstraindo a camada de persistência.
/// </summary>
public interface ITransactionRepository
{
    /// <summary>
    /// Persiste uma nova transação no banco de dados.
    /// </summary>
    /// <param name="transaction">
    /// Transação que será cadastrada.
    /// </param>
    /// <returns>
    /// Retorna a transação criada.
    /// </returns>
    Task<Transaction> CreateAsync(Transaction transaction);

    /// <summary>
    /// Obtém uma transação pelo seu identificador.
    /// </summary>
    /// <param name="id">
    /// Identificador único da transação.
    /// </param>
    /// <returns>
    /// A transação encontrada ou <c>null</c> caso ela não exista.
    /// </returns>
    Task<Transaction?> GetByIdAsync(Guid id);

    /// <summary>
    /// Obtém todas as transações cadastradas.
    /// </summary>
    /// <returns>
    /// Uma coleção contendo todas as transações.
    /// </returns>
    Task<IEnumerable<Transaction>> GetAllAsync();
}