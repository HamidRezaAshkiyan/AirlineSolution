using Airline.DataAccess.Library.Models;

namespace Airline.DataAccess.Library.Data;

public class SqlPersonRepo: IPersonRepo
{
    private readonly AirlineContext _context;

    public SqlPersonRepo(AirlineContext context)
    {
        _context = context;
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() >= 0;
    }

    public IEnumerable<Person> GetAllPeople()
    {
        return _context.People.ToList();
    }

    public Person              GetPersonById(int id)
    {
        return _context.People.SingleOrDefault(p => p.Id == id);
    }

    public void CreatePerson(Person person)
    {
        if (person is null)
            throw new ArgumentNullException(nameof(person));
        _context.People.Add(person);
    }

    public void UpdatePerson(Person person)
    {
        throw new NotImplementedException();
    }

    public void DeletePerson(Person person)
    {
        if (person is null)
            throw new ArgumentNullException(nameof(person));
        _context.People.Remove(person);
    }
}