namespace financas.Application.DTOs.Person;

public class SummaryResponseDto
{
    public List<PersonSummaryDto> Persons { get; set; } = [];
    public decimal TotalReceitas { get; set; }
    public decimal TotalDespesas { get; set; }
    public decimal TotalSaldo => TotalReceitas - TotalDespesas;
}