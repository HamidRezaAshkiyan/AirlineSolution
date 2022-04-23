using AirlineAPI.Models;

namespace AirlineAPI.Data;

public interface IPersonRepo
{
    IEnumerable<Person> GetAllPeople();
    Person GetPersonById(int id);
}