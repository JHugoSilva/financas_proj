using financas.Domain.Enums;

namespace financas.Domain.Entities;

/// <summary>
/// Representa uma transação financeira vinculada a uma pessoa.
/// Uma transação pode ser do tipo receita ou despesa.
/// </summary>
public class Transaction
{
    /// <summary>
    /// Identificador único da transação.
    /// O valor é gerado automaticamente na criação da entidade.
    /// </summary>
    public Guid Id { get; private set; } = Guid.NewGuid();

    /// <summary>
    /// Valor monetário da transação.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Descrição da transação.
    /// Utilizada para identificar ou detalhar sua finalidade.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Tipo da transação (Receita ou Despesa).
    /// </summary>
    public TransactionType Type { get; set; }

    /// <summary>
    /// Identificador da pessoa à qual a transação pertence.
    /// Chave estrangeira para a entidade <see cref="Person"/>.
    /// </summary>
    public Guid PersonId { get; set; }

    /// <summary>
    /// Propriedade de navegação para a pessoa proprietária da transação.
    /// Representa o relacionamento muitos-para-um entre
    /// <see cref="Transaction"/> e <see cref="Person"/>.
    /// </summary>
    public Person? Person { get; set; } = null!;

    /// <summary>
    /// Inicializa uma nova instância da entidade <see cref="Transaction"/>.
    /// </summary>
    /// <param name="amount">Valor da transação.</param>
    /// <param name="description">Descrição da transação.</param>
    /// <param name="type">Tipo da transação (Receita ou Despesa).</param>
    /// <param name="personId">Identificador da pessoa proprietária da transação.</param>
    public Transaction(
        decimal amount,
        string description,
        TransactionType type,
        Guid personId)
    {
        Amount = amount;
        Description = description;
        Type = type;
        PersonId = personId;
    }
}