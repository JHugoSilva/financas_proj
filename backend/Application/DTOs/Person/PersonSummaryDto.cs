namespace financas.Application.DTOs.Person;

public class PersonSummaryDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    public decimal Receitas { get; set; }
    public decimal Despesas { get; set; }
    public decimal Saldo => Receitas - Despesas;
}