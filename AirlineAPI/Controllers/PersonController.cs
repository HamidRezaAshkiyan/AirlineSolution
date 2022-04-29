using System.Security.Cryptography.X509Certificates;
using AirlineAPI.Data;
using AirlineAPI.Models;
using AirlineAPI.Models.DTOs;
using AutoMapper;
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
        return Ok(_mapper.Map<PersonReadDto>(_personRepo.GetPersonById(id)));
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
}