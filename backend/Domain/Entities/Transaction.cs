using financas.Domain.Enums;

namespace financas.Domain.Entities;

public class Transaction
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public TransactionType Type { get; set; }
    public Guid PersonId { get; set; }
    public Person? Person { get; set; } = null!;
    public Transaction(decimal amount, string description, TransactionType type, Guid personId)
    {
        Amount = amount;
        Description = description;
        Type = type;
        PersonId = personId;
    }
}