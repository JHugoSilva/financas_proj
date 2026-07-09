using financas.Domain.Entities;
using financas.Infrastructure.Data;
using financas.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace financas.Infrastructure.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly ApplicationDbContext _context;

    public PersonRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Person> CreateAsync(Person person)
    {
        _context.Persons.Add(person);
        await _context.SaveChangesAsync();
        return person;
    }

    public async Task<Person?> GetByIdAsync(Guid id) => await _context.Persons.FindAsync(id);

    public async Task<IEnumerable<Person>> GetAllAsync() => await _context.Persons.ToListAsync();

    public async Task<Person> UpdateAsync(Person person)
    {
        _context.Persons.Update(person);
        await _context.SaveChangesAsync();
        return person;
    }

    public async Task DeleteAsync(Guid id)
    {
        var person = await _context.Persons.FindAsync(id);
        if (person != null)
        {
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Person>> GetPersonsWithTransactionsAsync()
    {
        return await _context.Persons
          .Include(p => p.Transactions)
          .ToListAsync();
    }
}