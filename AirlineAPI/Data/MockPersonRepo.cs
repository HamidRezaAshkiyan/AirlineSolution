using AirlineAPI.Models;

namespace AirlineAPI.Data;

public class MockPersonRepo : IPersonRepo
{
    private readonly List<Person> _people = new() {
        new Person {Id = 1, FirstName = "hamid", LastName   = "hamidi", Age   = 21},
        new Person {Id = 2, FirstName = "Jamshid", LastName = "Jamshidi", Age = 21}
    };

    public bool SaveChanges()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Person> GetAllPeople() {
        return _people;
    }

    public Person GetPersonById(int id) {
        return _people.FirstOrDefault(p => p.Id == id) ?? throw new InvalidOperationException();
    }

    public void CreatePerson(Person person)
    {
        throw new NotImplementedException();
    }

    public void UpdatePerson(Person person)
    {
        throw new NotImplementedException();
    }

    public void DeletePerson(Person person)
    {
        throw new NotImplementedException();
    }
}