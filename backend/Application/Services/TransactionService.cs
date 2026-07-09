using financas.Application.DTOs.Transaction;
using financas.Application.DTOs.Person;
using financas.Application.Interfaces;
using financas.Domain.Entities;
using financas.Infrastructure.Interfaces;
using financas.Application.DTOs;

namespace financas.Application.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IPersonRepository _personRepository;

    public TransactionService(ITransactionRepository transactionRepository, IPersonRepository personRepository)
    {
        _transactionRepository = transactionRepository;
        _personRepository = personRepository;
    }

    public async Task<ServiceResult<TransactionDto>> CreateTransactionAsync(CreateTransactionDto createTransactionDto)
    {

        var person = await _personRepository.GetByIdAsync(createTransactionDto.PersonId);

        if (person is null)
        {
            return new ServiceResult<TransactionDto>
            {
                Success = false,
                Message = "Person not found",
            };
        }

        var age = person.Age;

        if (age < 18 && createTransactionDto.Type == Domain.Enums.TransactionType.Income)
        {
            return new ServiceResult<TransactionDto>
            {
                Success = false,
                Message = "Pessoas menores de 18 anos só podem criar despesas.",
                Data = null
            };
        }

        var transaction = new Transaction(
          createTransactionDto.Amount,
          createTransactionDto.Description,
          createTransactionDto.Type,
          createTransactionDto.PersonId
        );

        var createdTransaction = await _transactionRepository.CreateAsync(transaction);

        return new ServiceResult<TransactionDto>
        {
            Success = true,
            Message = null,
            Data = new TransactionDto
            {
                Amount = createdTransaction.Amount,
                Description = createdTransaction.Description,
                PersonId = createdTransaction.PersonId,
                Type = createdTransaction.Type
            }
        };
    }

    public async Task<ServiceResult<TransactionDto?>> GetTransactionByIdAsync(Guid id)
    {
        var transaction = await _transactionRepository.GetByIdAsync(id);
        if (transaction == null)
        {
            return new ServiceResult<TransactionDto?>
            {
                Success = false,
                Message = "Transaction not found",
                Data = null
            };
        }

        return new ServiceResult<TransactionDto?>
        {
            Success = true,
            Message = null,
            Data = new TransactionDto
            {
                Amount = transaction.Amount,
                Description = transaction.Description,
                PersonId = transaction.PersonId,
                Type = transaction.Type,
                Person = transaction.Person != null ? new PersonDto
                {
                    Id = transaction.Person.Id,
                    Name = transaction.Person.Name,
                    Age = transaction.Person.Age
                } : null
            }
        };
    }

    public async Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync()
    {
        var transactions = await _transactionRepository.GetAllAsync();
        return transactions.Select(t => new TransactionDto
        {
            Id = t.Id,
            Amount = t.Amount,
            Description = t.Description,
            PersonId = t.PersonId,
            Type = t.Type,
            Person = t.Person != null ? new PersonDto
            {
                Id = t.Person.Id,
                Name = t.Person.Name,
                Age = t.Person.Age
            } : null
        });
    }
}