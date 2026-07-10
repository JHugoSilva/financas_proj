using financas.Application.DTOs.Person;
using financas.Application.Interfaces;
using financas.Domain.Entities;
using financas.Domain.Enums;
using financas.Infrastructure.Interfaces;

namespace financas.Application.Services;

/// <summary>
/// Implementação dos serviços responsáveis pelas regras de negócio
/// relacionadas à entidade <see cref="Person"/>.
/// Atua como intermediária entre os controllers e a camada de persistência.
/// </summary>
public class PersonService : IPersonService
{
  /// <summary>
  /// Repositório utilizado para acesso aos dados de pessoas.
  /// </summary>
  private readonly IPersonRepository _personRepository;

  /// <summary>
  /// Inicializa uma nova instância do serviço de pessoas.
  /// </summary>
  /// <param name="personRepository">
  /// Repositório responsável pelas operações de persistência.
  /// </param>
  public PersonService(IPersonRepository personRepository)
  {
    _personRepository = personRepository;
  }

  /// <summary>
  /// Cria uma nova pessoa.
  /// </summary>
  /// <param name="createPersonDto">
  /// Dados utilizados para o cadastro da pessoa.
  /// </param>
  /// <returns>
  /// Retorna os dados da pessoa criada.
  /// </returns>
  public async Task<PersonDto> CreatePersonAsync(CreatePersonDto createPersonDto)
  {
    var person = new Person(
        createPersonDto.Name,
        createPersonDto.Age
    );

    var createdPerson = await _personRepository.CreateAsync(person);

    return ToDto(createdPerson);
  }

  /// <summary>
  /// Obtém uma pessoa pelo seu identificador.
  /// </summary>
  /// <param name="id">Identificador único da pessoa.</param>
  /// <returns>
  /// Os dados da pessoa encontrada ou <c>null</c> caso ela não exista.
  /// </returns>
  public async Task<PersonDto?> GetPersonByIdAsync(Guid id)
  {
    var person = await _personRepository.GetByIdAsync(id);

    if (person == null)
    {
      return null;
    }

    return ToDto(person);
  }

  /// <summary>
  /// Obtém todas as pessoas cadastradas.
  /// </summary>
  /// <returns>
  /// Uma coleção de pessoas.
  /// </returns>
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

  /// <summary>
  /// Atualiza os dados de uma pessoa existente.
  /// </summary>
  /// <param name="id">Identificador da pessoa.</param>
  /// <param name="updatePersonDto">
  /// Dados utilizados para atualização.
  /// </param>
  /// <returns>
  /// Retorna a pessoa atualizada ou <c>null</c> caso ela não seja encontrada.
  /// </returns>
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

  /// <summary>
  /// Remove uma pessoa do sistema.
  /// </summary>
  /// <param name="id">Identificador da pessoa.</param>
  /// <returns>
  /// <c>true</c> caso a exclusão seja realizada com sucesso;
  /// caso contrário, <c>false</c>.
  /// </returns>
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

  /// <summary>
  /// Obtém um resumo financeiro contendo todas as pessoas,
  /// seus totais de receitas, despesas e saldo consolidado.
  /// </summary>
  /// <returns>
  /// Um objeto contendo o resumo financeiro da aplicação.
  /// </returns>
  public async Task<SummaryResponseDto> GetSummaryAsync()
  {
    var persons = await _personRepository.GetPersonsWithTransactionsAsync();

    var summaryResponse = new SummaryResponseDto
    {
      Persons = persons.Select(p => new PersonSummaryResponseDto
      {
        Id = p.Id,
        Name = p.Name,
        Age = p.Age,
        Receitas = p.Transactions
              .Where(t => t.Type == TransactionType.Income)
              .Sum(t => t.Amount),
        Despesas = p.Transactions
              .Where(t => t.Type == TransactionType.Expense)
              .Sum(t => t.Amount)
      }).ToList()
    };

    summaryResponse.TotalReceitas =
        summaryResponse.Persons.Sum(p => p.Receitas);

    summaryResponse.TotalDespesas =
        summaryResponse.Persons.Sum(p => p.Despesas);

    return summaryResponse;
  }

  /// <summary>
  /// Converte uma entidade <see cref="Person"/> em um
  /// objeto de transferência de dados (<see cref="PersonDto"/>).
  /// </summary>
  /// <param name="person">Entidade a ser convertida.</param>
  /// <returns>
  /// Um <see cref="PersonDto"/> contendo os dados da pessoa.
  /// </returns>
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