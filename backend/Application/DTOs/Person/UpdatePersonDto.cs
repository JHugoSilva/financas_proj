using System.ComponentModel.DataAnnotations;

namespace financas.Application.DTOs.Person;

public class UpdatePersonDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(2, ErrorMessage = "O nome deve ter no mínimo 2 caracteres.")]
    [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public required string Name { get; set; }
    [Range(0, 150, ErrorMessage = "A idade deve estar entre 0 e 150.")]
    public int Age { get; set; }
}