namespace financas.Application.DTOs.Person;

/// <summary>
/// DTO utilizado para representar o resumo financeiro geral da aplicação,
/// contendo a lista de pessoas e os totais consolidados de receitas,
/// despesas e saldo.
/// </summary>
public class SummaryResponseDto
{
    /// <summary>
    /// Lista contendo o resumo financeiro de cada pessoa.
    /// </summary>
    public List<PersonSummaryResponseDto> Persons { get; set; } = [];

    /// <summary>
    /// Soma de todas as receitas das pessoas.
    /// </summary>
    public decimal TotalReceitas { get; set; }

    /// <summary>
    /// Soma de todas as despesas das pessoas.
    /// </summary>
    public decimal TotalDespesas { get; set; }

    /// <summary>
    /// Saldo financeiro total.
    /// Calculado automaticamente pela diferença entre as receitas
    /// e as despesas consolidadas.
    /// </summary>
    public decimal TotalSaldo => TotalReceitas - TotalDespesas;
}