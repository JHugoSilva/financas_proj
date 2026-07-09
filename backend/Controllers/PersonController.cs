using financas.Application.DTOs.Person;
using financas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace financas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePerson(CreatePersonDto createPersonDto)
    {
        var person = await _personService.CreatePersonAsync(createPersonDto);
        return CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPersonById(Guid id)
    {
        var person = await _personService.GetPersonByIdAsync(id);
        return person is null ? NotFound() : Ok(person);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPersons()
    {
        var persons = await _personService.GetAllPersonsAsync();
        return Ok(persons);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePerson(Guid id, [FromBody] UpdatePersonDto updatePersonDto)
    {
        var person = await _personService.UpdatePersonAsync(id, updatePersonDto);
        return person is null ? NotFound() : Ok(person);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson(Guid id)
    {
        var deleted = await _personService.DeletePersonAsync(id);

        return deleted ? NoContent() : NotFound();
    }

    [HttpGet("summary")]
    public async Task<IActionResult> GetSummary()
    {
        var summary = await _personService.GetSummaryAsync();
        return Ok(summary);
    }
}