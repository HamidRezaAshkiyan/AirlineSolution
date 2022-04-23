using System.Security.Cryptography.X509Certificates;
using AirlineAPI.Data;
using AirlineAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly IPersonRepo               _personRepo;

    public PersonController(ILogger<PersonController> logger, IPersonRepo personRepo)
    {
        _logger     = logger;
        _personRepo = personRepo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Person>> GetAllPeople()
    {
        return Ok(_personRepo.GetAllPeople());
    }

    [HttpGet("/{id:int}")]
    public ActionResult<Person> GetPersonById(int id)
    {
        return Ok(_personRepo.GetPersonById(id));
    }
}