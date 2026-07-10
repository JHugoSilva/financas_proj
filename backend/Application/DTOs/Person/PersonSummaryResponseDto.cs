namespace financas.Application.DTOs.Person;

/// <summary>
/// DTO utilizado para representar o resumo financeiro de uma pessoa,
/// contendo suas informações básicas e os totais de receitas, despesas
/// e saldo.
/// </summary>
public class PersonSummaryResponseDto
{
    /// <summary>
    /// Identificador único da pessoa.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Nome da pessoa.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Idade da pessoa.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Valor total das receitas da pessoa.
    /// </summary>
    public decimal Receitas { get; set; }

    /// <summary>
    /// Valor total das despesas da pessoa.
    /// </summary>
    public decimal Despesas { get; set; }

    /// <summary>
    /// Saldo financeiro da pessoa.
    /// Calculado automaticamente pela diferença entre receitas e despesas.
    /// </summary>
    public decimal Saldo => Receitas - Despesas;
}