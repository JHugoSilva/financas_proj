using financas.Application.DTOs.Person;

namespace financas.Application.Interfaces;

public interface IPersonService
{
    Task<PersonDto> CreatePersonAsync(CreatePersonDto createPersonDto);
    Task<PersonDto?> GetPersonByIdAsync(Guid id);
    Task<IEnumerable<PersonDto>> GetAllPersonsAsync();
    Task<PersonDto?> UpdatePersonAsync(Guid id, UpdatePersonDto updatePersonDto);
    Task<bool> DeletePersonAsync(Guid id);
    Task<SummaryResponseDto> GetSummaryAsync();
}