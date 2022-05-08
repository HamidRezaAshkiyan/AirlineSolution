using Airline.DataAccess.Library.Models;

namespace Airline.DataAccess.Library.Data;

public interface IPersonRepo
{
    bool                SaveChanges();
    IEnumerable<Person> GetAllPeople();
    Person              GetPersonById(int   id);
    void                CreatePerson(Person person);
    void                UpdatePerson(Person person);
    void                DeletePerson(Person person);
}