using Airline.DataAccess.Sqlite.Library.Data;
using Airline.DataAccess.Sqlite.Library.Models;
using AirlineAPI.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AirlineAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly IMapper                   _mapper;
    private readonly IPersonRepo               _personRepo;

    public PersonController(ILogger<PersonController> logger, IPersonRepo personRepo, IMapper mapper)
    {
        _logger     = logger;
        _personRepo = personRepo;
        _mapper     = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PersonReadDto>> GetAllPeople()
    {
        return Ok(_mapper.Map<List<PersonReadDto>>(_personRepo.GetAllPeople()));
    }

    [HttpGet("{id:int}", Name = "GetPersonById")]
    public ActionResult<PersonReadDto> GetPersonById(int id)
    {
        Person person = _personRepo.GetPersonById(id);

        if (person is null) return NotFound();
        
        return Ok(_mapper.Map<PersonReadDto>(person));
    }

    [HttpPost]
    public ActionResult<PersonReadDto> CreatePerson(PersonCreateDto personCreateDto)
    {
        var personModel = _mapper.Map<Person>(personCreateDto);
        _personRepo.CreatePerson(personModel);
        _personRepo.SaveChanges();

        var personReadDto = _mapper.Map<PersonReadDto>(personModel);

        return CreatedAtRoute(nameof(GetPersonById), new {personReadDto.Id}, personReadDto);
    }

    [HttpPut("{id:int}")]
    public ActionResult UpdatePerson(int id, PersonUpdateDto personUpdateDto)
    {
        Person? personModelFromRepo = _personRepo.GetPersonById(id);
        if (personModelFromRepo is null) return NotFound();

        _mapper.Map(personUpdateDto, personModelFromRepo);
        _personRepo.UpdatePerson(personModelFromRepo);
        _personRepo.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id:int}")]
    public ActionResult PartialPersonUpdate(int id, JsonPatchDocument<PersonUpdateDto> patchDoc)
    {
        Person? personModelFromRepo = _personRepo.GetPersonById(id);
        if(personModelFromRepo is null) return NotFound();

        var personToPatch = _mapper.Map<PersonUpdateDto>(personModelFromRepo);
        patchDoc.ApplyTo(personToPatch, ModelState);

        if (TryValidateModel(personToPatch)) return ValidationProblem(ModelState);

        _mapper.Map(personToPatch, personModelFromRepo);
        _personRepo.UpdatePerson(personModelFromRepo);
        _personRepo.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeletePersonById(int id)
    {
        Person personModelFromRepo = _personRepo.GetPersonById(id);
        if (personModelFromRepo is null) return NotFound();

        _personRepo.DeletePerson(personModelFromRepo);
        _personRepo.SaveChanges();

        return NoContent();
    }
}