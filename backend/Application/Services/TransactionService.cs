using financas.Application.DTOs;
using financas.Application.DTOs.Person;
using financas.Application.DTOs.Transaction;
using financas.Application.Interfaces;
using financas.Domain.Entities;
using financas.Infrastructure.Interfaces;

namespace financas.Application.Services;

/// <summary>
/// Implementação dos serviços responsáveis pelas regras de negócio
/// relacionadas às transações financeiras.
/// Atua como intermediária entre os controllers e a camada de persistência.
/// </summary>
public class TransactionService : ITransactionService
{
    /// <summary>
    /// Repositório responsável pelas operações de persistência das transações.
    /// </summary>
    private readonly ITransactionRepository _transactionRepository;

    /// <summary>
    /// Repositório responsável pelas operações de persistência das pessoas.
    /// </summary>
    private readonly IPersonRepository _personRepository;

    /// <summary>
    /// Inicializa uma nova instância do serviço de transações.
    /// </summary>
    /// <param name="transactionRepository">
    /// Repositório de transações.
    /// </param>
    /// <param name="personRepository">
    /// Repositório de pessoas.
    /// </param>
    public TransactionService(
        ITransactionRepository transactionRepository,
        IPersonRepository personRepository)
    {
        _transactionRepository = transactionRepository;
        _personRepository = personRepository;
    }

    /// <summary>
    /// Cria uma nova transação financeira.
    /// Antes da criação, valida se a pessoa existe e aplica
    /// as regras de negócio da aplicação.
    /// </summary>
    /// <param name="createTransactionDto">
    /// Dados necessários para criação da transação.
    /// </param>
    /// <returns>
    /// Um objeto contendo o resultado da operação e os dados
    /// da transação criada, quando bem-sucedida.
    /// </returns>
    public async Task<ServiceResult<TransactionDto>> CreateTransactionAsync(
        CreateTransactionDto createTransactionDto)
    {
        var person = await _personRepository.GetByIdAsync(createTransactionDto.PersonId);

        if (person is null)
        {
            return new ServiceResult<TransactionDto>
            {
                Success = false,
                Message = "Person not found"
            };
        }

        var age = person.Age;

        // Regra de negócio:
        // Pessoas menores de 18 anos podem registrar apenas despesas.
        if (age < 18 &&
            createTransactionDto.Type == Domain.Enums.TransactionType.Income)
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
            createTransactionDto.PersonId);

        var createdTransaction =
            await _transactionRepository.CreateAsync(transaction);

        return new ServiceResult<TransactionDto>
        {
            Success = true,
            Message = null,
            Data = new TransactionDto
            {
                Id = createdTransaction.Id,
                Amount = createdTransaction.Amount,
                Description = createdTransaction.Description,
                PersonId = createdTransaction.PersonId,
                Type = createdTransaction.Type
            }
        };
    }

    /// <summary>
    /// Obtém uma transação pelo seu identificador.
    /// </summary>
    /// <param name="id">
    /// Identificador da transação.
    /// </param>
    /// <returns>
    /// Um objeto contendo o resultado da operação e os dados
    /// da transação encontrada.
    /// </returns>
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
            Data = new TransactionDto
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                Description = transaction.Description,
                PersonId = transaction.PersonId,
                Type = transaction.Type,
                Person = transaction.Person != null
                    ? new PersonDto
                    {
                        Id = transaction.Person.Id,
                        Name = transaction.Person.Name,
                        Age = transaction.Person.Age
                    }
                    : null
            }
        };
    }

    /// <summary>
    /// Obtém todas as transações cadastradas.
    /// Cada transação pode conter também os dados da pessoa associada.
    /// </summary>
    /// <returns>
    /// Uma coleção contendo todas as transações.
    /// </returns>
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
            Person = t.Person != null
                ? new PersonDto
                {
                    Id = t.Person.Id,
                    Name = t.Person.Name,
                    Age = t.Person.Age
                }
                : null
        });
    }
}