using financas.Application.DTOs.Person;

namespace financas.Application.Interfaces;

/// <summary>
/// Define os serviços responsáveis pelas regras de negócio relacionadas
/// à entidade Person.
/// </summary>
public interface IPersonService
{
    /// <summary>
    /// Cria uma nova pessoa.
    /// </summary>
    /// <param name="createPersonDto">
    /// Dados necessários para o cadastro da pessoa.
    /// </param>
    /// <returns>
    /// Retorna os dados da pessoa criada.
    /// </returns>
    Task<PersonDto> CreatePersonAsync(CreatePersonDto createPersonDto);

    /// <summary>
    /// Obtém uma pessoa pelo seu identificador.
    /// </summary>
    /// <param name="id">Identificador único da pessoa.</param>
    /// <returns>
    /// Retorna os dados da pessoa, ou <c>null</c> caso ela não exista.
    /// </returns>
    Task<PersonDto?> GetPersonByIdAsync(Guid id);

    /// <summary>
    /// Obtém todas as pessoas cadastradas.
    /// </summary>
    /// <returns>
    /// Uma coleção contendo os dados de todas as pessoas.
    /// </returns>
    Task<IEnumerable<PersonDto>> GetAllPersonsAsync();

    /// <summary>
    /// Atualiza os dados de uma pessoa existente.
    /// </summary>
    /// <param name="id">Identificador da pessoa.</param>
    /// <param name="updatePersonDto">
    /// Dados utilizados para atualização.
    /// </param>
    /// <returns>
    /// Retorna os dados atualizados da pessoa, ou <c>null</c> caso ela não seja encontrada.
    /// </returns>
    Task<PersonDto?> UpdatePersonAsync(Guid id, UpdatePersonDto updatePersonDto);

    /// <summary>
    /// Remove uma pessoa do sistema.
    /// </summary>
    /// <param name="id">Identificador da pessoa.</param>
    /// <returns>
    /// <c>true</c> se a pessoa foi removida com sucesso; caso contrário, <c>false</c>.
    /// </returns>
    Task<bool> DeletePersonAsync(Guid id);

    /// <summary>
    /// Obtém um resumo financeiro contendo as pessoas cadastradas,
    /// seus saldos individuais e os totais consolidados de receitas,
    /// despesas e saldo geral.
    /// </summary>
    /// <returns>
    /// Um objeto contendo o resumo financeiro da aplicação.
    /// </returns>
    Task<SummaryResponseDto> GetSummaryAsync();
}