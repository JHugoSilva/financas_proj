using financas.Application.DTOs;
using financas.Application.DTOs.Transaction;

namespace financas.Application.Interfaces;

public interface ITransactionService
{
    Task<ServiceResult<TransactionDto>> CreateTransactionAsync(CreateTransactionDto createTransactionDto);
    Task<ServiceResult<TransactionDto?>> GetTransactionByIdAsync(Guid id);
    Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync();
}