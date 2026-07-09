using System.ComponentModel.DataAnnotations;
using financas.Domain.Enums;
namespace financas.Application.DTOs.Transaction;

public class CreateTransactionDto
{
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
    public decimal Amount { get; set; }
    [Required]
    [StringLength(200, ErrorMessage = "Description must be a maximum of 200 characters.")]
    public required string Description { get; set; }
    [Required]
    public Guid PersonId { get; set; }
    [Required]
    public TransactionType Type { get; set; }
}