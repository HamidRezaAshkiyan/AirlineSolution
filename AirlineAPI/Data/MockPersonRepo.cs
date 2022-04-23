using AirlineAPI.Models;

namespace AirlineAPI.Data;

public class MockPersonRepo : IPersonRepo
{
    public List<Person> People = new() {
        new Person {Id = 1, FirstName = "hamid", LastName   = "hamidi", Age   = 21},
        new Person {Id = 1, FirstName = "Jamshid", LastName = "Jamshidi", Age = 21}
    };

    public IEnumerable<Person> GetAllPeople() {
        return People;
    }

    public Person GetPersonById(int id) {
        return People.FirstOrDefault(p => p.Id == id) ?? throw new InvalidOperationException();
    }
}