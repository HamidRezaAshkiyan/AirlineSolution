using Airline.DataAccess.Sqlite.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Airline.DataAccess.Sqlite.Library.Data;

public class AirlineContext : DbContext
{
    public AirlineContext(DbContextOptions<AirlineContext> opt) : base(opt)
    {
    }

    public DbSet<Person> People { get; set; }
}