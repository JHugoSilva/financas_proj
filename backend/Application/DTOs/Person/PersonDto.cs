namespace financas.Application.DTOs.Person;

/// <summary>
/// DTO utilizado para representar os dados de uma pessoa
/// nas respostas da API.
/// </summary>
public class PersonDto
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
}