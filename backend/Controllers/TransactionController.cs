using financas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using financas.Application.DTOs.Transaction;

namespace financas.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionDto transaction)
    {
        var createdTransaction = await _transactionService.CreateTransactionAsync(transaction);
        if (!createdTransaction.Success)
        {
            return BadRequest(new { message = createdTransaction.Message });
        }
        return CreatedAtAction(nameof(GetTransactionById), new { id = createdTransaction.Data!.Id }, createdTransaction.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTransactionById(Guid id)
    {
        var transaction = await _transactionService.GetTransactionByIdAsync(id);
        if (!transaction.Success)
        {
            return NotFound(new
            {
                message = transaction.Message
            });
        }
        return Ok(transaction.Data);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTransactions()
    {
        var transactions = await _transactionService.GetAllTransactionsAsync();
        return Ok(transactions);
    }
}