using System.ComponentModel.DataAnnotations;

namespace financas.Application.DTOs.Person;

/// <summary>
/// DTO utilizado para receber os dados necessários para o cadastro
/// de uma nova pessoa.
/// Contém regras de validação aplicadas através de Data Annotations.
/// </summary>
public class CreatePersonDto
{
    /// <summary>
    /// Nome da pessoa.
    /// Deve possuir entre 2 e 100 caracteres.
    /// </summary>
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(2, ErrorMessage = "O nome deve ter no mínimo 2 caracteres.")]
    [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public required string Name { get; set; }

    /// <summary>
    /// Idade da pessoa.
    /// Deve estar compreendida entre 0 e 150 anos.
    /// </summary>
    [Required(ErrorMessage = "A idade é obrigatória.")]
    [Range(0, 150, ErrorMessage = "A idade deve estar entre 0 e 150.")]
    public int Age { get; set; }
}