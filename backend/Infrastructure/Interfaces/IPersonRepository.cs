using financas.Domain.Entities;

namespace financas.Infrastructure.Interfaces;

/// <summary>
/// Define as operações de acesso aos dados da entidade <see cref="Person"/>.
/// Segue o padrão Repository, abstraindo a camada de persistência.
/// </summary>
public interface IPersonRepository
{
    /// <summary>
    /// Persiste uma nova pessoa no banco de dados.
    /// </summary>
    /// <param name="person">Objeto da pessoa a ser cadastrada.</param>
    /// <returns>Retorna a pessoa criada.</returns>
    Task<Person> CreateAsync(Person person);

    /// <summary>
    /// Obtém uma pessoa pelo seu identificador.
    /// </summary>
    /// <param name="id">Identificador único da pessoa.</param>
    /// <returns>
    /// A pessoa encontrada ou <c>null</c> caso não exista.
    /// </returns>
    Task<Person?> GetByIdAsync(Guid id);

    /// <summary>
    /// Retorna todas as pessoas cadastradas.
    /// </summary>
    /// <returns>Uma coleção contendo todas as pessoas.</returns>
    Task<IEnumerable<Person>> GetAllAsync();

    /// <summary>
    /// Atualiza as informações de uma pessoa existente.
    /// </summary>
    /// <param name="person">Objeto contendo os dados atualizados.</param>
    /// <returns>Retorna a pessoa após a atualização.</returns>
    Task<Person> UpdateAsync(Person person);

    /// <summary>
    /// Remove uma pessoa do banco de dados.
    /// </summary>
    /// <param name="id">Identificador da pessoa que será removida.</param>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Retorna todas as pessoas juntamente com suas respectivas transações.
    /// </summary>
    /// <returns>
    /// Uma coleção de pessoas com suas transações carregadas.
    /// </returns>
    Task<IEnumerable<Person>> GetPersonsWithTransactionsAsync();
}