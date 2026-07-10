using System.ComponentModel.DataAnnotations;
using financas.Domain.Enums;

namespace financas.Application.DTOs.Transaction;

/// <summary>
/// DTO utilizado para receber os dados necessários para o cadastro
/// de uma nova transação financeira.
/// Contém regras de validação aplicadas através de Data Annotations.
/// </summary>
public class CreateTransactionDto
{
    /// <summary>
    /// Valor da transação.
    /// Deve ser maior que zero.
    /// </summary>
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
    public decimal Amount { get; set; }

    /// <summary>
    /// Descrição da transação.
    /// Deve possuir no máximo 200 caracteres.
    /// </summary>
    [Required]
    [StringLength(200, ErrorMessage = "Description must be a maximum of 200 characters.")]
    public required string Description { get; set; }

    /// <summary>
    /// Identificador da pessoa à qual a transação será vinculada.
    /// </summary>
    [Required]
    public Guid PersonId { get; set; }

    /// <summary>
    /// Tipo da transação.
    /// Pode ser Receita (<see cref="TransactionType.Income"/>) ou
    /// Despesa (<see cref="TransactionType.Expense"/>).
    /// </summary>
    [Required]
    public TransactionType Type { get; set; }
}