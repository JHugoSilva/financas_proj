using financas.Application.DTOs;
using financas.Application.DTOs.Transaction;

namespace financas.Application.Interfaces;

/// <summary>
/// Define os serviços responsáveis pelas regras de negócio
/// relacionadas às transações financeiras.
/// </summary>
public interface ITransactionService
{
    /// <summary>
    /// Cria uma nova transação financeira.
    /// </summary>
    /// <param name="createTransactionDto">
    /// Dados necessários para o cadastro da transação.
    /// </param>
    /// <returns>
    /// Um <see cref="ServiceResult{T}"/> contendo o status da operação,
    /// uma mensagem e os dados da transação criada.
    /// </returns>
    Task<ServiceResult<TransactionDto>> CreateTransactionAsync(
        CreateTransactionDto createTransactionDto);

    /// <summary>
    /// Obtém uma transação pelo seu identificador.
    /// </summary>
    /// <param name="id">
    /// Identificador único da transação.
    /// </param>
    /// <returns>
    /// Um <see cref="ServiceResult{T}"/> contendo a transação encontrada
    /// ou <c>null</c> caso ela não exista.
    /// </returns>
    Task<ServiceResult<TransactionDto?>> GetTransactionByIdAsync(Guid id);

    /// <summary>
    /// Obtém todas as transações cadastradas.
    /// </summary>
    /// <returns>
    /// Uma coleção contendo todas as transações.
    /// </returns>
    Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync();
}