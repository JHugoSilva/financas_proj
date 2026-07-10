using financas.Domain.Entities;
using financas.Infrastructure.Data;
using financas.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace financas.Infrastructure.Repositories;

/// <summary>
/// Implementação do repositório responsável pelo acesso aos dados da entidade Person.
/// Utiliza o Entity Framework Core para realizar operações de persistência no banco de dados.
/// </summary>
public class PersonRepository : IPersonRepository
{
    /// <summary>
    /// Contexto de acesso ao banco de dados.
    /// </summary>
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Inicializa uma nova instância do repositório de pessoas.
    /// </summary>
    /// <param name="context">Contexto do Entity Framework.</param>
    public PersonRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Cria uma nova pessoa no banco de dados.
    /// </summary>
    /// <param name="person">Objeto da pessoa a ser persistido.</param>
    /// <returns>Retorna a pessoa criada.</returns>
    public async Task<Person> CreateAsync(Person person)
    {
        _context.Persons.Add(person);
        await _context.SaveChangesAsync();
        return person;
    }

    /// <summary>
    /// Busca uma pessoa pelo seu identificador.
    /// </summary>
    /// <param name="id">Identificador único da pessoa.</param>
    /// <returns>
    /// A pessoa encontrada ou <c>null</c> caso não exista.
    /// </returns>
    public async Task<Person?> GetByIdAsync(Guid id) => await _context.Persons.FindAsync(id);

    /// <summary>
    /// Retorna todas as pessoas cadastradas.
    /// </summary>
    /// <returns>Lista de pessoas.</returns>
    public async Task<IEnumerable<Person>> GetAllAsync() => await _context.Persons.ToListAsync();

    /// <summary>
    /// Atualiza os dados de uma pessoa existente.
    /// </summary>
    /// <param name="person">Pessoa contendo os novos dados.</param>
    /// <returns>A pessoa atualizada.</returns>
    public async Task<Person> UpdateAsync(Person person)
    {
        _context.Persons.Update(person);
        await _context.SaveChangesAsync();
        return person;
    }

    /// <summary>
    /// Remove uma pessoa do banco de dados.
    /// Caso a pessoa não seja encontrada, nenhuma ação é realizada.
    /// </summary>
    /// <param name="id">Identificador da pessoa.</param>
    public async Task DeleteAsync(Guid id)
    {
        var person = await _context.Persons.FindAsync(id);
        if (person != null)
        {
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Retorna todas as pessoas juntamente com suas transações.
    /// Utiliza <see cref="EntityFrameworkQueryableExtensions.Include{TEntity, TProperty}"/>
    /// para carregar os dados relacionados em uma única consulta.
    /// </summary>
    /// <returns>Lista de pessoas com suas respectivas transações.</returns>
    public async Task<IEnumerable<Person>> GetPersonsWithTransactionsAsync()
    {
        return await _context.Persons
          .Include(p => p.Transactions)
          .ToListAsync();
    }
}