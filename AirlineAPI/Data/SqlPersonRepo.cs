using AirlineAPI.Models;

namespace AirlineAPI.Data;

public class SqlPersonRepo: IPersonRepo
{
    private readonly AirlineContext _context;

    public SqlPersonRepo(AirlineContext context)
    {
        _context = context;
    }

    public IEnumerable<Person> GetAllPeople()
    {
        return _context.People.ToList();
    }

    public Person              GetPersonById(int id)
    {
        return _context.People.SingleOrDefault(p => p.Id == id);
    }
}