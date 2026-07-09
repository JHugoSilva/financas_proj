using financas.Domain.Entities;

namespace financas.Infrastructure.Interfaces;

public interface IPersonRepository
{
    Task<Person> CreateAsync(Person person);
    Task<Person?> GetByIdAsync(Guid id);
    Task<IEnumerable<Person>> GetAllAsync();
    Task<Person> UpdateAsync(Person person);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Person>> GetPersonsWithTransactionsAsync();
}