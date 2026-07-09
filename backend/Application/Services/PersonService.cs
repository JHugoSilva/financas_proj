using financas.Application.DTOs.Person;
using financas.Application.Interfaces;
using financas.Domain.Entities;
using financas.Infrastructure.Interfaces;
using financas.Domain.Enums;

namespace financas.Application.Services;

public class PersonService : IPersonService
{
  private readonly IPersonRepository _personRepository;

  public PersonService(IPersonRepository personRepository)
  {
    _personRepository = personRepository;
  }

  public async Task<PersonDto> CreatePersonAsync(CreatePersonDto createPersonDto)
  {
    var person = new Person(
      createPersonDto.Name,
      createPersonDto.Age
    );

    var createdPerson = await _personRepository.CreateAsync(person);

    return ToDto(createdPerson);
  }

  public async Task<PersonDto?> GetPersonByIdAsync(Guid id)
  {
    var person = await _personRepository.GetByIdAsync(id);
    if (person == null)
    {
      return null;
    }

    return ToDto(person);
  }

  public async Task<IEnumerable<PersonDto>> GetAllPersonsAsync()
  {
    var persons = await _personRepository.GetAllAsync();
    return persons.Select(p => new PersonDto
    {
      Id = p.Id,
      Name = p.Name,
      Age = p.Age
    });
  }

  public async Task<PersonDto?> UpdatePersonAsync(Guid id, UpdatePersonDto updatePersonDto)
  {
    var personToUpdate = await _personRepository.GetByIdAsync(id);

    if (personToUpdate == null)
    {
      return null;
    }

    personToUpdate.Name = updatePersonDto.Name;
    personToUpdate.Age = updatePersonDto.Age;

    var updatedPerson = await _personRepository.UpdateAsync(personToUpdate);

    return ToDto(updatedPerson);
  }

  public async Task<bool> DeletePersonAsync(Guid id)
  {
    var personToDelete = await _personRepository.GetByIdAsync(id);
    if (personToDelete == null)
    {
      return false;
    }

    await _personRepository.DeleteAsync(id);
    return true;
  }

  public async Task<SummaryResponseDto> GetSummaryAsync()
  {
    var persons = await _personRepository.GetPersonsWithTransactionsAsync();
    var summaryResponse = new SummaryResponseDto
    {
      Persons = persons.Select(p => new PersonSummaryDto
      {
        Id = p.Id,
        Name = p.Name,
        Age = p.Age,
        Receitas = p.Transactions.Where(t => t.Type == TransactionType.Income).Sum(t => t.Amount),
        Despesas = p.Transactions.Where(t => t.Type == TransactionType.Expense).Sum(t => t.Amount)
      }).ToList()
    };

    summaryResponse.TotalReceitas = summaryResponse.Persons.Sum(p => p.Receitas);
    summaryResponse.TotalDespesas = summaryResponse.Persons.Sum(p => p.Despesas);

    return summaryResponse;

  }

  private static PersonDto ToDto(Person person)
  {
    return new PersonDto
    {
      Id = person.Id,
      Name = person.Name,
      Age = person.Age
    };
  }
}