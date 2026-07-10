using financas.Application.DTOs.Transaction;
using financas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace financas.Api.Controllers;

/// <summary>
/// Controller responsável pelo gerenciamento das transações financeiras.
/// Disponibiliza endpoints para criação e consulta de transações.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    /// <summary>
    /// Serviço responsável pelas regras de negócio das transações.
    /// </summary>
    private readonly ITransactionService _transactionService;

    /// <summary>
    /// Inicializa uma nova instância do controller de transações.
    /// </summary>
    /// <param name="transactionService">
    /// Serviço responsável pelas operações de transações financeiras.
    /// </param>
    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    /// <summary>
    /// Cria uma nova transação financeira.
    /// </summary>
    /// <param name="transaction">
    /// Dados necessários para criação da transação.
    /// </param>
    /// <returns>
    /// Retorna a transação criada ou uma mensagem de erro caso a operação falhe.
    /// </returns>
    /// <response code="201">
    /// Transação criada com sucesso.
    /// </response>
    /// <response code="400">
    /// Dados inválidos ou regra de negócio não permitida.
    /// </response>
    [HttpPost]
    public async Task<IActionResult> CreateTransaction(
        [FromBody] CreateTransactionDto transaction)
    {
        var createdTransaction =
            await _transactionService.CreateTransactionAsync(transaction);

        if (!createdTransaction.Success)
        {
            return BadRequest(new
            {
                message = createdTransaction.Message
            });
        }

        return CreatedAtAction(
            nameof(GetTransactionById),
            new { id = createdTransaction.Data!.Id },
            createdTransaction.Data);
    }

    /// <summary>
    /// Obtém uma transação pelo seu identificador.
    /// </summary>
    /// <param name="id">
    /// Identificador único da transação.
    /// </param>
    /// <returns>
    /// Retorna os dados da transação encontrada.
    /// </returns>
    /// <response code="200">
    /// Transação encontrada.
    /// </response>
    /// <response code="404">
    /// Transação não encontrada.
    /// </response>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTransactionById(Guid id)
    {
        var transaction =
            await _transactionService.GetTransactionByIdAsync(id);

        if (!transaction.Success)
        {
            return NotFound(new
            {
                message = transaction.Message
            });
        }

        return Ok(transaction.Data);
    }

    /// <summary>
    /// Obtém todas as transações cadastradas.
    /// </summary>
    /// <returns>
    /// Lista contendo todas as transações financeiras.
    /// </returns>
    /// <response code="200">
    /// Lista retornada com sucesso.
    /// </response>
    [HttpGet]
    public async Task<IActionResult> GetAllTransactions()
    {
        var transactions =
            await _transactionService.GetAllTransactionsAsync();

        return Ok(transactions);
    }
}