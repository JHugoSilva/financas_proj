using financas.Application.DTOs.Person;
using financas.Domain.Enums;

namespace financas.Application.DTOs.Transaction;

/// <summary>
/// DTO utilizado para representar uma transação financeira
/// nas respostas da API.
/// </summary>
public class TransactionDto
{
    /// <summary>
    /// Identificador único da transação.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Valor monetário da transação.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Descrição da transação.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Identificador da pessoa proprietária da transação.
    /// </summary>
    public Guid PersonId { get; set; }

    /// <summary>
    /// Tipo da transação.
    /// Pode representar uma receita (<see cref="TransactionType.Income"/>)
    /// ou uma despesa (<see cref="TransactionType.Expense"/>).
    /// </summary>
    public TransactionType Type { get; set; }

    /// <summary>
    /// Dados da pessoa associada à transação.
    /// Pode ser nulo caso a pessoa não tenha sido carregada na consulta.
    /// </summary>
    public PersonDto? Person { get; set; }
}