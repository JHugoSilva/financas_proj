using financas.Application.DTOs.Person;
using financas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace financas.Controllers;

/// <summary>
/// Controller responsável pelo gerenciamento das pessoas cadastradas.
/// Disponibiliza endpoints para criação, consulta, atualização,
/// exclusão e obtenção do resumo financeiro das pessoas.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    /// <summary>
    /// Serviço responsável pelas regras de negócio relacionadas às pessoas.
    /// </summary>
    private readonly IPersonService _personService;

    /// <summary>
    /// Inicializa uma nova instância do controller de pessoas.
    /// </summary>
    /// <param name="personService">
    /// Serviço responsável pelas operações da entidade Person.
    /// </param>
    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    /// <summary>
    /// Cadastra uma nova pessoa.
    /// </summary>
    /// <param name="createPersonDto">
    /// Dados necessários para o cadastro da pessoa.
    /// </param>
    /// <returns>
    /// Retorna o recurso criado juntamente com sua localização.
    /// </returns>
    /// <response code="201">Pessoa criada com sucesso.</response>
    /// <response code="400">Os dados informados são inválidos.</response>
    [HttpPost]
    public async Task<IActionResult> CreatePerson(CreatePersonDto createPersonDto)
    {
        var person = await _personService.CreatePersonAsync(createPersonDto);

        return CreatedAtAction(
            nameof(GetPersonById),
            new { id = person.Id },
            person);
    }

    /// <summary>
    /// Obtém uma pessoa pelo seu identificador.
    /// </summary>
    /// <param name="id">Identificador da pessoa.</param>
    /// <returns>
    /// Os dados da pessoa encontrada.
    /// </returns>
    /// <response code="200">Pessoa encontrada.</response>
    /// <response code="404">Pessoa não encontrada.</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPersonById(Guid id)
    {
        var person = await _personService.GetPersonByIdAsync(id);

        return person is null
            ? NotFound()
            : Ok(person);
    }

    /// <summary>
    /// Obtém todas as pessoas cadastradas.
    /// </summary>
    /// <returns>
    /// Lista de pessoas.
    /// </returns>
    /// <response code="200">Lista retornada com sucesso.</response>
    [HttpGet]
    public async Task<IActionResult> GetAllPersons()
    {
        var persons = await _personService.GetAllPersonsAsync();

        return Ok(persons);
    }

    /// <summary>
    /// Atualiza os dados de uma pessoa existente.
    /// </summary>
    /// <param name="id">Identificador da pessoa.</param>
    /// <param name="updatePersonDto">
    /// Dados utilizados para atualização.
    /// </param>
    /// <returns>
    /// Os dados atualizados da pessoa.
    /// </returns>
    /// <response code="200">Pessoa atualizada com sucesso.</response>
    /// <response code="400">Os dados informados são inválidos.</response>
    /// <response code="404">Pessoa não encontrada.</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePerson(
        Guid id,
        [FromBody] UpdatePersonDto updatePersonDto)
    {
        var person = await _personService.UpdatePersonAsync(id, updatePersonDto);

        return person is null
            ? NotFound()
            : Ok(person);
    }

    /// <summary>
    /// Remove uma pessoa do sistema.
    /// </summary>
    /// <param name="id">Identificador da pessoa.</param>
    /// <returns>
    /// Retorna sucesso caso a pessoa seja removida.
    /// </returns>
    /// <response code="204">Pessoa removida com sucesso.</response>
    /// <response code="404">Pessoa não encontrada.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson(Guid id)
    {
        var deleted = await _personService.DeletePersonAsync(id);

        return deleted
            ? NoContent()
            : NotFound();
    }

    /// <summary>
    /// Obtém um resumo financeiro de todas as pessoas cadastradas.
    /// O resumo contém receitas, despesas e saldo individual de cada pessoa,
    /// além dos totais consolidados da aplicação.
    /// </summary>
    /// <returns>
    /// Resumo financeiro geral.
    /// </returns>
    /// <response code="200">Resumo retornado com sucesso.</response>
    [HttpGet("summary")]
    public async Task<IActionResult> GetSummary()
    {
        var summary = await _personService.GetSummaryAsync();

        return Ok(summary);
    }
}