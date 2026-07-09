using financas.Application.DTOs.Person;
using financas.Domain.Enums;

namespace financas.Application.DTOs.Transaction;

public class TransactionDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Amount { get; set; }
    public required string Description { get; set; }
    public Guid PersonId { get; set; }
    public TransactionType Type { get; set; }
    public PersonDto? Person { get; set; }
}