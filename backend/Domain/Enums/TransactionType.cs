namespace financas.Domain.Enums;

/// <summary>
/// Representa os tipos de transações financeiras suportados pelo sistema.
/// </summary>
public enum TransactionType
{
    /// <summary>
    /// Indica uma despesa, ou seja, um valor que reduz o saldo financeiro.
    /// </summary>
    Expense = 0,

    /// <summary>
    /// Indica uma receita, ou seja, um valor que aumenta o saldo financeiro.
    /// </summary>
    Income = 1
}