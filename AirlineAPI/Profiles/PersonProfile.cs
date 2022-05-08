using AirlineAPI.Models;
using AirlineAPI.Models.DTOs;
using AutoMapper;

namespace AirlineAPI.Profiles;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<Person, PersonReadDto>();
        CreateMap<PersonCreateDto, Person>();
        CreateMap<PersonUpdateDto, Person>();
        CreateMap<Person, PersonUpdateDto>();
    }
}